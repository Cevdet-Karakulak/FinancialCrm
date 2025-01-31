using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinacialCrmDbEntities db=new FinacialCrmDbEntities();
        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var toplambakiye = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = toplambakiye.ToString();

            var toplamGider = db.Spendings.Sum(y => y.SpendingAmount);
            lblTotalGider.Text = toplamGider.ToString();

            var values = (from spending in db.Spendings
                          join category in db.Categories
                         on spending.CategoryId equals category.CategoryId
                          select new
                          {
                              spending.SpendingId,
                              spending.SpendingAmount,
                              spending.SpendingDate,
                              spending.SpendingTitle,
                              categoryName = category.CategoryName

                          }).ToList();

            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks banks = new FrmBanks();
            banks.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling billing = new FrmBilling();
            billing.Show();
            this.Hide();
        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmSpendings spendings = new FrmSpendings();
            spendings.Show();
            this.Hide();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = (from spending in db.Spendings
                          join category in db.Categories
                      on spending.CategoryId equals category.CategoryId
                          select new
                          {
                              spending.SpendingId,
                              spending.SpendingAmount,
                              spending.SpendingDate,
                              spending.SpendingTitle,
                              categoryName = category.CategoryName

                          }).ToList();

            dataGridView1.DataSource = values;
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            int categoryName = int.Parse(txtCategory.Text);
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);

            Spendings spending = new Spendings();
            spending.SpendingDate = DateTime.Now;
            spending.SpendingTitle = title;
            spending.SpendingAmount = amount;
            spending.CategoryId = categoryName;
            db.Spendings.Add(spending);
            db.SaveChanges();
            MessageBox.Show("Harcama başarıyla eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbtnBillDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.Spendings.Find(id);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Harcama başarıyla silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            int categoryName = int.Parse(txtCategory.Text);
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);

            Spendings spending = new Spendings();
            spending.SpendingDate = date;
            spending.SpendingTitle = title;
            spending.SpendingAmount = amount;
            spending.CategoryId = categoryName;
            db.Spendings.Add(spending);
            db.SaveChanges();

            MessageBox.Show("Harcama başarıyla güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

