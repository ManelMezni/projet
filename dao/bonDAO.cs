using metiers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dao
{
    public class bonDAO
    {
        private SqlConnection cnx;

        public bonDAO()
        {
            cnx = ConnexionVente.GetInstance();
        }

        public void Add(Bon b)
        {
         
            try
            {
                cnx = ConnexionVente.GetInstance();
                string req = "INSERT INTO tBon VALUES(@num,@date,@type,@qte,@prix,@ref)";

                SqlCommand cmd = new SqlCommand(req, cnx);

                cmd.Parameters.AddWithValue("@num", b.Numero);
                cmd.Parameters.AddWithValue("@date", b.DateBon);
                cmd.Parameters.AddWithValue("@type", b.Type);
                cmd.Parameters.AddWithValue("@qte", b.Quantite);
                cmd.Parameters.AddWithValue("@prix", b.Prix);
                cmd.Parameters.AddWithValue("@ref", b.Produit.Reference);

                int n = cmd.ExecuteNonQuery();
                if (n != 0)
                    MessageBox.Show("Service ajouté avec succès", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Requete recherche Service \n " + ex.Message, "Attention");
            }
            finally
            {
                cnx.Close();
            }
        }

        public List<Bon> FindAll()
        {
            List<Bon> liste = new List<Bon>();
            
            try
            {
                ProduitDAO bdprod = new ProduitDAO();
                List<Produit> produits = bdprod.FindAll();
                Produit p = null;
                cnx = ConnexionVente.GetInstance();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tBon", cnx);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    foreach (Produit prod in produits)
                        if (prod.Reference.Equals(dr.GetString(5)))
                        {
                            p = prod;
                            break;
                        }
                    Bon b = new Bon(dr.GetString(0), dr.GetDateTime(1), dr.GetString(2), dr.GetInt32(3), dr.GetFloat(4), p);

                    liste.Add(b);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service : Pb de FindAll \n " + ex.Message, "Attention");
            }
            finally
            {
                cnx.Close();
            }

            return liste;
        }
    }
}
