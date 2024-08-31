using System;
using System.IO;
using System.Collections.Generic;

class Algoritm
{
    public class Muchie
    {
        public int src, dest;
        public Muchie(int s, int d)
        {
            this.src = s;
            this.dest = d;
        }
    }

    public class Graf
    {
        public int N, E;

        public Muchie[] muchii;
        public Graf(int v, int e)
        {
            this.N = v;
            this.E = e;
            this.muchii = new Muchie[e];
        }
    }

    // structura set pentru Union-Find
    public class Set
    {
        public int radacina;
        public int dimensiune;
        public Set(int p, int r)
        {
            this.radacina = p;
            this.dimensiune = r;
        }
    }

    public static int kargerTaieturaMinima(Graf graf)
    {
        int N = graf.N, E = graf.E;
        Muchie[] muchii = graf.muchii;

        // cream N seturi
        Set[] seturi = new Set[N];

        // fiecare element este parte dintr-un set in care este radacina
        for (int v = 0; v < N; ++v)
        {
            seturi[v] = new Set(v, 0);
        }

        int noduri = N;

        // contractam noduri pana ramanem cu 2
        while (noduri > 2)
        {
            // alegem o muchie in mod aleatoriu
            int i = ((int)(new Random().NextDouble() * 10))
                    % E;

            // gasim seturile in care se afla varfurile muchiei
            int set1 = find(seturi, muchii[i].src);
            int set2 = find(seturi, muchii[i].dest);

            if (set1 == set2)
            {
                continue;
            }

            // contractam muchia prin functia Union
            else
            {
                Console.WriteLine("Contractam muchia "
                                  + muchii[i].src + "-"
                                  + muchii[i].dest);
                noduri--;
                Union(seturi, set1, set2);
            }
        }

        // avem doua supernoduri ramase in graful
        // final, deci cardinalul muchiilor ramase
        // este cardinalul taieturii minime
        int taietura = 0;
        for (int i = 0; i < E; i++)
        {
            int set1 = find(seturi, muchii[i].src);
            int set2 = find(seturi, muchii[i].dest);
            if (set1 != set2)
            {
                taietura++;
            }
        }
        return taietura;
    }

    public static int find(Set[] seturi, int i)
    {
        if (seturi[i].radacina != i)
        {
            seturi[i].radacina
                = find(seturi, seturi[i].radacina);
        }

        return seturi[i].radacina;
    }

    public static void Union(Set[] seturi, int x, int y)
    {
        int xroot = find(seturi, x);
        int yroot = find(seturi, y);

        if (seturi[xroot].dimensiune < seturi[yroot].dimensiune)
        {
            seturi[xroot].radacina = yroot;
        }
        else if (seturi[xroot].dimensiune
                 > seturi[yroot].dimensiune)
        {
            seturi[yroot].radacina = xroot;
        }

        else
        {
            seturi[yroot].radacina = xroot;
            seturi[xroot].dimensiune++;
        }
    }
    public static void Main()
    {

        int N = 8, E = 14;
        Graf graf = new Graf(N, E);

        graf.muchii[0] = new Muchie(0, 1);
        graf.muchii[1] = new Muchie(0, 4);
        graf.muchii[2] = new Muchie(0, 5);
        graf.muchii[3] = new Muchie(1, 4);
        graf.muchii[4] = new Muchie(1, 5);
        graf.muchii[5] = new Muchie(1, 2);
        graf.muchii[6] = new Muchie(2, 3);
        graf.muchii[7] = new Muchie(2, 6);
        graf.muchii[8] = new Muchie(2, 7);
        graf.muchii[9] = new Muchie(3, 7);
        graf.muchii[10] = new Muchie(3, 6);
        graf.muchii[11] = new Muchie(4, 5);
        graf.muchii[12] = new Muchie(5, 6);
        graf.muchii[13] = new Muchie(6, 7);

        int rezultat = kargerTaieturaMinima(graf);
        Console.WriteLine(
            "Taietura gasita prin algoritmul probabilistic Karger "
            + rezultat);
    }
}
