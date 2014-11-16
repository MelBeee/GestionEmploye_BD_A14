using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TP2_Sql
{
    // jlgkyffuliho;`jo;
    public partial class AjouterModifier : Form
    {

        public AjouterModifier()
        {
            InitializeComponent();
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            SetData();
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CommandeInsertUpdate = "";
            this.Close();
        }

        private void tb_NumEmp_TextChanged(object sender, EventArgs e)
        {
            OkEnable();
        }

        private void tb_Nom_TextChanged(object sender, EventArgs e)
        {
            OkEnable();
        }

        private void tb_Prenom_TextChanged(object sender, EventArgs e)
        {
            OkEnable();
        }

        private void tb_Salaire_TextChanged(object sender, EventArgs e)
        {
            OkEnable();
        }

        private void tb_Echelon_TextChanged(object sender, EventArgs e)
        {
            OkEnable();
        }

        private void tb_Dep_TextChanged(object sender, EventArgs e)
        {
            OkEnable();
        }

        private void TB_Adresse_TextChanged(object sender, EventArgs e)
        {
            OkEnable();
        }

        private void OkEnable()
        {
            btn_Enregistrer.Enabled = !(tb_Dep.Text == "" ||
                tb_Echelon.Text == "" ||
                tb_Nom.Text == "" ||
                tb_Prenom.Text == "" ||
                tb_NumEmp.Text == "" ||
                tb_Salaire.Text == "" ||
                TB_Adresse.Text == "");
        }

        void LoadData()
        {
            tb_NumEmp.Text = Properties.Settings.Default.empno.ToString();
            tb_Nom.Text = Properties.Settings.Default.nom.ToString();
            tb_Prenom.Text = Properties.Settings.Default.prenom.ToString();
            tb_Salaire.Text = Properties.Settings.Default.salaire.ToString();
            tb_Echelon.Text = Properties.Settings.Default.echelon.ToString();
            TB_Adresse.Text = Properties.Settings.Default.Adresse.ToString();
            tb_Dep.Text = Properties.Settings.Default.codedep.ToString();
        }

        void SetData()
        {
            Properties.Settings.Default.empno = Convert.ToInt32(tb_NumEmp.Text);
            Properties.Settings.Default.nom = tb_Nom.Text;
            Properties.Settings.Default.prenom = tb_Prenom.Text;
            Properties.Settings.Default.salaire = float.Parse(tb_Salaire.Text);
            Properties.Settings.Default.echelon = Convert.ToInt32(tb_Echelon.Text);
            Properties.Settings.Default.Adresse = TB_Adresse.Text;
            Properties.Settings.Default.codedep = tb_Dep.Text;
        }

        private void AjouterModifier_Load(object sender, EventArgs e)
        {
            //toolTip1.SetToolTip(this.button1, "My button1");
            TP_Dep.SetToolTip(this.tb_Dep, "Entrez un code dep existant !");
            TP_Echelon.SetToolTip(this.tb_Echelon, "Entrez un nombre positif !");
            TP_NumEmp.SetToolTip(this.tb_NumEmp, "Entrez un numero non existant !");
            TP_Salaire.SetToolTip(this.tb_Salaire, "Entre 25000 et 100000 !");
            if (Properties.Settings.Default.empno != -1) //Modif
            {
                tb_Nom.Enabled = false;
                tb_NumEmp.Enabled = false;
                tb_Prenom.Enabled = false;
                tb_Dep.Enabled = false;
                this.Text = "Modification";
                LoadData();
            }
            else //new
            {
                tb_Nom.Enabled = true;
                tb_NumEmp.Enabled = true;
                tb_Prenom.Enabled = true;
                tb_Dep.Enabled = true;
                this.Text = "Ajouter";
            }
            OkEnable();
        }

        private void TB_Adresse_TextChanged_1(object sender, EventArgs e)
        {
            OkEnable();
        }
    }
}
