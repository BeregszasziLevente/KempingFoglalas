using System;
using System.Collections.Generic;
using System.Text;

namespace KempingFoglalas
{
    public class Foglalas
    {
        public string VendegNev;
        public string ParcellaTipus;
        public int EjszakakSzama;
        public int FelnottFo;
        public int GyerekFo;

        public Foglalas(string sor)
        {
            string[] darabolt = sor.Split(';');
            VendegNev = darabolt[0];
            ParcellaTipus = darabolt[1];
            EjszakakSzama = int.Parse(darabolt[2]);
            FelnottFo = int.Parse(darabolt[3]);
            GyerekFo = int.Parse(darabolt[4]);
        }

        public double FizetendoOsszeg()
        {
            int alapdij = 6000*EjszakakSzama;
            int szemelyiDij = 500 * FelnottFo * EjszakakSzama + 1500 * GyerekFo * EjszakakSzama;

            if (ParcellaTipus=="KOMFORT")
            {
                alapdij = 9500*EjszakakSzama;
            }

            if (EjszakakSzama>=5)
            {
                return Math.Round((alapdij + szemelyiDij) * 0.9, 0);
            }

            return (alapdij + szemelyiDij);

        }

        public override string ToString()
        {
            return $"{VendegNev}({ParcellaTipus}): {EjszakakSzama} éjszaka, {FelnottFo} felnőtt, {GyerekFo} gyerek - Fizetendő: {FizetendoOsszeg():f0} Ft";
        }
    }
}
