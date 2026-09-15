using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tetelek
{
    internal class Program
    {
        static int[] A =  { 1, 4, 2, 8, 12, 15, 19, 25, 3, -2 };
        static int N = A.Length;
        static int Sorozatszámítás()
        {
            int S = 0;
            for (int i = 0; i < N; i++)
            {
                S = S + A[i];
            }

            return S;
        }
        static bool Eldöntés()
        {
            int i = 0;
            bool VAN;
            while (i < N && !(A[i] % 2 == 0))
            {
                i = i + 1;
            }
            VAN = i < N;
            return VAN;
        }
        static int Kiválasztás()
        {
            int i = 0;
            int sorszam = -1;
            if (!Eldöntés()) return sorszam;
            else
            {
                while (!(A[i] % 2 == 0))  i = i + 1;
            }
            sorszam = i;
            return sorszam;
        }
        
        static int Keresés()
        {
            int i = 0;
            while (i < N && !(A[i] % 2 == 0))
            {
                i = i + 1;
            }
            bool VAN = i < N;
            if (VAN) return i;
            else return -1;
        }
        static int Megszámolás()
        {
            int DB = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] % 2 == 0) DB = DB + 1;
            }
            return DB;
        }
        static int MinimumKiválasztás()
        {
            int INDEX = 0;
            for (int i = 1; i < N; i++)
            {
                if (A[i] < A[INDEX]) INDEX = i;
            }
            return INDEX;
        }
        static int [] Másolás()
        {
            int[] B = new int[N];
            int b = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] % 2 == 0 && A[i] != 0)
                {
                    B[b] = A[i];
                    b = b + 1;
                }
            }
            return B;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Összegzés: {Sorozatszámítás()}");
            Console.WriteLine($"Eldöntés: {Eldöntés()}");
            Console.WriteLine($"Kiválasztás: {Kiválasztás()}");
            Console.WriteLine($"Keresés: {Keresés()}");
            Console.WriteLine($"Megszámolás (páros): {Megszámolás()}");
            Console.WriteLine($"Minimum kiválasztás: {MinimumKiválasztás()}");
            int [] Párosok = Másolás(); // Kiválogatás

            Console.ReadKey();
        }
    }
}
