using dao;
using metiers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace controller
{
    public class ProduitController
    {
      static  List<Produit> produits = new List<Produit>();

        public bool Add(Produit p) {

            ProduitDAO pr = new ProduitDAO();
            //produits = pr.FindAll();
            if (produits.Count() == 0)
            {
                produits = GetProduit();

            }

            if (produits.Contains(p))
                return false;

            pr.Add(p);

            return true;
        }

        public List<Produit> GetProduit()
        {
            ProduitDAO pr = new ProduitDAO();
            produits = pr.FindAll();

            return produits;
        }
        public bool ModifierProduit(Produit p)
        {

            ProduitDAO pr = new ProduitDAO();
            if (produits.Count() == 0)
            {
                produits = GetProduit();

            }
            if (produits.Contains(p))
                return false;

            return pr.Update(p);
        }
        public bool Remove(Produit p)
        {
            ProduitDAO bd = new ProduitDAO();
            if (produits.Count() == 0)
            {
                produits = GetProduit();

            }

            if (produits.Contains(p)==false)
                return false;

            // Check if produit dans un autre bon
            /*
            if (BonController.Find(p.Cin) != null)
                return false;
           */

            bd.Delete(p.Reference);
            produits.Remove(p);
            return true;
        }
        public  Produit Find(string refe)
        {
            ProduitDAO p=new ProduitDAO();
            return p.FindByReference(refe);

        }
    }
}
