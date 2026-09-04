
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metiers;
using System.Windows.Forms;


namespace dao
{
    public class ConnexionVente
    {
        //static String url = @"Server=DESKTOP-6MSILMJ\SQLEXPRESS;Database=BDCommerciale;Trusted_Connection=True";
       
        static string url = @"Server=DESKTOP-5DK0TQB\SQLEXPRESS;Database=BDCommerciale;Trusted_Connection=True";

        static SqlConnection cnx = new SqlConnection(url);
        public static SqlConnection GetInstance()
        {
            try
            {
                if (cnx != null && cnx.State == System.Data.ConnectionState.Closed)
                    cnx.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Vente: Pb de connexion\n " + ex.Message);
            }
            return cnx;
        }
        public static void Close()
        {
            if (cnx != null && cnx.State == System.Data.ConnectionState.Open)
            {
                cnx.Close();
            }
        }

    }
}
