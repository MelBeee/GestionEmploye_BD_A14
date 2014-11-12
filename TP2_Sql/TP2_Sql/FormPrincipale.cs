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
    public partial class FormPrincipale : Form
    {
        public bool connection = false;
        private OracleConnection oraconn = new OracleConnection();

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
                BTN_Refresh.Enabled = false;
            }
            else
            {
                btn_Ajouter.Enabled = true;
                btn_Modifier.Enabled = true;
                btn_Rechercher.Enabled = true;
                btn_Supprimer.Enabled = true;
                TB_ModSup.Enabled = true;
                BTN_Refresh.Enabled = true;
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
            Recherche dlg = new Recherche();

            if(dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btn_Ajouter_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_Modifier_Click(object sender, EventArgs e)
        {

        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {

        }

        private void AjouterModifier()
        {
            AjouterModifier dlg = new AjouterModifier(); 

            if (TB_ModSup.Text == "")
            {

            }
            else
            {
                
            }

            dlg.Text = (TB_ModSup.Text == "" ? "Nouveau" : "Modification");
        }


        private void RemplirDataGridViewDepartement()
        {
            DGV_Departement.Rows.Clear();
            string sql = "select e.codedep, d.nomdepartement " + ", count(e.codedep) " + 
                         "from employes e " +
                         "inner join departements d on e.codedep = d.codedep " +
                         "group by e.codedep, d.nomdepartement " +
                         "order by e.codedep ";
            // code nomdep numemp

            

            //string sql = "select codedep, nomdepartement from departements"; 
            try
            {
                DGV_Departement.Rows.Clear();
                OracleCommand orcd = new OracleCommand(sql, oraconn);
                orcd.CommandType = CommandType.Text;
                OracleDataReader oraRead = orcd.ExecuteReader();

                //label11.Text = oraRead.GetDataTypeName(2);
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

        private void BTN_Refresh_Click(object sender, EventArgs e)
        {
            RemplirDataGridViewDepartement();
        }
    }
}
