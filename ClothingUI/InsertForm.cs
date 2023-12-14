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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }
        TypeBLL typeBLL = new TypeBLL();
        GoodsBLL goodsBLL = new GoodsBLL();
        public void SelectCombox()
        {
            List<TypeEntity> types= typeBLL.TypeSelect();
            TypeEntity typeEntity = new TypeEntity();
            typeEntity.TypeID = 0;
            typeEntity.TypeName = "--请选择--";
            types.Insert(0, typeEntity);
            comboBox1.DataSource = types;
            comboBox1.ValueMember = "TypeID";
            comboBox1.DisplayMember = "TypeName";
            
        }
        private void InsertForm_Load(object sender, EventArgs e)
        {
            SelectCombox();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectIdButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("请输入货号/条形码！");
                return;
            }
            string str = textBox1.Text;
            DataTable dt = goodsBLL.select(str);
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("该商品是一个全新的商品！");
                return;
            }
            else
            {
                textBox2.Text = dt.Rows[0]["GoodsName"].ToString();
                comboBox1.Text = dt.Rows[0]["TypeName"].ToString();
                textBox3.Text = dt.Rows[0]["StorePrice"].ToString();
                textBox4.Text = dt.Rows[0]["SalePrice"].ToString();
                textBox5.Text = dt.Rows[0]["Discount"].ToString();
            }
            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            DataTable dt = goodsBLL.select(str);
            GoodsEntity goodsEntity = new GoodsEntity();
            goodsEntity.BarCode = textBox1.Text;
            goodsEntity.GoodsName = textBox2.Text;
            if (textBox2.Text==""&& textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "" && comboBox1.Text == "--请选择--")
            {
                MessageBox.Show("请准确填写商品信息！");
                return;
            }
            try
            {
                goodsEntity.TypeID = int.Parse(comboBox1.SelectedValue.ToString());
                goodsEntity.StorePrice = double.Parse(textBox3.Text);
                goodsEntity.SalePrice = double.Parse(textBox4.Text);
                goodsEntity.Discount = double.Parse(textBox5.Text);
                goodsEntity.StockNum = int.Parse(textBox6.Text);
                goodsEntity.StockDate = DateTime.Now.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("请填入合法的商品信息！");
                return;
            }
            
            if (dt.Rows.Count == 0)//全新商品，添加
            {
                int no= goodsBLL.insertGooods(goodsEntity);
                if (no!=0)
                {
                    MessageBox.Show("入库成功!");
                }
                else
                {
                    MessageBox.Show("入库失败！");
                }
            }
            else//非全新商品，修改商品信息或添加产品数量
            {
                int no = goodsBLL.UpdateGooods(goodsEntity);
                if (no != 0)
                {
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }
    }
}
