using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncarcareMasini
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Usurelu\source\repos\IncarcareMasini\IncarcareMasini\MasiniDeIncarcat.txt");

            System.Console.WriteLine("Contents of  = MasiniDeIncarcat.txt");
            int tensiuneTotala = Int32.Parse(lines[0]);

            List<Masina> listaMasini = new List<Masina>();
            string filename = @"C:\Users\Usurelu\source\repos\IncarcareMasini\IncarcareMasini\MasiniDeIncarcat.txt";
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader rdr = new StreamReader(fs);
            
                rdr.ReadLine();

                while (!rdr.EndOfStream)
                {
                    string[] linia = rdr.ReadLine().Split();
                    listaMasini.Add( new Masina(linia[0], Int32.Parse(linia[1]), Int32.Parse(linia[2]), Int32.Parse(linia[3]), DateTime.Parse(linia[4] + ' ' + linia[5]), Int32.Parse(linia[6])));
                    //.WriteLine("\t" + linia[4]);
                }


            foreach (Masina car in listaMasini)
            {
                car.calculeazaDurataIncarcarii();
                car.ordonareDupaTimp();
                Console.WriteLine("\t" + car.durataIncarcarii);
            }

            List<Masina> SortedList = listaMasini.OrderBy(o => o.nrMinimDeAsteptare).ToList();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Usurelu\source\repos\IncarcareMasini\IncarcareMasini\WriteLines2.txt"))
            {
                foreach (Masina m in SortedList)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                   
                        file.WriteLine(m.name, m.oraAlimentare);

                }
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        
    }
}
