class Graf1
{
    private int N;

    // vectori de liste de adiacenta
    private List<int>[] vecini;

    // constructor
    Graf1(int v)
    {
        N = v;
        vecini = new List<int>[v];
        for (int i = 0; i < v; ++i)
            vecini[i] = new List<int>();
    }

    // functie care adauga muchii in graf
    void AdaugaMuchie(int v, int w)
    {
        vecini[v].Add(w);
    }

    void BFS(int v)
    {
        Queue<int> coada = new Queue<int>();
        bool[] noduriVizitate = new bool[N];

        // marcam nodul sursa ca vizitat si il adaugam in coada
        noduriVizitate[v] = true;
        coada.Enqueue(v);

        // iteram printre nodurile cozii
        while (coada.Count > 0)
        {

            // scoatem nodul curent din coada
            int nodCurent = coada.Dequeue();
            Console.Write(nodCurent + " ");

            // iteram printre vecinii nodului curent
            // orice nod nevizitat este marcat vizitat
            // si introdus in coada
            foreach (int x in vecini[nodCurent])
            {
                if (!noduriVizitate[x])
                {
                    noduriVizitate[x] = true;
                    coada.Enqueue(x);
                }
            }
        }
    }

    public static void Main(String[] args)
    {
        Graf1 g = new Graf1(7);

        g.AdaugaMuchie(0, 2);
        g.AdaugaMuchie(0, 5);
        g.AdaugaMuchie(0, 6);
        g.AdaugaMuchie(2, 4);
        g.AdaugaMuchie(6, 1);
        g.AdaugaMuchie(6, 3);

        Console.WriteLine(
            "Parcurgerea BFS "
            + "(incepand de la nodul 0)");

        g.BFS(0);
        Console.ReadKey();
    }
}