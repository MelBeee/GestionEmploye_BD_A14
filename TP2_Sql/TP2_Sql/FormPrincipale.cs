﻿using System;
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
    public partial class FormPrincipale : Form
    {
        public bool connection = false;
        private OracleConnection oraconn = new OracleConnection();
        private DataSet monDataSet = new DataSet();


        public FormPrincipale()
        {
            InitializeComponent();
        }

        void updateButton()
        {
            if (!connection)
            {
                btn_Ajouter.Enabled = false;
                btn_Modifier.Enabled = false;
                btn_Rechercher.Enabled = false;
                btn_Supprimer.Enabled = false;
                TB_ModSup.Enabled = false;
                BTN_Precedant.Enabled = false;
                BTN_Suivant.Enabled = false;
            }
            else
            {
                btn_Ajouter.Enabled = true;
                btn_Rechercher.Enabled = true;
                TB_ModSup.Enabled = true;
                BTN_Precedant.Enabled = true;
                BTN_Suivant.Enabled = true;
            }
        }

        private void FormPrincipale_Load(object sender, EventArgs e)
        {
            updateButton();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!connection)
            {
                Connexion form = new Connexion();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //Remplit le DSource
                    string Dsource = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                        "(HOST=205.237.244.251)(PORT=1521)))" +
                        "(CONNECT_DATA=(SERVICE_NAME=ORCL.clg.qc.ca)))";
                    string user = Properties.Settings.Default.User;
                    string passwd = Properties.Settings.Default.Passwd;

                    string chaineconnection = "Data Source = " + Dsource + ";User Id =" + user + "; Password =" + passwd;
                    pictureBox1.BackgroundImage = Properties.Resources.Connecter;
                    connection = true;
                    try
                    {
                        oraconn.ConnectionString = chaineconnection;
                        oraconn.Open();
                        LB_Connection.Text = oraconn.State.ToString();
                    }
                    catch (Exception ex)
                    {
                        LB_Connection.Text = ex.Message.ToString();
                        pictureBox1.BackgroundImage = Properties.Resources.Deconnecter;
                        connection = false;
                    }
                    RemplirDataGridViewDepartement();
                }
            }
            else
            {
                oraconn.Close();
                pictureBox1.BackgroundImage = Properties.Resources.Deconnecter;
                connection = false;
                LB_Connection.Text = oraconn.State.ToString();
                DGV_Departement.Rows.Clear();
            }
            updateButton();
        }

        private void FormPrincipale_FormClosing(object sender, FormClosingEventArgs e)
        {
            oraconn.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_Rechercher_Click(object sender, EventArgs e)
        {
            string sql = "select * from employes ";
            Recherche dlg = new Recherche();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sql += Properties.Settings.Default.CommandeSelect;
                LB_test.Text = sql.ToString();
                monDataSet.Clear();
                RemplirLabels(sql);
            }
        }

        public void RemplirLabels(string sql)
        {
            try
            {
                monDataSet.Clear();
                OracleDataAdapter dataAdapter = new OracleDataAdapter();
                OracleCommand commandeSql = new OracleCommand();
                dataAdapter.SelectCommand = new OracleCommand(sql, oraconn);
                monDataSet = new DataSet("Employes");
                dataAdapter.Fill(monDataSet, "Employes");
                if(this.BindingContext[monDataSet, "Employes"].Count > 0)
                {
                    GB_Employe.Text = "Employé (" + this.BindingContext[monDataSet, "Employes"].Count.ToString() + " résultats)";
                    InitLabels();                       
                }
                else
                {
                    MessageBox.Show("Erreur dans le remplissage des informations");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void InitLabels()
        {
            LB_Numemp.DataBindings.Add("Text", monDataSet, "Employes.Empno");
            LB_Nom.DataBindings.Add("Text", monDataSet, "Employes.Nom");
            LB_Prenom.DataBindings.Add("Text", monDataSet, "Employes.Prenom");
            LB_Adresse.DataBindings.Add("Text", monDataSet, "Employes.Adresse");
            LB_Echelon.DataBindings.Add("Text", monDataSet, "Employes.Echelon");
            LB_Dep.DataBindings.Add("Text", monDataSet, "Employes.CodeDep");
            LB_Salaire.DataBindings.Add("Text", monDataSet, "Employes.Salaire");
        }

        private void btn_Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter();
            RemplirDataGridViewDepartement();
            Properties.Settings.Default.empno = -1;
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            Modifier();
            RemplirDataGridViewDepartement();

        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            Supprimer();
            RemplirDataGridViewDepartement();
        }

        private bool EmpnoValide(string empno)
        {
            bool valide = false;
            string sql = "select empno from employes where empno = " + empno;
            OracleCommand orcd = new OracleCommand(sql, oraconn);
            orcd.CommandType = CommandType.Text;
            OracleDataReader oraRead = orcd.ExecuteReader();

            if (oraRead.Read())
            {
                valide = true;
            }
            else
            {
                MessageBox.Show("Numéro d'employé invalide");
            }
            oraRead.Close();
            return valide;
        }

        private void Ajouter()
        {
            AjouterModifier dlg = new AjouterModifier();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dlg.Text = "Nouveau";
                string sqlcommande = "INSERT INTO employes VALUES(" + Properties.Settings.Default.empno.ToString() + ",'"
                                 + Properties.Settings.Default.nom.ToString() + "','"
                                 + Properties.Settings.Default.prenom.ToString() + "',"
                                 + Properties.Settings.Default.salaire.ToString() + ","
                                 + Properties.Settings.Default.echelon.ToString() + ",'"
                                 + Properties.Settings.Default.Adresse.ToString() + "','"
                                 + Properties.Settings.Default.codedep.ToString() + "')";
                OracleCommand orcd = new OracleCommand(sqlcommande, oraconn);
                try
                {
                    orcd.CommandType = CommandType.Text;
                    orcd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Modifier()
        {
            AjouterModifier dlg = new AjouterModifier();
            if (EmpnoValide(TB_ModSup.Text))
            {
                Properties.Settings.Default.empno = Convert.ToInt32(TB_ModSup.Text);
                LoadData();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string sqlcommande = "UPDATE employes SET " +
                                        "Adresse = '" + Properties.Settings.Default.Adresse.ToString() +
                                        "', Echelon =" + Properties.Settings.Default.echelon.ToString() +
                                        ", Salaire = " + Properties.Settings.Default.salaire.ToString() +
                                        " WHERE empno = " + Properties.Settings.Default.empno.ToString();
                    OracleCommand orcd = new OracleCommand(sqlcommande, oraconn);
                    try
                    {
                        orcd.CommandType = CommandType.Text;
                        orcd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                Properties.Settings.Default.empno = -1;
                TB_ModSup.Text = "";
            }

            dlg.Text = "Modification";
        }

        void LoadData()
        {
            try
            {
                //Commande pour afficher un employe dans le form ajouter (dans les bonnes textbox)
                string loadSQL = "select empno, nom, prenom, salaire, echelon, adresse, codedep " +
                    "from employes where empno = " + Properties.Settings.Default.empno.ToString();  //-- properties.settings.default.Empno au lieu du 12
                OracleCommand orcd = new OracleCommand(loadSQL, oraconn);
                orcd.CommandType = CommandType.Text;
                OracleDataReader oraRead = orcd.ExecuteReader();

                oraRead.Read();

                Properties.Settings.Default.nom = oraRead.GetString(1);
                Properties.Settings.Default.prenom = oraRead.GetString(2);
                Properties.Settings.Default.salaire = oraRead.GetFloat(3);
                Properties.Settings.Default.echelon = oraRead.GetInt32(4);
                Properties.Settings.Default.Adresse = oraRead.GetString(5);
                Properties.Settings.Default.codedep = oraRead.GetString(6);
                oraRead.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Supprimer()
        {
            if (EmpnoValide(TB_ModSup.Text))
            {
                string sqlcommande = "delete from employes where empno = " + TB_ModSup.Text;
                OracleCommand orcd = new OracleCommand(sqlcommande, oraconn);
                try
                {
                    orcd.CommandType = CommandType.Text;
                    orcd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                TB_ModSup.Clear();
            }
        }

        private void RemplirDataGridViewDepartement()
        {
            DGV_Departement.Rows.Clear();
            string sql = "select d.codedep, d.nomdepartement " + ", count(e.codedep) " +
                         "from employes e " +
                         "right join departements d on e.codedep = d.codedep " +
                         "group by d.codedep, d.nomdepartement " +
                         "order by d.codedep ";

            try
            {
                DGV_Departement.Rows.Clear();
                OracleCommand orcd = new OracleCommand(sql, oraconn);
                orcd.CommandType = CommandType.Text;
                OracleDataReader oraRead = orcd.ExecuteReader();

                while (oraRead.Read())
                {
                    DGV_Departement.Rows.Add(
                    oraRead.GetString(0),
                    oraRead.GetString(1),
                    oraRead.GetInt32(2)
                    );
                }
                oraRead.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TB_ModSup_TextChanged(object sender, EventArgs e)
        {
            if (TB_ModSup.Text == "")
            {
                btn_Modifier.Enabled = false;
                btn_Supprimer.Enabled = false;
                btn_Ajouter.Enabled = true;
            }
            else
            {
                btn_Modifier.Enabled = true;
                btn_Supprimer.Enabled = true;
                btn_Ajouter.Enabled = false;
            }
        }

        private void BTN_Precedant_Click(object sender, EventArgs e)
        {
            this.BindingContext[monDataSet, "Employes"].Position -= 1;
        }

        private void BTN_Suivant_Click(object sender, EventArgs e)
        {
            this.BindingContext[monDataSet, "Employes"].Position += 1;
        }
    }
}
