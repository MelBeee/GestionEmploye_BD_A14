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
    public partial class Recherche : Form
    {
        public Recherche()
        {
            InitializeComponent();
        }
        private void Recherche_Load(object sender, EventArgs e)
        {
            VerifierChoix();
        }

        private void VerifierChoix()
        {
            BTN_Ok.Enabled = false;

            if (RBTN_Tout.Checked)
            {
                BTN_Ok.Enabled = true;
                Properties.Settings.Default.CommandeSelect = "select * from employes";
            }
            else if (RBTN_Nom.Checked)
            {
                if (TB_Nom.Text != "")
                {
                    BTN_Ok.Enabled = true;
                    Properties.Settings.Default.CommandeSelect = "select * from employes where nom like '" + TB_Nom.Text + "%'";
                }
            }
            else if (RBTN_Dep.Checked)
            {
                BTN_Ok.Enabled = true;
                Properties.Settings.Default.CommandeSelect = "select * from employes e inner join departements d on e.codedep = d.codedep where NomDepartement like '" + CB_Dep.Text + "'";
            }

        }

        private void BTN_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RBTN_Tout_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTN_Tout.Checked)
            {
                LB_Text.Text = "";
                TB_Nom.Visible = false; 
                CB_Dep.Visible = false; 
                TB_Nom.Text = "";
            }
            VerifierChoix();
        }

        private void RBTN_Nom_CheckedChanged(object sender, EventArgs e)
        {
            LB_Text.Text = "Nom de l'Employé";
            TB_Nom.Visible = true;
            CB_Dep.Visible = false; 
            VerifierChoix();
        }

        private void RBTN_Dep_CheckedChanged(object sender, EventArgs e)
        {
            LB_Text.Text = "Département";
            TB_Nom.Visible = false;
            CB_Dep.Visible = true; 
            TB_Nom.Text = "";
            VerifierChoix();
            CB_Dep.SelectedItem = 0; 
        }

        private void TB_Nom_TextChanged(object sender, EventArgs e)
        {
            VerifierChoix(); 
        }

        private void CB_Dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerifierChoix(); 
        }

        private void CB_Dep_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; 
        }

    }
}
