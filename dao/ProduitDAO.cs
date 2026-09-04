using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metiers;

namespace dao
{
    public class ProduitDAO
    {
        SqlConnection cnx;
     
        public void Add(Produit p)
        {
            try
            {
                String reqSQL = "insert into tProduit values (@refe, @desig, @quantite, @prix)";
                cnx = ConnexionVente.GetInstance();
                SqlCommand cmd = new SqlCommand(reqSQL, cnx);

                cmd.Parameters.Add("@refe", p.Reference);
                cmd.Parameters.Add("@desig", p.Designation);
                cmd.Parameters.Add("@quantite", p.Quantite);
                cmd.Parameters.Add("@prix", p.PrixAchat);
                int nbr = cmd.ExecuteNonQuery();
                if (nbr != 0)
                {
                    MessageBox.Show("done");
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("L’erreur dans l’ajout" + ex.Message);

            }
            finally
            {
                cnx.Close();
            }

        }
        public  void Delete(String text)
        {
            try
            {

                cnx = ConnexionVente.GetInstance();

                string reqSQL = "DELETE FROM tProduit WHERE reference = @ref";

                SqlCommand cmd = new SqlCommand(reqSQL, cnx);
                cmd.Parameters.Add("@ref", text);

                int lignesAffectees = cmd.ExecuteNonQuery();

                if (lignesAffectees != 0)
                {
                    MessageBox.Show($"Produit {text} supprimé !");
                }
                else
                    MessageBox.Show("Aucun produit trouvé avec cette référence.");
             
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }
        public  List<Produit> FindAll()
        {

            List<Produit> lesProduits = new List<Produit>();

            try
            {
                cnx = ConnexionVente.GetInstance();

                SqlCommand cmd = new SqlCommand("select * from tProduit", cnx);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                  
                    Produit p = new Produit(dr.GetString(0), dr.GetString(1), dr.GetInt32(2), dr.GetFloat(3));
                    lesProduits.Add(p);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }

            return lesProduits;
        }

        public bool Update(Produit p)
        {
            try
            {
                cnx = ConnexionVente.GetInstance();

                string reqSQL = @"UPDATE tProduit SET designation = @des, 
                         quantite = @qte, prixAchat = @prix 
                         WHERE reference = @ref";
                SqlCommand cmd = new SqlCommand(reqSQL, cnx);
                cmd.Parameters.AddWithValue("@ref", p.Reference);
                cmd.Parameters.AddWithValue("@des", p.Designation);
                cmd.Parameters.AddWithValue("@qte", p.Quantite);
                cmd.Parameters.AddWithValue("@prix", p.PrixAchat);
                int lignes = cmd.ExecuteNonQuery();
                return lignes > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur Update: " + ex.Message);
                return false;
            }
            finally
            {
                cnx.Close();
            }
        }
        public Produit FindByReference(string reference)
        {
            Produit p = null;
            try
            {
                cnx = ConnexionVente.GetInstance();

                string req = "SELECT reference, designation, quantite, prixAchat FROM tProduit WHERE reference = @ref";

                SqlCommand cmd = new SqlCommand(req, cnx);
                cmd.Parameters.AddWithValue("@ref", reference);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    p = new Produit(dr.GetString(0), dr.GetString(1), dr.GetInt32(2), (double)dr.GetFloat(3));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }


            return p;
        }
    }

}

  

