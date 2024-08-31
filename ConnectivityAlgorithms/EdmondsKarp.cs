public class FluxMaxim
{
    static readonly int N = 6;

    /* Returnează true dacă există un drum
    de la sursa 's' la destinatia 't' in graful
    rezidual. Pastreaza drumul in vectorul parinti */
    bool BFS(int[,] rGraf, int s, int t, int[] parinti)
    {
        // Cream un vector de noduriVizitate
        // toate nodurile sunt marcate nevizitate
        bool[] noduriVizitate = new bool[N];
        for (int i = 0; i < N; ++i)
            noduriVizitate[i] = false;

        // Cream o coada, introducem nodul sursa
        // ssi il marcam ca vizitat
        Queue<int> coada = new Queue<int>();
        coada.Enqueue(s);
        noduriVizitate[s] = true;
        parinti[s] = -1;

        // BFS clasic
        while (coada.Count != 0)
        {
            int u = coada.Dequeue();

            for (int v = 0; v < N; v++)
            {
                if (noduriVizitate[v] == false
                    && rGraf[u, v] > 0)
                {
                    // Daca gasim un drum de la nodul sursa
                    // la destinatie, nu este nevoie sa continuam.
                    // Putem returna true la finalul iteratiei.
                    if (v == t)
                    {
                        parinti[v] = u;
                        return true;
                    }
                    coada.Enqueue(v);
                    parinti[v] = u;
                    noduriVizitate[v] = true;
                }
            }
        }

        // Daca nu am gasit niciun drum augmentat, returnam false
        return false;
    }

    // Returneaza fluxul maxim
    int EdmondsKarp(int[,] graf, int s, int t)
    {
        int u, v;

        // Cream graful rezidual in care introducem
        // capacitatile originale din graf

        // Graful rezidual unde rGraph[i,j]
        // indica capacitatea reziduala a muchiei ij
        // (daca nu exista, atunci este 0)
        int[,] rGraph = new int[N, N];

        for (u = 0; u < N; u++)
            for (v = 0; v < N; v++)
                rGraph[u, v] = graf[u, v];

        int[] parinti = new int[N];

        int fluxMax = 0;

        // fluxul creste cat exista drumuri augmentate
        while (BFS(rGraph, s, t, parinti))
        {
            // Gasim capacitatea minima a arcelor 
            // de-a lungul unui drum augmentat. 
            int fluxDrum = int.MaxValue;
            for (v = t; v != s; v = parinti[v])
            {
                u = parinti[v];
                fluxDrum
                    = Math.Min(fluxDrum, rGraph[u, v]);
            }

            // updatam capacitatile reziduale 
            for (v = t; v != s; v = parinti[v])
            {
                u = parinti[v];
                rGraph[u, v] -= fluxDrum;
                rGraph[v, u] += fluxDrum;
            }

            // creste fluxul
            fluxMax += fluxDrum;
        }

        // returnam fluxul final
        return fluxMax;
    }

    public static void Main()
    {
        // date de intrare
        int[,] graph = new int[,] {
            { 0, 16, 13, 0, 0, 0 }, { 0, 0, 14, 12, 0, 0 },
            { 0, 0, 0, 0, 14, 0 },  { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },   { 0, 0, 0, 0, 0, 0 }
        };
        FluxMaxim m = new FluxMaxim();

        Console.WriteLine("Fluxul maxim este: "
                          + m.EdmondsKarp(graph, 0, 5));
    }
}