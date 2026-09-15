using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reklam
{
    internal class Program
    {

        class Rendeles
        {
            public int Nap {  get; set; }
            public string Hirdet { get; set; }
            public int Db { get; set; }

            public Rendeles(int nap, string hirdet, int db)
            {
                Nap = nap;
                Hirdet = hirdet;
                Db = db;

            }
        }
        static List<Rendeles> rendelesek = new List<Rendeles>();
        static int osszes(string varos, int nap)
        {
            int osszeg = 0;
            foreach (var r in rendelesek)
            {
                if(r.Nap == nap && r.Hirdet == varos)
                {
                    osszeg += r.Db;
                }
            }
            return osszeg;
        }

        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("rendel.txt");
            
            foreach (var s in sorok)
            {
                string[] darabok = s.Split(' ');  
                Rendeles r = new Rendeles(int.Parse(darabok[0]), darabok[1], int.Parse(darabok[2]));
                rendelesek.Add(r);
            }

            #region 2. feladat
            Console.WriteLine($"2. feladat: Rendelések száma: {rendelesek.Count}");
            #endregion

            #region 3. feladat
            Console.Write("Írja be egy nap számát: ");
            int nap = int.Parse(Console.ReadLine());

            int ossz = 0;

            foreach (var r in rendelesek)
            {
                if(r.Nap == nap)
                {
                    ossz += r.Db;
                }
            }

            Console.WriteLine($"{ossz} rendelés történt.");
            #endregion

            #region 4. feladat
            int feladott = 0;
            for (int i = 0; i <= 30; i++)
            {
                int szamlalo = 0;
                foreach (var r in rendelesek)
                {
                    if(r.Nap == i && r.Hirdet == "NR")
                    {
                        szamlalo++;
                    }
                }
                if(szamlalo == 0)
                {
                    feladott++;
                }
                else
                {
                    Console.WriteLine($"{feladott} napon nem adtak le rendelést");
                    
                }

                int max = 0;
                foreach (var r in rendelesek)
                {
                    if(r.Db > max)
                    {
                        max = r.Db;
                    }
                }

                foreach (var r in rendelesek)
                {
                    if(r.Db == max)
                    {
                        Console.WriteLine($"A legnagyobb darabszám: {max}, rendelés napja: {r.Nap}");
                        break;
                    }
                }

                int pl21 = osszes("PL", 21);
                int tv21 = osszes("TV", 21);
                int nr21 = osszes("NR", 21);

                Console.WriteLine($"A rendelt termékek darabszáma a 21. napon PL: {pl21}, TV: {tv21}, NR: {nr21}");

                StreamWriter sw = new StreamWriter("kampany.txt");
                sw.WriteLine("Napok\t..10\t11..20\t21..30");

                sw.Write("PL\t");
                int osszesen = 0;
                for(nap = 1; nap <= 30; nap++)
                {
                    osszesen += osszes("PL", nap);
                    if(nap == 10)
                    {
                        sw.Write($"{osszesen}\t");
                        osszesen = 0;
                    }
                    if (nap == 20)
                    {
                        sw.Write($"{osszesen}\t");
                        osszesen = 0;
                    }
                }
                sw.WriteLine(osszesen);

                sw.Write("TV\t");
                
                for (nap = 1; nap <= 30; nap++)
                {
                    osszesen += osszes("TV", nap);
                    if (nap == 10)
                    {
                        sw.Write($"{osszesen}\t");
                        osszesen = 0;
                    }
                    if (nap == 20)
                    {
                        sw.Write($"{osszesen}\t");
                        osszesen = 0;
                    }
                }
                sw.WriteLine(osszesen);

                sw.Write("NR\t");

                for (nap = 1; nap <= 30; nap++)
                {
                    osszesen += osszes("NR", nap);
                    if (nap == 10)
                    {
                        sw.Write($"{osszesen}\t");
                        osszesen = 0;
                    }
                    if (nap == 20)
                    {
                        sw.Write($"{osszesen}\t");
                        osszesen = 0;
                    }
                }
                sw.WriteLine(osszesen);

                sw.Close();

            }
            #endregion
        }
    }
}
