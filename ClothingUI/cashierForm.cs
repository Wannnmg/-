using ClothingBLL;
using ClothingEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingUI
{
    public partial class cashierForm : Form
    {
        public cashierForm()
        {
            InitializeComponent();
        }
        public string ID { get; set; } 
        GoodsBLL goodsBLL= new GoodsBLL();
        SalesDetailBLL salesDetailBLL = new SalesDetailBLL();
        SalesBLL salesBLL=new SalesBLL();
        SalesManBLL salesMan=new SalesManBLL();
        private void cashierForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SalesManEntity salesManEntity = new SalesManEntity();
            salesManEntity.Mobile = ID;
            DataTable dtcashier = salesMan.GetIdSelect(salesManEntity);
            
            if (dtcashier.Rows[0]["Role"].ToString()=="店长")
            {
                
            }
            else
            {
                Application.Exit();
            }
        }
        public void BindData()
        {
            SalesManBLL salesManBLL=new SalesManBLL();
            DataTable dtshooping= salesManBLL.GetShoopingSelect();
            
            shopingComboBox.DataSource= dtshooping;
            shopingComboBox.ValueMember = "SalesmanID";
            shopingComboBox.DisplayMember = "SalesmanName";
            shopingComboBox.Text = "--请选择--";
            SalesManEntity salesManEntity=new SalesManEntity();
            salesManEntity.Mobile = ID;
            DataTable dtcashier= salesManBLL.GetIdSelect(salesManEntity);
            CashierLabel.Text = "收银员：" + dtcashier.Rows[0]["SalesmanName"].ToString();
            labelnum.Text=DateTime.Now.ToString("yyyMMddhhmmssfff");
        }
        public void insertBindData()
        {
            int count = 0;
            double sumMoney = 0;
            foreach (ListViewItem item in GoodslistView.Items)
            {
                count += int.Parse(item.SubItems[6].Text.ToString());
                sumMoney += int.Parse(item.SubItems[6].Text.ToString()) * double.Parse(item.SubItems[5].Text.ToString());
            }
            SumLabel.Text = "共：￥"+ sumMoney.ToString("F2") + "元";
            CountLabel.Text= "数量："+count.ToString();
            textBox2.Text = sumMoney.ToString("F2");
            try
            {
                textBox4.Text = (double.Parse(textBox3.Text) - double.Parse(sumMoney.ToString())).ToString("F2");
            }
            catch (Exception)
            {

                textBox3.Text = "0.00";
            }
            
            
        }
        private void cashierForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = e.KeyChar;
            if (key!=13)
            {
                return;
            }
            DataTable dt= goodsBLL.select(textBox1.Text);
            if (dt.Rows.Count!=0)
            {
                foreach (ListViewItem item in this.GoodslistView.Items)
                {
                    if (item.Text==textBox1.Text)
                    {
                        int count=int.Parse(item.SubItems[6].Text);
                        count++;
                        item.SubItems[6].Text=count.ToString();
                        insertBindData();
                        return;
                    }
                    
                }
                DataTable insertdtitems = goodsBLL.select(textBox1.Text);
                ListViewItem listViewItem = new ListViewItem(insertdtitems.Rows[0]["BarCode"].ToString());
                listViewItem.SubItems.Add(insertdtitems.Rows[0]["GoodsName"].ToString());
                listViewItem.SubItems.Add(insertdtitems.Rows[0]["TypeName"].ToString());
                listViewItem.SubItems.Add(insertdtitems.Rows[0]["SalePrice"].ToString());
                listViewItem.SubItems.Add(insertdtitems.Rows[0]["Discount"].ToString());
                double price = double.Parse(insertdtitems.Rows[0]["SalePrice"].ToString());
                double discount = double.Parse(insertdtitems.Rows[0]["Discount"].ToString());
                listViewItem.SubItems.Add((price*discount).ToString("F2"));
                listViewItem.SubItems.Add("1");
                GoodslistView.Items.Add(listViewItem);
                insertBindData();
            }
            else
            {
                MessageBox.Show("没有该商品！");
            }
        }

        

        private void GoodslistView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //+43 -45 backspace 8
            if (this.GoodslistView.Items.Count == 0)
            {
                return;
            }
            else
            {
                if (GoodslistView.SelectedItems.Count!=0)
                {
                    if (e.KeyChar == 43)
                    {
                        int subitemscount = int.Parse(GoodslistView.SelectedItems[0].SubItems[6].Text);
                        subitemscount++;
                        GoodslistView.SelectedItems[0].SubItems[6].Text = subitemscount.ToString();
                        insertBindData();
                    }
                    if (e.KeyChar == 45)
                    {
                        int subitemscount = int.Parse(GoodslistView.SelectedItems[0].SubItems[6].Text);
                        if (int.Parse(GoodslistView.SelectedItems[0].SubItems[6].Text) > 1)
                        {
                            subitemscount--;
                            GoodslistView.SelectedItems[0].SubItems[6].Text = subitemscount.ToString();
                            insertBindData();
                        }
                        else
                        {
                            MessageBox.Show("商品数量需2个以上！");
                        }

                    }
                    if (e.KeyChar == 8)
                    {
                        int subitemscount = int.Parse(GoodslistView.SelectedItems[0].SubItems[6].Text);
                        GoodslistView.Items.RemoveAt(GoodslistView.SelectedItems[0].Index);
                        insertBindData();
                    }
                }
                else
                {
                    return;
                }
            }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = e.KeyChar;
            if (key != 13)
            {
                return;
            }
            textBox4.Text = (double.Parse(textBox3.Text) - double.Parse(textBox2.Text)).ToString("F2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = (double.Parse(textBox3.Text) - double.Parse(textBox2.Text)).ToString("F2");
            if (this.shopingComboBox.Text=="--请选择--")
            {
                MessageBox.Show("请选择导购员！");
                return;
            }
            if (double.Parse(textBox4.Text)<0)
            {
                MessageBox.Show("实收金额应大于应收金额！");
                return;
            }

            //对库存进行删减操作
            foreach (ListViewItem item in this.GoodslistView.Items)
            {
                
               int no= goodsBLL.UpdateGooods(item.Text, int.Parse(item.SubItems[6].Text));
                if (no==0)
                {
                    DataTable dt = goodsBLL.select(item.Text);
                    MessageBox.Show(string.Format("库存不足！当前商品:{0},库存剩余量为:{1}", item.SubItems[1].Text, dt.Rows[0]["StockNum"].ToString()));
                    return;
                }
            }
            //添加销售记录
            SalesEntity salesEntity = new SalesEntity();
            salesEntity.ReceiptsCode = this.labelnum.Text;
            salesEntity.AllMoney = double.Parse(this.textBox2.Text);
            SalesManEntity salesManEntity = new SalesManEntity();
            salesManEntity.Mobile = ID;
            DataTable dtcashier = salesMan.GetIdSelect(salesManEntity);
            salesEntity.SalesmanID = int.Parse(this.shopingComboBox.SelectedValue.ToString()); 
            salesEntity.CashierID =int.Parse(dtcashier.Rows[0]["SalesmanID"].ToString());
            int salesno = salesBLL.insertSales(salesEntity);
            int SalesDetailno = 0;
            //添加详细销售记录
            foreach (ListViewItem item in this.GoodslistView.Items)
            {
                SalesDetailEntity salesDetail = new SalesDetailEntity();
                DataTable dtsales = salesBLL.SelectID(labelnum.Text);
                salesDetail.SalesID = int.Parse(dtsales.Rows[0]["SalesID"].ToString());
                DataTable dtsalesDetail = goodsBLL.select(item.SubItems[0].Text);
                salesDetail.GoodsID = int.Parse(dtsalesDetail.Rows[0]["GoodsID"].ToString());
                salesDetail.Quantity = int.Parse(item.SubItems[6].Text);
                salesDetail.GoodsMoney = int.Parse(item.SubItems[6].Text) * double.Parse(item.SubItems[5].Text);
                SalesDetailno=salesDetailBLL.insertSalesDetail(salesDetail);
            }
            

            if (SalesDetailno!=0&& SalesDetailno!=0)
            {
                MessageBox.Show("销售成功！");
                labelnum.Text = DateTime.Now.ToString("yyyMMddhhmmssfff");
                GoodslistView.Items.Clear();
                shopingComboBox.Text = "--请选择--";
                textBox1.Text = "";
                SumLabel.Text = "共：0元";
                CountLabel.Text = "数量：0";
                textBox2.Text = "0.00";
                textBox3.Text = "0.00";
                textBox4.Text = "0.00";
            }
            else
            {
                MessageBox.Show("销售失败！");
            }
        }
    }
}
