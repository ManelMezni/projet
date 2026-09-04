using controller;
using metiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet
{
    public partial class GestionBon : Form
    {
        public GestionBon()
        {
            InitializeComponent();
        }



        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Produit pr = (Produit)cbproduits.SelectedItem;
            String type="";
            if (rbEntree.Checked)
                type = "E";
            else if (rbSortie.Checked)
                type = "S";
            Bon s = new Bon(txtNum.Text,dtpNaissance.Value, type,  int.Parse(txtQT.Text) ,double.Parse(txtPrix.Text) , pr);
            if (BonController.AjouterBon(s))
            {
                MessageBox.Show("bon ajouté");
                GestionProduit_Load(sender, e);
                viderchamps();
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private void viderchamps()
        {
            txtPrix.Text = "";

        }

        private void GestionProduit_Load(object sender, EventArgs e)
        {
            ProduitController p =new ProduitController();
            txtNum.Text = BonController.GenererNumero();
            txtNum.Enabled = false;
            cbproduits.DataSource = p.GetProduit().ToArray();
            dgvBon.DataSource=BonController.GetBons().ToArray();


        }

        private void button1_Click(object sender, EventArgs e)
        {
           txtNum.Text= BonController.GenererNumero();
        }
    }

}

