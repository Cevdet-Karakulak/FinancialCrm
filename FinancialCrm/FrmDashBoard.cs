using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }
        FinacialCrmDbEntities db=new FinacialCrmDbEntities();
        int count = 0;

        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            var totalBalance=db.Banks.Sum(x=>x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " ₺";

            var lastBankProcessAmount=db.BankProceses.OrderByDescending(x=>x.BankProcessId).Take(1).Select(y=>y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + " ₺";

            //Chart1 Kodlar
           var bankData=db.Banks.Select(x=>new
           {
               x.BankTitle,
               x.BankBalance,

           }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach(var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }
            //Chart1 Kodlar
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount,

            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType=System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Renko;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count%4==1)
            {
                var elektrikFaturasi=db.Bills.Where(x=>x.BillTitle== "Elektrik Faturası").Select(y=>y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBiillAmount.Text=elektrikFaturasi.ToString() + " ₺";
            }
            if (count % 4 == 2)
            {
                var dogalgazFaturasi = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBiillAmount.Text = dogalgazFaturasi.ToString() + " ₺";
            }
            if (count % 4 == 3)
            {
                var suFaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBiillAmount.Text = suFaturasi.ToString() + " ₺";
            }
            if (count % 4 == 0)
            {
                var internetFaturasi = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "İnternet Faturası";
                lblBiillAmount.Text = internetFaturasi.ToString() + " ₺";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void btnBillForm_Click(object sender, EventArgs e)
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
