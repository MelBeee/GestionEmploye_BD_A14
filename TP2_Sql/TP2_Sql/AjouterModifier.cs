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
            string sqlcommande;
            if (Properties.Settings.Default.empno != -1)
            {
                sqlcommande = "UPDATE employes SET" +
                                "Adresse = '" + TB_Adresse.Text +
                                "', Echelon =" + tb_Echelon.Text +
                                ", Salaire = " + tb_Salaire.Text +
                                "WHERE empno = " +
                                tb_NumEmp.Text +
                                ";";
            }
            else
            {
                sqlcommande = "INSERT INTO employes VALUES(" + tb_NumEmp.Text + ",'"
                                + tb_Nom.Text + "','"
                                + tb_Prenom.Text + "',"
                                + tb_Salaire.Text + ","
                                + tb_Echelon.Text + ",'"
                                + TB_Adresse.Text + "','"
                                + tb_Dep.Text + "');";
            }
            try
            {
                OracleCommand orcd = new OracleCommand(sqlcommande, conect);
                orcd.CommandType = CommandType.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Properties.Settings.Default.CommandeInsertUpdate = sqlcommande;
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
            if (tb_Dep.Text == "" &&
                tb_Echelon.Text == "" &&
                tb_Nom.Text == "" &&
                tb_Prenom.Text == "" &&
                tb_NumEmp.Text == "" &&
                tb_Salaire.Text == "" &&
                TB_Adresse.Text == "")
            {
                btn_Enregistrer.Enabled = false;
            }
        }

        void LoadData()
        {
            try
            {
                //Commande pour afficher un employe dans le form ajouter (dans les bonnes textbox)
                string loadSQL = "select empno, nom, prenom, salaire, echelon, adresse, codedep " +
                    "from employes where empno = " + Properties.Settings.Default.empno.ToString();  //-- properties.settings.default.Empno au lieu du 12
                OracleCommand orcd = new OracleCommand(loadSQL, conect);
                orcd.CommandType = CommandType.Text;
                OracleDataReader oraRead = orcd.ExecuteReader();

                if (oraRead.Read())
                {
                    tb_NumEmp.Text = Properties.Settings.Default.empno.ToString();
                    tb_Nom.Text = oraRead.GetString(1);
                    tb_Prenom.Text = oraRead.GetString(2);
                }
                else
                {
                    MessageBox.Show("Numéro d'employé invalide");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AjouterModifier_Load(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.empno != -1) //Modif
            {
                tb_Nom.Enabled = false;
                tb_NumEmp.Enabled = false;
                tb_Prenom.Enabled = false;
                tb_Dep.Enabled = false;
                LoadData();
            }
            else //new
            {
                tb_Nom.Enabled = true;
                tb_NumEmp.Enabled = true;
                tb_Prenom.Enabled = true;
                tb_Dep.Enabled = true;
            }
        }


    }
}
