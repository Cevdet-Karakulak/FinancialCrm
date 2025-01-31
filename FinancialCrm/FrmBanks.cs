using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinacialCrmDbEntities db=new FinacialCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
             var ziraatBankBalance=db.Banks.Where(x=>x.BankTitle== "Ziraat Bankası").Select(y=>y.BankBalance).FirstOrDefault();
             var VakıfbankBalance = db.Banks.Where(x=>x.BankTitle== "Vakıfbank").Select(y=>y.BankBalance).FirstOrDefault();
             var isBankasıBalance = db.Banks.Where(x=>x.BankTitle== "İş Bankası").Select(y=>y.BankBalance).FirstOrDefault();
            lblisbankBalance.Text=isBankasıBalance.ToString() + " ₺";
            lblVakifbankBalance.Text=VakıfbankBalance.ToString() + " ₺";
            lblZiraatbankBalance.Text=ziraatBankBalance.ToString() + " ₺";
                
            // Banka Hareketleri
            var bankProcess1=db.BankProceses.OrderByDescending(x=>x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = $"{bankProcess1.Description} {bankProcess1.Amount:C} {bankProcess1.ProcessDate:dd.MM.yyyy}";
            var bankProcess2 = db.BankProceses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = $"{bankProcess2.Description} {bankProcess2.Amount:C} {bankProcess2.ProcessDate:dd.MM.yyyy}";
            var bankProcess3 = db.BankProceses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = $"{bankProcess3.Description} {bankProcess3.Amount:C} {bankProcess3.ProcessDate:dd.MM.yyyy}";
            var bankProcess4 = db.BankProceses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = $"{bankProcess4.Description} {bankProcess4.Amount:C} {bankProcess4.ProcessDate:dd.MM.yyyy}";
            var bankProcess5 = db.BankProceses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = $"{bankProcess5.Description} {bankProcess5.Amount:C} {bankProcess5.ProcessDate:dd.MM.yyyy}";
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frn = new FrmBilling();
            frn.Show();
            this.Hide();
        }
    }
}
