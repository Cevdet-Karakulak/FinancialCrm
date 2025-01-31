using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinancialCrm
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        FrmDashBoard frm=new FrmDashBoard();

        FinacialCrmDbEntities db = new FinacialCrmDbEntities();

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            using (var context = new FinacialCrmDbEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == name && x.Password == password);
                if (user != null)
                {
                    MessageBox.Show("Giriş onaylandı");
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Giriş Bilgileriniz Hatalı Lütfen Tekrar Deneyiniz");
                }
            }

        }              

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }     
    }
}