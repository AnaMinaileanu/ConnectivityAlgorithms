using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectivityAlgorithms_Thesis
{
    public class UnionFindImproved
    {
        static void Main(string[] args)
        {
            UnionFind problem = new UnionFind(9);
            problem.union(1, 0);
            problem.union(2, 3);
            problem.union(4, 5);
            problem.union(7, 8);
            problem.union(6, 7);
            problem.union(0, 3);
            problem.union(4, 6);
            problem.union(3, 8);
            int[] arr = problem.noduri;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


            Console.WriteLine("The number of components is " + problem.compConexe);
        }
    }

    public class UnionFind
    {
        public int nrNoduri;
        public int[] componente;
        public int[] noduri;

        public int compConexe;

        public UnionFind(int nrNoduri)
        {

            if (nrNoduri <= 0)
                throw new ArgumentException("Parameter can't be null");

            this.nrNoduri = compConexe = nrNoduri;
            componente = new int[nrNoduri];
            noduri = new int[nrNoduri];

            for (int i = 0; i < nrNoduri; i++)
            {
                noduri[i] = i; // fiecare componenta este propria radacina
                componente[i] = 1; // fiecare componenta are dimensiunea 1
            }
        }

        public int find(int p)
        {

            int radacina = p;
            while (radacina != noduri[radacina])
                radacina = noduri[radacina];

            while (p != radacina)
            {
                int varx = noduri[p];
                noduri[p] = radacina;
                p = varx;
            }

            return radacina;
        }

        public void union(int p, int q)
        {

            if (find(p) == find(q)) return;

            int radacina1 = find(p);
            int radacina2 = find(q);

            if (componente[radacina1] < componente[radacina2])
            {
                componente[radacina2] += componente[radacina1];
                noduri[radacina1] = radacina2;
                componente[radacina1] = 0;
            }
            else
            {
                componente[radacina1] += componente[radacina2];
                noduri[radacina2] = radacina1;
                componente[radacina2] = 0;
            }

            compConexe--;
        }
    }
}
