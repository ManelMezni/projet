using dao;
using metiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller
{
    public class BonController
    {
        private static List<Bon> bons = new List<Bon>();

        public static List<Bon> GetBons()
        {
            bonDAO bd = new bonDAO();
            bons = bd.FindAll();
            return bons;
        }

        public static string GenererNumero()
        {
            bonDAO bd = new bonDAO();
            bons = bd.FindAll();
            int compteur = bons.Count + 1;

            string mois = DateTime.Now.Month.ToString().PadLeft(2, '0');  
            string annee = DateTime.Now.Year.ToString().Substring(2);//from index 2 to end 
            string numero = compteur.ToString().PadLeft(3, '0');          

            return "BS-" + mois + "-" + annee + "-" + numero;
        }


        public static bool AjouterBon(Bon b)
        {
            ProduitDAO produitDAO = new ProduitDAO();
            //ou b.produit
            Produit p = produitDAO.FindByReference(b.Produit.Reference);
            if (p == null)
                return false; 

            if (b.Type == "E") 
            {
                double newPrix = (p.PrixAchat * p.Quantite + b.Prix * b.Quantite)
                                 / (p.Quantite + b.Quantite);
                p.PrixAchat = newPrix;
                p.Quantite += b.Quantite;
            }
            else if (b.Type == "S")
            {
                if (b.Quantite > p.Quantite)
                    return false; 
                p.Quantite -= b.Quantite;
            }

            produitDAO.Update(p);

            bonDAO bd = new bonDAO();
            bd.Add(b);
            bons.Add(b); 

            return true;
        }


        public static List<Bon> GetBonSortie()
        {
            bonDAO bd = new bonDAO();
            bons = bd.FindAll();

            List<Bon> bonsSortie = new List<Bon>();
            foreach (Bon b in bons)
            {
                if (b.Type == "S")
                    bonsSortie.Add(b);
            }
            return bonsSortie;
        }


        public static List<Bon> GetBonEntree()
        {
            bonDAO bd = new bonDAO();
            bons = bd.FindAll();

            List<Bon> bonsEntree = new List<Bon>();
            foreach (Bon b in bons)
            {
                if (b.Type == "E")
                    bonsEntree.Add(b);
            }
            return bonsEntree;
        }
    }
}
