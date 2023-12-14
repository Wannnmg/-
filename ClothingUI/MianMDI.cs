using ClothingBLL;
using ClothingEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingUI
{
    public partial class MianMDI : Form
    {
        
        public MianMDI()
        {
            InitializeComponent();
        }
        public string ID { get; set; }
        SalesManBLL salesManBLL = new SalesManBLL();
        private void XianShi()
        {
            SalesManEntity salesManEntity = new SalesManEntity();
            salesManEntity.Mobile = ID;
            DataTable dt= salesManBLL.GetIdSelect(salesManEntity);
            string str = dt.Rows[0]["SalesmanName"].ToString();
            str+=string.Format("({0})", dt.Rows[0]["Role"].ToString());
            str += ",欢迎您!";
            Rolelabel.Text= str;
        }
        private void MianMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
            
        }

        private void MianMDI_Load(object sender, EventArgs e)
        {
            XianShi();
            timer1.Start();
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string str = "当前时间为：";
            str += DateTime.Now.ToString();
            Timelabel.Text = str;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            TypeForm typeForm = new TypeForm();
            typeForm.MdiParent = this;
            typeForm.Show();
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            StaffManagementForm staffManagementForm=new StaffManagementForm();
            staffManagementForm.MdiParent = this;
            staffManagementForm.Show();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CommodityForm commodityForm=new CommodityForm();
            commodityForm.MdiParent= this;
            commodityForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            InsertForm insertForm=new InsertForm();
            insertForm.MdiParent = this;
            insertForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cashierForm cashierForm = new cashierForm();
            cashierForm.ID= this.ID;
            cashierForm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WageFrom wageFrom=new   WageFrom();
            wageFrom.MdiParent=this;
            wageFrom.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SalesStatisticsForm salesStatisticsForm=new SalesStatisticsForm();
            salesStatisticsForm.MdiParent= this;
            salesStatisticsForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
