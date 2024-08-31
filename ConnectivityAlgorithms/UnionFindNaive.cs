using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectivityAlgorithms_Thesis
{
    public class UnionFindNaive
    {
        public static void main(string[] args)
        {
            UnionFindMetodaNaiva problem2 = new UnionFindMetodaNaiva(16);
            problem2.Union(0, 1);
            problem2.Union(0, 2);
            problem2.Union(1, 9);
            problem2.Union(3, 6);
            problem2.Union(6, 8);
            problem2.Union(4, 5);
            problem2.Union(5, 7);
            problem2.Union(5, 10);
            problem2.Union(11, 1);
            problem2.Union(12, 7);
            problem2.Union(13, 4);
            problem2.Union(14, 6);
            problem2.Union(14, 15);
            problem2.Union(3, 10);
            Console.WriteLine("Numarul de componente conexe este " + problem2.nrComponente);
        }
    }


    public class UnionFindMetodaNaiva
    {
        public int nrNoduri;
        public int[] noduri;
        public int nrComponente = 0;
        public UnionFindMetodaNaiva(int nrNoduri)
        {
            if (nrNoduri <= 0)
                throw new ArgumentException("Parameter can't be null");
            this.nrNoduri = nrComponente = nrNoduri;
            noduri = new int[nrNoduri];
            for (int i = 0; i < nrNoduri; i++)
            {
                noduri[i] = i;
            }
        }

        public int Find(int i)
        {
            while (i != noduri[i])
                i = noduri[i];
            return i;
        }

        public bool Conex(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            noduri[i] = j;
            if (i != j)
                nrComponente--;
        }

    }
}
