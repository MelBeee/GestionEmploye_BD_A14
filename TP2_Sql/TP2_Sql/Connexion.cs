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
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void btn_Connexion_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.User = tb_Username.Text;
            Properties.Settings.Default.Passwd = tb_Password.Text;
            Properties.Settings.Default.Save();
        }

        private void Connexion_Load(object sender, EventArgs e)
        {
            tb_Username.Text = Properties.Settings.Default.User;
            tb_Password.Text = Properties.Settings.Default.Passwd;
        }

    }
}
