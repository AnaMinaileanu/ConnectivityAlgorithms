class Graf
{
    private int N;

    // vectori de liste de adiacenta
    private List<int>[] vecini;

    // constructor
    Graf(int v)
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

    void DFSRecursiv(int v, bool[] noduriVizitate)
    {
        // marcam nodul curent ca vizitat
        noduriVizitate[v] = true;
        Console.Write(v + " ");

        // parcurgem toti vecinii nodului curent
        List<int> vList = vecini[v];
        foreach (var n in vList)
        {
            if (!noduriVizitate[n])
                DFSRecursiv(n, noduriVizitate);
        }
    }

    void DFS(int v)
    {
        // marcam nodurile ca nevizitate
        bool[] noduriVizitate = new bool[N];

        // apelam functia recursiva
        DFSRecursiv(v, noduriVizitate);
    }

    public static void Main(String[] args)
    {
        Graf g = new Graf(7);

        g.AdaugaMuchie(0, 2);
        g.AdaugaMuchie(0, 5);
        g.AdaugaMuchie(0, 6);
        g.AdaugaMuchie(2, 4);
        g.AdaugaMuchie(6, 1);
        g.AdaugaMuchie(6, 3);

        Console.WriteLine(
            "Parcurgerea DFS "
            + "(incepand de la nodul 0)");

        g.DFS(0);
        Console.ReadKey();
    }
}
