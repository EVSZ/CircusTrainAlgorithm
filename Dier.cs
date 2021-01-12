using COMEONEBITHHHHHH.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMEONEBITHHHHHH
{
    public class Dier : IDier
    {
        public string dieet { get; private set; }
        public int gewicht { get; private set; }
        public Dier(string Dieet, int Gewicht)
        {
            dieet = Dieet;
            gewicht = Gewicht;
        }
        public Dier()
        {

        }
        public bool ZijnWeBoosOpElkaar(Dier WagonDier, Dier HuidigDier)
        {
            if ((HuidigDier.dieet == "C" && HuidigDier.gewicht >= WagonDier.gewicht)        //Als het dier dat in de wagon moet het andere dier op eet
                    || (WagonDier.dieet == "C" && WagonDier.gewicht >= HuidigDier.gewicht)) //Als het dier dat in de wagon zit het andere dier op eet
            {
                return true;        //Dieren mogen niet bij elkaar, dus JA ze zijn boos :(
            }
            else
            {
                return false;       //Dieren zijn blij en mogen bij elkaar :)
            }
        }
        public List<Dier> MaakDier(int HoeveelheidDieren)
        {
            string[] Dieet = { "C", "H"};       //String waardes voor dieet
            int[] Gewicht = { 1, 3, 5 };        //Int waardes voor gewicht

            List<Dier> dierenlijst = new List<Dier>();      //Nieuwe lijst met dieren
            Dier dier;
            for (int i = 0; i <= HoeveelheidDieren - 1; i++)    //For loop om aantal dieren te maken, i = meegegeven parameter
            {
                dier = new Dier();
                Random random = new Random();
                int start1 = random.Next(0, Dieet.Length);      //Random getal tussen 0 en aantal dieet soorten
                int start2 = random.Next(0, Gewicht.Length);      //Random getal tussen 0 en aantal gewichten
                dier.dieet = Dieet[start1];     //Koppel getal aan positie van dieet in array
                dier.gewicht = Gewicht[start2];     //Koppel getal aan positie van gewicht in array
                dierenlijst.Add(dier);      //Voeg dier toe aan lijst
            }
            return dierenlijst;     //Geef de lijst met dieren terug
        }
    }
}
