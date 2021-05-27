using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public class Bank
    {
        //Bank osztályon belül privát osztály.
        //Csak a bank osztály fogja elérni.
        private class Szamla
        {
            string nev;
            string szamlaszam;
            ulong egyenleg;

            public Szamla(string nev, string szamlaszam)
            {
                this.nev = nev;
                this.szamlaszam = szamlaszam;
                this.Egyenleg = 0;
            }

            public string Nev { get => nev; }
            public string Szamlaszam { get => szamlaszam;  }
            public ulong Egyenleg { get => egyenleg; set => egyenleg = value; }
        }
        List<Szamla> szamlak = new List<Szamla>();

        // Egy létező számlára pénzt helyez
        public void EgyenlegFeltolt(string szamlaszam, ulong osszeg)
        {
            Szamla szamla = SzamlaKeres(szamlaszam);
            szamla.Egyenleg += osszeg;
        }

        private Szamla SzamlaKeres(string szamlaszam)
        {
            foreach (Szamla item in szamlak)
            {
                if (item.Szamlaszam.Equals(szamlaszam))
                {
                    return item;
                }
            }
            throw new HibasSzamlaszamException(szamlaszam);
        }

        // Új számlát nyit a megadott névvel, számlaszámmal
        public void UjSzamla(string nev, string szamlaszam)
        {
            foreach (Szamla item in szamlak)
            {
                if (item.Szamlaszam.Equals(szamlaszam))
                {
                    throw new ArgumentException("A megadott számlaszámmal már létezik számla", "szamlaszam");
                }
            }
            Szamla szamla = new Szamla(nev, szamlaszam);
            szamlak.Add(szamla);
        }

        // Két számla között utal.
        // Ha nincs elég pénz a forrás számlán, akkor
        public bool Utal(string honnan, string hova, ulong osszeg)
        {
            throw new NotImplementedException();
        }

        // Lekérdezi az adott számlán lévő pénzösszeget
        public ulong Egyenleg(string szamlaszam)
        {
            throw new NotImplementedException();
        }
    }
}
    // Nem létező számla esetén dobhatjuk bármely függvényből
    class HibasSzamlaszamException : Exception
    {
        public HibasSzamlaszamException(string szamlaszam)
            : base("Hibas szamlaszam: " + szamlaszam)
        {
        }
    }

