using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClothingBLL;
using ClothingEntity;
using ClothingUI;

namespace ClothingUI
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }
        SalesManBLL manBLL=new SalesManBLL();
        SalesManEntity manEntity=new SalesManEntity();
        private void Log()
        {
            manEntity.Mobile = textBox1.Text;
            DataTable dt= manBLL.GetIdSelect(manEntity);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("此用户不存在！");
                return;
            }
            manEntity.SalesmanName = dt.Rows[0]["SalesmanName"].ToString();
            if (dt.Rows[0]["Pwd"].ToString()==textBox2.Text ) 
            {

                switch (dt.Rows[0]["Role"].ToString())
                {
                    case "店长":
                        MianMDI mianMDI = new MianMDI();
                        mianMDI.ID=textBox1.Text;
                        mianMDI.Show();
                        this.Hide();
                        break;
                    case "导购员":
                        MessageBox.Show("导购员不需要登录！");
                        break;
                    case "收银员":
                        cashierForm caForm=new cashierForm();
                        caForm.ID = textBox1.Text;
                        caForm.Show();
                        this.Hide();
                        break;
                    default:
                        MessageBox.Show("无职位，无法进入系统！");
                        break;
                }
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }
        private void Logbutton_Click(object sender, EventArgs e)
        {
            Log();
        }

        
    }
}
