using System;
using System.Collections;
using System.Collections.Generic;

namespace Fasada_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Fasada fasada = new Fasada();
            fasada.SprawdzCiag(1, 1, 2);
            Console.WriteLine("");
            fasada.SprawdzCiag(7, 10, 17);
            Console.WriteLine("");
            fasada.SprawdzCiag(2, 4, 8);
            Console.WriteLine("");
            fasada.SprawdzCiag(3, 17, 1);
            Console.WriteLine("");
            fasada.SprawdzCiag(0, 21, 37);
            Console.WriteLine("");
            fasada.SprawdzCiag(7, 15, 23);
            Console.WriteLine("");
            fasada.SprawdzCiag(1597, 2584, 4181);
            Console.WriteLine("");
            fasada.SprawdzCiag(2137, 3333, 4160);
            Console.WriteLine("");
            fasada.SprawdzCiag(-1, -1, -2);


            Console.WriteLine("");
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine("");


            Figura f = new TrojkatRownoboczny();
            f.Rysuj();
            Console.WriteLine("");
            Console.WriteLine("");
            Kwadrat k = new Kwadrat();
            Figura f2 = new KwadratAdapter(k);
            f2.Rysuj();

            Console.Read();
        }
    }
    class CiagAryt
    {
        public bool SprAryt(double a1, double a2, double a3)
        {
            if (a2 - a1 == a3 - a2)
            {
                return true;
            }
            else return false;
        }
    }
    class CiagGeo
    {
        public bool SprGeo(double a1, double a2, double a3)
        {
            if ((a2 / a1) == (a3 / a2))
            {
                return true;
            }
            else return false;
        }
    }
    class CiagFib
    {
        public bool SprFibo(double a1, double a2, double a3)
        {
            List<double> lista = new List<double>();
            bool fib = false;
            int i = 1;
            int j = 2;
            lista.Add(1);
            lista.Add(1);
            while (lista[i] < a3)
            {
                lista.Add(lista[i - 1] + lista[i]);
                i++;
            }
            while (j - 2 < lista.Count)
            {
                if (a1 == lista[j - 2] && a2 == lista[j - 1] && a3 == lista[j])
                {
                    fib = true;
                }
                j++;
            }
            return fib;
        }
    }
    class CiagInny
    {
        public void SprInny(double a1, double a2, double a3)
        {
            CiagAryt ca = new CiagAryt();
            CiagGeo cg = new CiagGeo();
            CiagFib cf = new CiagFib();
            if (!ca.SprAryt(a1, a2, a3) && !cg.SprGeo(a1, a2, a3) && !cf.SprFibo(a1, a2, a3))
            {
                Console.WriteLine("Jest to ciąg niestandardowy");
            }
        }
    }
    class Fasada
    {
        CiagAryt objAryt;
        CiagGeo objGeo;
        CiagFib objFib;
        CiagInny obj4Inny;
        public Fasada()
        {
            objAryt = new CiagAryt();
            objGeo = new CiagGeo();
            objFib = new CiagFib();
            obj4Inny = new CiagInny();
        }
        public void SprawdzCiag(double a1, double a2, double a3)
        {
            if (objAryt.SprAryt(a1, a2, a3))
            {
                Console.WriteLine("Jest to ciąg arytmetyczny");
            }
            if (objGeo.SprGeo(a1, a2, a3))
            {
                Console.WriteLine("Jest to ciąg geometryczny");
            }
            if (objFib.SprFibo(a1, a2, a3))
            {
                Console.WriteLine("Jest to ciąg Fibonacciego");
            }
            objAryt.SprAryt(a1, a2, a3);
            objGeo.SprGeo(a1, a2, a3);
            objFib.SprFibo(a1, a2, a3);
            obj4Inny.SprInny(a1, a2, a3);
        }
    }
    public interface Figura
    {
        void Rysuj();
    }
    public class TrojkatRownoboczny : Figura
    {
        public void Rysuj()
        {
            Console.WriteLine("  o  ");
            Console.WriteLine(" o o ");
            Console.WriteLine("ooooo");
        }
    }
    public class Kwadrat : Figura
    {
        public void Rysuj()
        {
            Console.WriteLine("ooooo");
            Console.WriteLine("o   o");
            Console.WriteLine("ooooo");
        }
    }
    public class KwadratAdapter : Figura
    {
        private Kwadrat kwadrat;

        public KwadratAdapter(Kwadrat kwadrat)
        {
            this.kwadrat = kwadrat;
        }
        public void Rysuj()
        {
            kwadrat.Rysuj();
        }
    }
}
