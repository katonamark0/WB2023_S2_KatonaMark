using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RandomSzam
{
    internal class Program
    {
        class Szam
        {
            public int Szamok {  get; set; }


            public Szam(string sor)
            {
                string[] darabok = sor.Split(',');
                Szamok = int.Parse(darabok[0]);

            }
        }
        
        static void Main(string[] args)
        {

            Console.Write("1. feladat:"); 

            Random r = new Random();
            int[] szamok = new int[280];

            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = r.Next(1, 1000);


                if (szamok[i] % 3 == 0 && szamok[i] % 7 == 0)
                {
                    Console.Write($"{szamok[i] + ","} ");
                }
            }



            using (StreamWriter sw = new StreamWriter("szamok.txt"))
            {
                foreach (var s in szamok)
                {
                    sw.WriteLine(s);
                }
            }
            
           








        }
    }
}
