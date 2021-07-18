
namespace Program_Facturat
{
    partial class Catalog_produse
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.catalogprodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDataSet = new Program_Facturat.masterDataSet();
            this.catalog_prodTableAdapter = new Program_Facturat.masterDataSetTableAdapters.catalog_prodTableAdapter();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denumireDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.umDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretftvaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valtvaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sterge = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogprodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.denumireDataGridViewTextBoxColumn,
            this.umDataGridViewTextBoxColumn,
            this.pretftvaDataGridViewTextBoxColumn,
            this.valtvaDataGridViewTextBoxColumn,
            this.sterge});
            this.dataGridView1.DataSource = this.catalogprodBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(5, 32);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(671, 417);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(601, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Denumire *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "UM *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pret fara TVA *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Valoare TVA(%) *";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5",
            "9",
            "19",
            "0"});
            this.comboBox1.Location = new System.Drawing.Point(542, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(44, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(367, 7);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // catalogprodBindingSource
            // 
            this.catalogprodBindingSource.DataMember = "catalog_prod";
            this.catalogprodBindingSource.DataSource = this.masterDataSet;
            // 
            // masterDataSet
            // 
            this.masterDataSet.DataSetName = "masterDataSet";
            this.masterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // catalog_prodTableAdapter
            // 
            this.catalog_prodTableAdapter.ClearBeforeFill = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // denumireDataGridViewTextBoxColumn
            // 
            this.denumireDataGridViewTextBoxColumn.DataPropertyName = "denumire";
            this.denumireDataGridViewTextBoxColumn.HeaderText = "Denumire";
            this.denumireDataGridViewTextBoxColumn.Name = "denumireDataGridViewTextBoxColumn";
            this.denumireDataGridViewTextBoxColumn.ReadOnly = true;
            this.denumireDataGridViewTextBoxColumn.Width = 200;
            // 
            // umDataGridViewTextBoxColumn
            // 
            this.umDataGridViewTextBoxColumn.DataPropertyName = "um";
            this.umDataGridViewTextBoxColumn.HeaderText = "UM";
            this.umDataGridViewTextBoxColumn.Name = "umDataGridViewTextBoxColumn";
            this.umDataGridViewTextBoxColumn.ReadOnly = true;
            this.umDataGridViewTextBoxColumn.Width = 70;
            // 
            // pretftvaDataGridViewTextBoxColumn
            // 
            this.pretftvaDataGridViewTextBoxColumn.DataPropertyName = "pret_f_tva";
            this.pretftvaDataGridViewTextBoxColumn.HeaderText = "Pret fara TVA";
            this.pretftvaDataGridViewTextBoxColumn.Name = "pretftvaDataGridViewTextBoxColumn";
            this.pretftvaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valtvaDataGridViewTextBoxColumn
            // 
            this.valtvaDataGridViewTextBoxColumn.DataPropertyName = "val_tva";
            this.valtvaDataGridViewTextBoxColumn.HeaderText = "Valoare TVA (%)";
            this.valtvaDataGridViewTextBoxColumn.Name = "valtvaDataGridViewTextBoxColumn";
            this.valtvaDataGridViewTextBoxColumn.ReadOnly = true;
            this.valtvaDataGridViewTextBoxColumn.Width = 110;
            // 
            // sterge
            // 
            this.sterge.DataPropertyName = "sterge";
            this.sterge.HeaderText = "";
            this.sterge.Name = "sterge";
            this.sterge.ReadOnly = true;
            this.sterge.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sterge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Catalog_produse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Catalog_produse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalog produse";
            this.Load += new System.EventHandler(this.Catalog_produse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogprodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private masterDataSet masterDataSet;
        private System.Windows.Forms.BindingSource catalogprodBindingSource;
        private masterDataSetTableAdapters.catalog_prodTableAdapter catalog_prodTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn denumireDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn umDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretftvaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valtvaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn sterge;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}