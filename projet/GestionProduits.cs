using controller;
using metiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dao;

namespace projet
{
    public partial class GestionProduits : Form
    {
        public GestionProduits()
        {
            InitializeComponent();
        }

        private void btnDao_Click(object sender, EventArgs e)
        {
            Produit pr = new Produit(txtReference.Text, txtDesignation.Text, Convert.ToInt32(txtQt.Text), Convert.ToDouble(txtPrix.Text));
            ProduitController p = new ProduitController();
            if (p.Add(pr))
            {
                MessageBox.Show("done");
                GestionProduits_Load(sender, e);

            }
            else
            {
                MessageBox.Show("exist");
            }
        }

        private void GestionProduits_Load(object sender, EventArgs e)
        {

            ProduitController controller = new ProduitController();
            dgvProduit.DataSource = controller.GetProduit().ToArray();
            dgvProduits.Rows.Clear();   
            foreach (Produit p in controller.GetProduit())
            {
                dgvProduits.Rows.Add(p.Reference,p.Designation,p.Quantite,p.PrixAchat);
            }



        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReference.Text))
            {
                MessageBox.Show("Veuillez chercher un produit à modifier !");
                return;
            }

           ProduitController controller = new ProduitController();
            Produit pr = new Produit(txtReference.Text, txtDesignation.Text, Convert.ToInt32(txtQt.Text), Convert.ToDouble(txtPrix.Text));

            bool modifie = controller.ModifierProduit(pr);

                if (modifie)
                {
                    MessageBox.Show("Produit modifié avec succès !");
                GestionProduits_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Aucun produit modifié.");
                }
            }

        private void btnSupp_Click(object sender, EventArgs e)
        {

            ProduitController controller = new ProduitController();
            // Produit pr = new Produit(txtReference.Text, txtDesignation.Text, Convert.ToInt32(txtQt.Text), Convert.ToDouble(txtPrix.Text));
            Produit pr = new Produit(txtReference.Text, "", 0, 0);


            bool remove = controller.Remove(pr);
            if (remove)
            {
                MessageBox.Show("Produit supprimer avec succès !");
                GestionProduits_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Aucun produit modifié.");
            }
        }

        private void btnchercher_Click(object sender, EventArgs e)
        {
            if (txtReference.Text != "")
            {
                List<Produit> services = new List<Produit>();
                ProduitController p=new ProduitController();
                Produit service = p.Find(txtReference.Text);
                if (service != null)
                {
                    services.Add(service);
                }
                dgvProduit.DataSource = services.ToArray();
                dgvProduits.Rows.Clear();
                foreach (Produit pr in services)
                {
                    dgvProduits.Rows.Add(pr.Reference, pr.Designation, pr.Quantite, pr.PrixAchat);
                }
            }
        }
    }
}
