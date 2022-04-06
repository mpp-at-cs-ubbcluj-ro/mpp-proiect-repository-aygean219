
namespace WindowsFormsApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.charityCaseSQLDatabaseDataSet = new WindowsFormsApp.charityCaseSQLDatabaseDataSet();
            this.charityCaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.charityCaseTableAdapter = new WindowsFormsApp.charityCaseSQLDatabaseDataSetTableAdapters.charityCaseTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp.charityCaseSQLDatabaseDataSetTableAdapters.TableAdapterManager();
            this.donorTableAdapter = new WindowsFormsApp.charityCaseSQLDatabaseDataSetTableAdapters.donorTableAdapter();
            this.charityCaseDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNameCC = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.donorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donorDataGridView = new System.Windows.Forms.DataGridView();
            this.textBoxNameD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPhoneD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAdressD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDonatedMoney = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.charityCaseSQLDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityCaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityCaseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.MinimumSize = new System.Drawing.Size(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME !";
            // 
            // charityCaseSQLDatabaseDataSet
            // 
            this.charityCaseSQLDatabaseDataSet.DataSetName = "charityCaseSQLDatabaseDataSet";
            this.charityCaseSQLDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // charityCaseBindingSource
            // 
            this.charityCaseBindingSource.DataMember = "charityCase";
            this.charityCaseBindingSource.DataSource = this.charityCaseSQLDatabaseDataSet;
            // 
            // charityCaseTableAdapter
            // 
            this.charityCaseTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.charityCaseTableAdapter = this.charityCaseTableAdapter;
            this.tableAdapterManager.donationTableAdapter = null;
            this.tableAdapterManager.donorTableAdapter = this.donorTableAdapter;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp.charityCaseSQLDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.userrTableAdapter = null;
            // 
            // donorTableAdapter
            // 
            this.donorTableAdapter.ClearBeforeFill = true;
            // 
            // charityCaseDataGridView
            // 
            this.charityCaseDataGridView.AutoGenerateColumns = false;
            this.charityCaseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.charityCaseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.charityCaseDataGridView.DataSource = this.charityCaseBindingSource;
            this.charityCaseDataGridView.Location = new System.Drawing.Point(455, 9);
            this.charityCaseDataGridView.Name = "charityCaseDataGridView";
            this.charityCaseDataGridView.RowHeadersWidth = 51;
            this.charityCaseDataGridView.RowTemplate.Height = 24;
            this.charityCaseDataGridView.Size = new System.Drawing.Size(642, 268);
            this.charityCaseDataGridView.TabIndex = 2;
            this.charityCaseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.charityCaseDataGridView_CellContentClick);
            this.charityCaseDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.charityCaseDataGridView_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "totalSum";
            this.dataGridViewTextBoxColumn2.HeaderText = "Total Donated Money";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name of Charity Case";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // textBoxNameCC
            // 
            this.textBoxNameCC.Location = new System.Drawing.Point(235, 78);
            this.textBoxNameCC.Name = "textBoxNameCC";
            this.textBoxNameCC.Size = new System.Drawing.Size(142, 22);
            this.textBoxNameCC.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add a Charity Case";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete a Charitu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // donorBindingSource
            // 
            this.donorBindingSource.DataMember = "donor";
            this.donorBindingSource.DataSource = this.charityCaseSQLDatabaseDataSet;
            // 
            // donorDataGridView
            // 
            this.donorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.donorDataGridView.Location = new System.Drawing.Point(378, 283);
            this.donorDataGridView.Name = "donorDataGridView";
            this.donorDataGridView.RowHeadersWidth = 51;
            this.donorDataGridView.RowTemplate.Height = 24;
            this.donorDataGridView.Size = new System.Drawing.Size(881, 265);
            this.donorDataGridView.TabIndex = 8;
            this.donorDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.donorDataGridView_CellMouseDoubleClick);
            // 
            // textBoxNameD
            // 
            this.textBoxNameD.Location = new System.Drawing.Point(87, 303);
            this.textBoxNameD.Name = "textBoxNameD";
            this.textBoxNameD.Size = new System.Drawing.Size(211, 22);
            this.textBoxNameD.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // textBoxPhoneD
            // 
            this.textBoxPhoneD.Location = new System.Drawing.Point(87, 346);
            this.textBoxPhoneD.Name = "textBoxPhoneD";
            this.textBoxPhoneD.Size = new System.Drawing.Size(211, 22);
            this.textBoxPhoneD.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Phone";
            // 
            // textBoxAdressD
            // 
            this.textBoxAdressD.Location = new System.Drawing.Point(87, 390);
            this.textBoxAdressD.Name = "textBoxAdressD";
            this.textBoxAdressD.Size = new System.Drawing.Size(211, 22);
            this.textBoxAdressD.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Address";
            // 
            // textBoxDonatedMoney
            // 
            this.textBoxDonatedMoney.Location = new System.Drawing.Point(106, 432);
            this.textBoxDonatedMoney.Name = "textBoxDonatedMoney";
            this.textBoxDonatedMoney.Size = new System.Drawing.Size(192, 22);
            this.textBoxDonatedMoney.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Donated Money";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(62, 515);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Delete Donor";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(62, 486);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Add Donor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1757, 599);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxDonatedMoney);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAdressD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPhoneD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNameD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.donorDataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNameCC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.charityCaseDataGridView);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.charityCaseSQLDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityCaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityCaseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private charityCaseSQLDatabaseDataSet charityCaseSQLDatabaseDataSet;
        private System.Windows.Forms.BindingSource charityCaseBindingSource;
        private charityCaseSQLDatabaseDataSetTableAdapters.charityCaseTableAdapter charityCaseTableAdapter;
        private charityCaseSQLDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView charityCaseDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox textBoxNameCC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private charityCaseSQLDatabaseDataSetTableAdapters.donorTableAdapter donorTableAdapter;
        private System.Windows.Forms.BindingSource donorBindingSource;
        private System.Windows.Forms.DataGridView donorDataGridView;
        private System.Windows.Forms.TextBox textBoxNameD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPhoneD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAdressD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDonatedMoney;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

