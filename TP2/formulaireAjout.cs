using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class formulaireAjout : Form
    {
        private ArticleManagment articleManagment;
        private int selectID;
        private DataGridView datagrid;
        private int position;
        Form1 form;
        public formulaireAjout()
        {
            InitializeComponent();
            form = new Form1();
            articleManagment = new ArticleManagment();
            button1.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            
            
        }
        public formulaireAjout(int selectID, DataGridView dataGridView1, int position)
        {
            InitializeComponent();
            form = new Form1();
            articleManagment = new ArticleManagment();
            this.selectID = selectID;
            this.position = position;
            this.datagrid = dataGridView1;
            remplirLesChamps();
            button3.Enabled = false;

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
               

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            string name = textBox2.Text;
            string description = textBox3.Text;
            string brand = textBox4.Text;
            string category = textBox5.Text;
            decimal price = Decimal.Parse(textBox6.Text);
            articleManagment.add(new Article(1, code, name, description, brand, category, price,null));
            viderLesChamps();
            
            
            
        }
        private void viderLesChamps() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void remplirLesChamps()
        {
            
           
            Article a = articleManagment.getArticle(selectID);

            textBox1.Text = a.Code;
            textBox2.Text = a.Name;
            textBox3.Text = a.Description;
            textBox4.Text = a.Brand;
            textBox5.Text = a.Category;
            textBox6.Text = a.Price.ToString();
            form.afficheImage(a.Image, pictureBox1);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            string name = textBox2.Text;
            string description = textBox3.Text;
            string brand = textBox4.Text;
            string category = textBox5.Text;
            decimal price = Decimal.Parse(textBox6.Text);
            int id = Convert.ToInt32(datagrid.Rows[position].Cells["ID"].Value.ToString());
            articleManagment.update(new Article(id, code, name, description, brand, category, price,null));
            this.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(datagrid.Rows[position].Cells["ID"].Value.ToString());
            articleManagment.delete(id);
            viderLesChamps();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button avancer
            position++;
            if (position >= datagrid.RowCount)
            {
                position--;
            }

            if (position > 0)
            {
                var row = datagrid.Rows[position];
                textBox1.Text = row.Cells["Code"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Description"].Value.ToString();
                textBox4.Text = row.Cells["Brand"].Value.ToString();
                textBox5.Text = row.Cells["Category"].Value.ToString();
                textBox6.Text = row.Cells["Price"].Value.ToString();
                form.afficheImage(row.Cells["Image"].Value.ToString(), pictureBox1);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button reculer
            position--;
            if (position >= 0)
            {
                var row = datagrid.Rows[position];
                textBox1.Text = row.Cells["Code"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Description"].Value.ToString();
                textBox4.Text = row.Cells["Brand"].Value.ToString();
                textBox5.Text = row.Cells["Category"].Value.ToString();
                textBox6.Text = row.Cells["Price"].Value.ToString();
                form.afficheImage(row.Cells["Image"].Value.ToString(), pictureBox1);
            }
            else
            {
                position++;
            }
        }
    }
}
