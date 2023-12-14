using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClothingBLL;
using ClothingEntity;

namespace ClothingUI
{
    public partial class CommodityForm : Form
    {
        public CommodityForm()
        {
            InitializeComponent();
        }
        GoodsBLL goodsBLL = new GoodsBLL();
        TypeBLL typeBLL = new TypeBLL();
        
        public void comboxClassSelect()
        {
            TypeEntity typeEntity = new TypeEntity();
            List<TypeEntity> type=typeBLL.TypeSelect();
            comboBox2.DataSource= type;
            typeEntity.TypeID = 0;
            typeEntity.TypeName = "--请选择--";
            type.Insert(0, typeEntity);
;            comboBox2.ValueMember = "TypeID";
            comboBox2.DisplayMember = "TypeName";
        }
        public void comboxTimeSelect()
        {
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker2.Enabled = false;
            comboBox1.SelectedText = "全部";
        }
        public void DataGridView()
        {
            
            DataTable  dt= goodsBLL.select(textBox1.Text,textBox2.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd")+" 00:00:00",dateTimePicker2.Value.ToString("yyyy-MM-dd")+" 23:59:59", comboBox2.Text,comboBox1.Text);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            int count=dt.Rows.Count;
            this.Count.Text = string.Format("当前一共查询到{0}条记录！", count);
        }
        private void CommodityForm_Load(object sender, EventArgs e)
        {
            comboxClassSelect();
            comboxTimeSelect();
            DataGridView();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("全部"))
            {
                this.dateTimePicker1.Enabled = false;
                this.dateTimePicker2.Enabled = false;
            }
            if (comboBox1.Text.Equals("本日"))
            {
                this.dateTimePicker1.Enabled = true;
                this.dateTimePicker2.Enabled = true;
                DateTime dateTime= DateTime.Now;
                dateTimePicker1.Value= dateTime;
                dateTimePicker2.Value=dateTime;
            }
            if (comboBox1.Text.Equals("本周"))
            {
                this.dateTimePicker1.Enabled = true;
                this.dateTimePicker2.Enabled = true;
                DateTime dateTime = DateTime.Now;
                int dayOfWeek = (int)dateTime.DayOfWeek;
                if (dayOfWeek==0)
                {
                    dayOfWeek = 7;
                }
                dateTimePicker1.Value = dateTime.AddDays(-dayOfWeek+1);
                dateTimePicker2.Value = dateTime.AddDays(7-dayOfWeek);
            }
            if (comboBox1.Text.Equals("本月"))
            {
                this.dateTimePicker1.Enabled = true;
                this.dateTimePicker2.Enabled = true;
                DateTime dateTime = DateTime.Now;
                int dayOfMon = (int)dateTime.Day;
                dateTimePicker1.Value = dateTime.AddDays(-dayOfMon + 1);
                dateTimePicker2.Value = dateTime.AddDays(-dayOfMon + 1).AddMonths(1).AddDays(-1);
            }
            if (comboBox1.Text.Equals("本年"))
            {
                this.dateTimePicker1.Enabled = true;
                this.dateTimePicker2.Enabled = true;
                DateTime dateTime = DateTime.Now;
                int dayOfYear = (int)dateTime.DayOfYear;
                dateTimePicker1.Value = dateTime.AddDays(-dayOfYear + 1);
                dateTimePicker2.Value = dateTime.AddDays(-dayOfYear + 1).AddYears(1).AddDays(-1);
            }
        }
    }
}
