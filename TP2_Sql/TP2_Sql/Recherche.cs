﻿using System;
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

        int PosExtX = 185;
        int PosExtY = 300;
        int PosIntX = 185;
        int PosIntY = 50;

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
                Properties.Settings.Default.CommandeSelect = "";
            }
            else if (RBTN_Nom.Checked)
            {
                if (TB_Nom.Text != "")
                {
                    BTN_Ok.Enabled = true;
                    Properties.Settings.Default.CommandeSelect = "where name like '%" + TB_Nom.Text + "%'";
                }
            }
            else if (RBTN_Dep.Checked)
            {
                BTN_Ok.Enabled = true;
                Properties.Settings.Default.CommandeSelect = "where departement = " + CB_Dep.Text;
            }

            LB_Text.Text = Properties.Settings.Default.CommandeSelect;
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
                TB_Nom.Location = new Point(PosExtX, PosExtY);
                CB_Dep.Location = new Point(PosExtX, PosExtY);
                TB_Nom.Text = "";
            }
            VerifierChoix();
        }

        private void RBTN_Nom_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTN_Nom.Checked)
            {
                LB_Text.Text = "Nom de l'Employé";
                TB_Nom.Location = new Point(PosIntX, PosIntY);
                CB_Dep.Location = new Point(PosExtX, PosExtY);
            }
            VerifierChoix();
        }

        private void RBTN_Dep_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTN_Dep.Checked)
            {
                LB_Text.Text = "Département";
                TB_Nom.Location = new Point(PosExtX, PosExtY);
                CB_Dep.Location = new Point(PosIntX, PosIntY);
                TB_Nom.Text = "";
                CB_Dep.SelectedIndex = 0;
            }
            VerifierChoix();
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