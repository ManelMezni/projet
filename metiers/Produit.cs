using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metiers
{
    public class Produit
    {
        private string reference;
        private string designation;
        private int quantite;
        private double prixAchat;

        public string Reference { get => reference; set => reference = value; }
        public string Designation { get => designation; set => designation = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public double PrixAchat { get => prixAchat; set => prixAchat = value; }

        public Produit(string reference, string designation, int quantite, double prixAchat)
        {
            Reference = reference;
            Designation = designation;
            Quantite = quantite;
            PrixAchat = prixAchat;
        }

        public Produit() { }

        public override bool Equals(object obj)
        {
            return obj is Produit produit &&
                   reference == produit.reference;
        }

        public override string ToString()
        {
            return reference + " " + designation;
        }
    }
}
