using COMEONEBITHHHHHH.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMEONEBITHHHHHH
{
    public class Program
    {
        ITrein FunctieTrein = new Trein();
        IDier DierInterface = new Dier();
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Hoeveel Dieren Heb je?");
            int HoeveelheidDieren = Convert.ToInt32(Console.ReadLine());        //input voor automatische dier generatie
            program.GetResult(program.InitiateAlgorithm(HoeveelheidDieren));
        }

        private Trein InitiateAlgorithm(int Hoeveelheid)
        {
            Trein trein = FunctieTrein.MaakTreinAanMetWagon();      //Maak trein aan met wagon
            foreach (Dier AanDeBeurt in DierInterface.MaakDier(Hoeveelheid))        //Itereer door alle gegenereerde dieren
            {
                FunctieTrein.ReturnWagonWaarEenDierInPast(trein, AanDeBeurt).PlaatsDierInWagon(AanDeBeurt);      //Stop dier in returned wagon
            }
            return trein;       //Voor weergave van data
        }
        private void GetResult(Trein trein)
        {
            Console.WriteLine("        ___ ");
            Console.WriteLine("   _][__| |");
            Console.WriteLine("  <_______|-1");
            Console.WriteLine("    O-O-O");

            foreach (Wagon gevuldewagonnen in FunctieTrein.GetAllWagons())      //Itereer door alle wagons uit de trein
            {
                Console.WriteLine(" ____________ ");
                foreach (Dier dier in gevuldewagonnen.dierenLijst)      //Itereer door elk dier uit de wagon
                {
                    Console.WriteLine("|" + dier.gewicht + " " + dier.dieet + "         |");        //Data weergave over dier
                }
                Console.WriteLine("|____________|");
                Console.WriteLine("   0     0    ");
                Console.WriteLine("/////////////// Punten: " + gevuldewagonnen.punten);     //Totaal aantal punten van elke wagon
            }

            Console.WriteLine("AANTAL WAGONNEN: " + trein.wagons.Count);        //Totaal aantal wagonnen in de trein

            int i = 0;
            int a = 0;
            int b = 0;
            foreach (Wagon wagon in trein.wagons)       //Itereer door wagonnen voor extra data
            {
                if (wagon.isvol == false)
                {
                    i++;
                }
                foreach(Dier dier in wagon.dierenLijst)     //Itereer door alle dieren voor extra Data
                {
                    if(dier.dieet == "C")
                    {
                        a++;
                    }
                    else if(dier.dieet == "H")
                    {
                        b++;
                    }
                }
            }
            Console.WriteLine("AANTAL LEGE WAGONNEN: " + i);    
            Console.WriteLine("AANTAL Carnivoren: " + a);
            Console.WriteLine("AANTAL Herbivoren: " + b);
        }
    }
}

