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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        FinacialCrmDbEntities db = new FinacialCrmDbEntities();

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void bbtnNewCategory_Click(object sender, EventArgs e)
        {
            string title = txtCategoryName.Text;
           
            Categories category = new Categories();
            category.CategoryName = title;
            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Siteme Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sitemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            string name = txtCategoryName.Text;
            
            var values = db.Categories.Find(id);

            values.CategoryName = name;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values2 = db.Categories.ToList();
            dataGridView1.DataSource = values2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frn = new FrmBanks();
            frn.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling billing = new FrmBilling();
            billing.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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
            FrmDashBoard dashBoard = new FrmDashBoard();
            dashBoard.Show();
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
