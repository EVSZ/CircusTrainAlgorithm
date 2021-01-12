using COMEONEBITHHHHHH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMEONEBITHHHHHH
{
    public class Trein : ITrein
    {
        public List<Wagon> wagons { get; set; }

        public Trein()
        {
        }
        public Trein MaakTreinAanMetWagon()
        {
            wagons = new List<Wagon>();     //Nieuwe lijst van wagonnen bij aanmaakt trein
            Wagon wagon = new Wagon();      //Nieuwe wagon omdat trein nog leeg is  
            wagons.Add(wagon);              //Voeg wagon toe aan trein
            return this;
        }
        public List<Wagon> GetAllWagons()
        {
            return wagons;      //geef lijst van wagonnen terug
        }
        public void AddWagonToTrein(Wagon wagon)
        {
            wagons.Add(wagon);      //Voeg wagon toe aan trein
        }
        public Wagon ReturnWagonWaarEenDierInPast(Trein trein, Dier HuidigDier)
        {
            List<Wagon> BeschikbareWagonnen = new List<Wagon>();        //Nieuwe lijst voor beschikbare wagonnen
            foreach (Wagon wagon in trein.wagons)
            {
                if (!wagon.IsErIemandInGevaar(HuidigDier) && wagon.PastDierInWagon(HuidigDier))     //Als Dieren elkaar niet op eten & dier + punten !> 10  
                {
                    BeschikbareWagonnen.Add(wagon);     //Voeg wagon toe aan beschikbare wagonnen
                    break;      //Stop met zoeken want beschikbare wagon is gevonden
                }
            }
            if (BeschikbareWagonnen.Count == 0)     //Als er geen wagonnen beschikbaar zijn
            {
                Wagon wagon = new Wagon();      //Maak een nieuwe wagon aan
                trein.AddWagonToTrein(wagon);       //Voeg de wagon toe aan de trein
                return wagon;       //Geef nieuwe wagon terug
            }
            else
            {
                return BeschikbareWagonnen[0];  //Geef de eerste beschikbare wagon terug
            }
        }
    }
}

