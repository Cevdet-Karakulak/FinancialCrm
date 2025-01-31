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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinacialCrmDbEntities db = new FinacialCrmDbEntities();       

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            string username = txtuserName.Text;
            string password = txtPassword.Text;

            int id = int.Parse(txtId.Text);

            var users = db.Users.Where(x => x.UserId == id && x.UserName == username && x.Password == password);

            var values = db.Users.Find(id);
            values.UserName = username;
            values.Password = password;
            values.UserId = id;
            db.Users.AddOrUpdate(values);
            db.SaveChanges();

            MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Sistemde Güncellendi!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks f = new FrmBanks();
            f.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling b = new FrmBilling();
            b.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txtuserName.Text;
            var password = txtPassword.Text;

            Users login = new Users();
            login.UserName = userName;
            login.Password = password;
            db.Users.Add(login);
            db.SaveChanges();

            MessageBox.Show("Yeni Kullanıcı Başarı ile Oluşturuldu", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGiderler_Click(object sender, EventArgs e)
        {
            FrmSpendings spendings = new FrmSpendings();
            spendings.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashBoard frm = new FrmDashBoard();
            frm.Show();
            this.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankMovements movements = new FrmBankMovements();
            movements.Show();
            this.Hide();
        }
    }
}
