using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metiers
{
    public class Bon
    {
        public string Numero { get; set; }
        public DateTime DateBon { get; set; }
        public string Type { get; set; } // "E" or "S"
        public int Quantite { get; set; }
        public double Prix { get; set; }

        public Produit Produit { get; set; }

        public Bon() { }

        public Bon(string num, DateTime date, string type,
                   int qte, double prix, Produit p)
        {
            Numero = num;
            DateBon = date;
            Type = type;
            Quantite = qte;
            Prix = prix;
            Produit = p;
        }
    }
}
