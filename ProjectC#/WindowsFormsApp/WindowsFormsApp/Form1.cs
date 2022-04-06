using ConsoleApp.Domain;
using ConsoleApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Service service;
        SqlDataAdapter dataAdapterDonor = new SqlDataAdapter();
        private int idCurrentCharityCase;
        private int idCurrentDonor;
        public Form1(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void charityCaseBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.charityCaseBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.charityCaseSQLDatabaseDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'charityCaseSQLDatabaseDataSet.donor' table. You can move, or remove it, as needed.
            this.donorTableAdapter.Fill(this.charityCaseSQLDatabaseDataSet.donor);
            // TODO: This line of code loads data into the 'charityCaseSQLDatabaseDataSet.charityCase' table. You can move, or remove it, as needed.
            this.charityCaseTableAdapter.Fill(this.charityCaseSQLDatabaseDataSet.charityCase);
            
        }

        private void charityCaseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNameCC.Text != "")
            {
                service.addCharityCase(textBoxNameCC.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idCurrentCharityCase != 0)
            {
                service.deleteCharityCase(idCurrentCharityCase);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBoxNameD.Text!="" && textBoxAdressD.Text != "" && textBoxPhoneD.Text != "" && textBoxDonatedMoney.Text != "")
            {
                int sum = Convert.ToInt32(textBoxDonatedMoney.Text);
                service.addDonation(idCurrentCharityCase, textBoxNameD.Text, textBoxPhoneD.Text, textBoxAdressD.Text, sum);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idCurrentDonor != 0)
            {
                service.deleteDonation(idCurrentCharityCase, idCurrentDonor);
            }
        }

        private void charityCaseDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (charityCaseDataGridView.CurrentRow.Index != -1)
            {
                int idCharityCase = Convert.ToInt32(charityCaseDataGridView.CurrentRow.Cells[0].Value);
                idCurrentCharityCase = idCharityCase;
                textBoxNameCC.Text = charityCaseDataGridView.CurrentRow.Cells[2].Value.ToString();
                CharityCase charityCase = service.GetCharityCase(idCharityCase);
                List<Donor> donors = charityCase.getDonors();

                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Name of Donor");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Address");
                dt.Columns.Add("Donated Money");
                foreach (var oItem in donors)
                {
                    dt.Rows.Add(new object[] {oItem.getId(), oItem.getName(),oItem.getPhone(), oItem.getAddress(),oItem.getDonated_sum()});
                }
                donorDataGridView.DataSource = dt;

            }
        }

        private void donorDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (donorDataGridView.CurrentRow.Index != -1)
            {
                    int idDonor = Convert.ToInt32(donorDataGridView.CurrentRow.Cells[0].Value);
                    idCurrentDonor = idDonor;
                    textBoxNameD.Text = donorDataGridView.CurrentRow.Cells[1].Value.ToString();
                    textBoxPhoneD.Text = donorDataGridView.CurrentRow.Cells[2].Value.ToString();
                    textBoxAdressD.Text = donorDataGridView.CurrentRow.Cells[3].Value.ToString();
                    textBoxDonatedMoney.Text = donorDataGridView.CurrentRow.Cells[4].Value.ToString();
            }
            
        }
    }
}
