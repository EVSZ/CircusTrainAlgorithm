using COMEONEBITHHHHHH.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMEONEBITHHHHHH
{
    public class Wagon : IWagon
    {
        public int punten { get; private set; }
        public bool isvol { get; private set; }
        public List<Dier> dierenLijst { get; private set; }

        public Wagon()
        {
            dierenLijst = new List<Dier>();     //Elke wagon wordt aangemaakt met een nieuwe lege lijst van dieren
            isvol = false;      //Wagon is leeg
        }
        public void PlaatsDierInWagon(Dier HuidigDier)
        {
            dierenLijst.Add(HuidigDier);        //Voeg dier toe aan wagon
            punten += HuidigDier.gewicht;       //Voeg gewicht van dier toe aan wagon
        }
        public bool PastDierInWagon(Dier HuidigDier)
        {
            if (punten + HuidigDier.gewicht > 10)       //Als punten > 10 = te vol
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsErIemandInGevaar(Dier HuidigDier)
        {
            int AantalGechekteDieren = 0;       //count zodat alle dieren van de wagon worden gecheckt
            foreach (Dier WagonDier in dierenLijst)
            {
                if (WagonDier.ZijnWeBoosOpElkaar(WagonDier, HuidigDier))        //Als de dieren boos op elkaar zijn
                {
                    return true;        //mogen ze niet bij elkaar
                }
                else
                {
                    AantalGechekteDieren++;     //Anders ga door naar het volgende dier
                }
            }
            if (AantalGechekteDieren == dierenLijst.Count)      //Aantal gechekte dieren = aantal wagon dieren? 
            {
                return false;       //Niemand is in gevaar
            }
            return false;
        }
    }
}
