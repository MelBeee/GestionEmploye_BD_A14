using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_Sql
{
    public partial class AjouterModifier : Form
    {
        public AjouterModifier()
        {
            InitializeComponent();
        }

        private void btn_Enregistrer_Click(object sender, EventArgs e)
        {
            string sqlcommande; 
            if(this.Text == "Modification")
            {
                sqlcommande =   "UPDATE employes SET" +
                                "Adresse = '"    + TB_Adresse.Text +
                                "', Echelon ="   + tb_Echelon.Text +
                                ", Salaire = "   + tb_Salaire.Text +
                                "WHERE empno = " + 
                                tb_NumEmp.Text + 
                                ";";
            }
            else
            {
                sqlcommande =   "INSERT INTO employes VALUES(" + tb_NumEmp.Text + ",'" 
                                + tb_Nom.Text     + "','" 
                                + tb_Prenom.Text  + "'," 
                                + tb_Salaire.Text + "," 
                                + tb_Echelon.Text + ",'" 
                                + TB_Adresse.Text + "','" 
                                + tb_Dep.Text     + "');";
            }

            Properties.Settings.Default.CommandeInsertUpdate = sqlcommande; 
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CommandeInsertUpdate = ""; 
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
            if (tb_Dep.Text     ==  "" &&
                tb_Echelon.Text ==  "" &&
                tb_Nom.Text     ==  "" &&
                tb_Prenom.Text  ==  "" &&
                tb_NumEmp.Text  ==  "" &&
                tb_Salaire.Text ==  "" &&
                TB_Adresse.Text ==  "")
            {
                btn_Enregistrer.Enabled = false;
            }
        }

        private void AjouterModifier_Load(object sender, EventArgs e)
        {
            if(this.Text == "Modification")
            {
                tb_Nom.Enabled = false;
                tb_NumEmp.Enabled = false;
                tb_Prenom.Enabled = false;
                tb_Dep.Enabled = false;
            }
            else
            {
                tb_Nom.Enabled = true;
                tb_NumEmp.Enabled = true;
                tb_Prenom.Enabled = true;
                tb_Dep.Enabled = true;
            }
        }


    }
}
