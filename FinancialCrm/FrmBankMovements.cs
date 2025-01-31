using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBankMovements : Form
    {
        public FrmBankMovements()
        {
            InitializeComponent();
        }
        FinacialCrmDbEntities db = new FinacialCrmDbEntities();


        private void FrmBankMovements_Load(object sender, EventArgs e)
        {
            var toplambakiye = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = toplambakiye.ToString();                      
            


        var values = db.BankProceses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.BankProceses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            string processType = txtProcessType.Text;
            int bankName = int.Parse(txtBankName.Text);

            BankProceses bnkp = new BankProceses();
            bnkp.Description = description;
            bnkp.Amount = amount;
            bnkp.ProcessDate = date;
            bnkp.ProcessType = processType;
            bnkp.BankId = bankName;
            db.BankProceses.Add(bnkp);
            db.SaveChanges();
            MessageBox.Show("Banka işlemi başarıyla eklendi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProceses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;

        }

        private void bbtnBillDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = db.BankProceses.Find(id);
            db.BankProceses.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Banka işlemi başarıyla silindi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProceses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            string processType = txtProcessType.Text;
            int bankName = int.Parse(txtBankName.Text);
            int id = int.Parse(txtId.Text);

            var value = db.BankProceses.Find(id);

            value.Description = description;
            value.Amount = amount;
            value.ProcessType = processType;
            value.ProcessDate = date;
            value.BankId = bankName;
            db.BankProceses.AddOrUpdate(value);
            db.SaveChanges();

            MessageBox.Show("Banka işlemi başarıyla güncellendi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.BankProceses.Select(x => new
            {
                x.BankProcessId,
                x.Description,
                x.ProcessDate,
                x.ProcessType,
                x.Amount,
                x.Banks.BankTitle
            }).ToList();
            dataGridView1.DataSource = values;
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {            
         FrmCategory category = new FrmCategory();
         category.Show();
         this.Hide();            
        }

        private void btnBanksForm_Click_1(object sender, EventArgs e)
        {
            FrmBanks banks = new FrmBanks();
            banks.Show();
            this.Hide();
        }

        private void btnBills_Click_1(object sender, EventArgs e)
        {
            FrmBilling billing = new FrmBilling();
            billing.Show();
            this.Hide();
        }

        private void btnGiderler_Click_1(object sender, EventArgs e)
        {
            FrmSpendings spendings = new FrmSpendings();
            spendings.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankMovements movements = new FrmBankMovements();
            movements.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashBoard dashboard = new FrmDashBoard();
            dashboard.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
