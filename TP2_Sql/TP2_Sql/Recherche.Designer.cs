namespace TP2_Sql
{
    partial class Recherche
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RBTN_Tout = new System.Windows.Forms.RadioButton();
            this.RBTN_Nom = new System.Windows.Forms.RadioButton();
            this.RBTN_Dep = new System.Windows.Forms.RadioButton();
            this.BTN_Ok = new System.Windows.Forms.Button();
            this.BTN_Annuler = new System.Windows.Forms.Button();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.LB_Text = new System.Windows.Forms.Label();
            this.CB_Dep = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // RBTN_Tout
            // 
            this.RBTN_Tout.AutoSize = true;
            this.RBTN_Tout.Location = new System.Drawing.Point(12, 11);
            this.RBTN_Tout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RBTN_Tout.Name = "RBTN_Tout";
            this.RBTN_Tout.Size = new System.Drawing.Size(147, 21);
            this.RBTN_Tout.TabIndex = 0;
            this.RBTN_Tout.TabStop = true;
            this.RBTN_Tout.Text = "Tous les employés";
            this.RBTN_Tout.UseVisualStyleBackColor = true;
            this.RBTN_Tout.CheckedChanged += new System.EventHandler(this.RBTN_Tout_CheckedChanged);
            // 
            // RBTN_Nom
            // 
            this.RBTN_Nom.AutoSize = true;
            this.RBTN_Nom.Location = new System.Drawing.Point(12, 37);
            this.RBTN_Nom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RBTN_Nom.Name = "RBTN_Nom";
            this.RBTN_Nom.Size = new System.Drawing.Size(127, 21);
            this.RBTN_Nom.TabIndex = 1;
            this.RBTN_Nom.TabStop = true;
            this.RBTN_Nom.Text = "Nom d\'Employé";
            this.RBTN_Nom.UseVisualStyleBackColor = true;
            this.RBTN_Nom.CheckedChanged += new System.EventHandler(this.RBTN_Nom_CheckedChanged);
            // 
            // RBTN_Dep
            // 
            this.RBTN_Dep.AutoSize = true;
            this.RBTN_Dep.Location = new System.Drawing.Point(12, 64);
            this.RBTN_Dep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RBTN_Dep.Name = "RBTN_Dep";
            this.RBTN_Dep.Size = new System.Drawing.Size(111, 21);
            this.RBTN_Dep.TabIndex = 2;
            this.RBTN_Dep.TabStop = true;
            this.RBTN_Dep.Text = "Département";
            this.RBTN_Dep.UseVisualStyleBackColor = true;
            this.RBTN_Dep.CheckedChanged += new System.EventHandler(this.RBTN_Dep_CheckedChanged);
            // 
            // BTN_Ok
            // 
            this.BTN_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_Ok.Location = new System.Drawing.Point(328, 14);
            this.BTN_Ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Ok.Name = "BTN_Ok";
            this.BTN_Ok.Size = new System.Drawing.Size(75, 34);
            this.BTN_Ok.TabIndex = 4;
            this.BTN_Ok.Text = "Ok";
            this.BTN_Ok.UseVisualStyleBackColor = true;
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Annuler.Location = new System.Drawing.Point(328, 54);
            this.BTN_Annuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 34);
            this.BTN_Annuler.TabIndex = 5;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            this.BTN_Annuler.Click += new System.EventHandler(this.BTN_Annuler_Click);
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(185, 44);
            this.TB_Nom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(121, 22);
            this.TB_Nom.TabIndex = 6;
            this.TB_Nom.TextChanged += new System.EventHandler(this.TB_Nom_TextChanged);
            // 
            // LB_Text
            // 
            this.LB_Text.AutoSize = true;
            this.LB_Text.Location = new System.Drawing.Point(184, 26);
            this.LB_Text.Name = "LB_Text";
            this.LB_Text.Size = new System.Drawing.Size(46, 17);
            this.LB_Text.TabIndex = 7;
            this.LB_Text.Text = "label2";
            // 
            // CB_Dep
            // 
            this.CB_Dep.FormattingEnabled = true;
            this.CB_Dep.Items.AddRange(new object[] {
            "Ressources Humaines",
            "Marketing",
            "Informatique",
            "Administration",
            "Comptabilité"});
            this.CB_Dep.Location = new System.Drawing.Point(185, 44);
            this.CB_Dep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Dep.Name = "CB_Dep";
            this.CB_Dep.Size = new System.Drawing.Size(121, 24);
            this.CB_Dep.TabIndex = 8;
            this.CB_Dep.SelectedIndexChanged += new System.EventHandler(this.CB_Dep_SelectedIndexChanged);
            this.CB_Dep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_Dep_KeyPress);
            // 
            // Recherche
            // 
            this.AcceptButton = this.BTN_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(237)))), ((int)(((byte)(137)))));
            this.CancelButton = this.BTN_Annuler;
            this.ClientSize = new System.Drawing.Size(419, 102);
            this.Controls.Add(this.CB_Dep);
            this.Controls.Add(this.LB_Text);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.BTN_Ok);
            this.Controls.Add(this.RBTN_Dep);
            this.Controls.Add(this.RBTN_Nom);
            this.Controls.Add(this.RBTN_Tout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Recherche";
            this.Text = "Rechercher";
            this.Load += new System.EventHandler(this.Recherche_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RBTN_Tout;
        private System.Windows.Forms.RadioButton RBTN_Nom;
        private System.Windows.Forms.RadioButton RBTN_Dep;
        private System.Windows.Forms.Button BTN_Ok;
        private System.Windows.Forms.Button BTN_Annuler;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.Label LB_Text;
        private System.Windows.Forms.ComboBox CB_Dep;
    }
}