namespace EsDnevnik
{
    partial class Ocene
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Menjaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Dodaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime_i_prezime = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Ocena = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Predmet = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Obrisi,
            this.Menjaj,
            this.Dodaj,
            this.Id,
            this.Datum,
            this.Ime_i_prezime,
            this.Ocena,
            this.Predmet});
            this.dataGridView1.Location = new System.Drawing.Point(55, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1213, 475);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Obrisi
            // 
            this.Obrisi.HeaderText = "Obrisi";
            this.Obrisi.MinimumWidth = 6;
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.Text = "Obrisi";
            this.Obrisi.UseColumnTextForButtonValue = true;
            this.Obrisi.Width = 125;
            // 
            // Menjaj
            // 
            this.Menjaj.HeaderText = "Menjaj";
            this.Menjaj.MinimumWidth = 6;
            this.Menjaj.Name = "Menjaj";
            this.Menjaj.Text = "Menjaj";
            this.Menjaj.UseColumnTextForButtonValue = true;
            this.Menjaj.Width = 125;
            // 
            // Dodaj
            // 
            this.Dodaj.HeaderText = "Dodaj";
            this.Dodaj.MinimumWidth = 6;
            this.Dodaj.Name = "Dodaj";
            this.Dodaj.Text = "Dodaj";
            this.Dodaj.UseColumnTextForButtonValue = true;
            this.Dodaj.Width = 125;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Width = 125;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.MinimumWidth = 6;
            this.Datum.Name = "Datum";
            this.Datum.Width = 125;
            // 
            // Ime_i_prezime
            // 
            this.Ime_i_prezime.HeaderText = "Ucenik";
            this.Ime_i_prezime.MinimumWidth = 6;
            this.Ime_i_prezime.Name = "Ime_i_prezime";
            this.Ime_i_prezime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ime_i_prezime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ime_i_prezime.Width = 125;
            // 
            // Ocena
            // 
            this.Ocena.HeaderText = "Ocena";
            this.Ocena.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.Ocena.MinimumWidth = 6;
            this.Ocena.Name = "Ocena";
            this.Ocena.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ocena.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ocena.Width = 125;
            // 
            // Predmet
            // 
            this.Predmet.HeaderText = "Predmet";
            this.Predmet.MinimumWidth = 6;
            this.Predmet.Name = "Predmet";
            this.Predmet.Width = 125;
            // 
            // Ocene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 567);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Ocene";
            this.Text = "Ocene";
            this.Load += new System.EventHandler(this.Ocene_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
        private System.Windows.Forms.DataGridViewButtonColumn Menjaj;
        private System.Windows.Forms.DataGridViewButtonColumn Dodaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ime_i_prezime;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ocena;
        private System.Windows.Forms.DataGridViewComboBoxColumn Predmet;
    }
}