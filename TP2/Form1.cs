using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP2
{
    public partial class Form1 : Form
        
    {
        
        private ArticleManagment articlemanagment;
        private int IDselected;
        private int position;
       
        public Form1()
        {
            InitializeComponent();
            articlemanagment = new ArticleManagment();
            IDselected = -1;
            position = 0;
            chargerLesDonnees();

        }
        
        public int selectedId
        { 
            get { return IDselected; } 
            set { IDselected = value; }
        }
        public void chargerLesDonnees()
        {
            if(articlemanagment.getArticle(1) != null)
            {
                Article a = articlemanagment.getArticle(1);

                label1.Text = a.Code;
                label2.Text = a.Name;
                label3.Text = a.Description;
                label4.Text = a.Brand;
                label5.Text = a.Category;
                label6.Text = a.Price.ToString();
                string img = a.Image.ToString();
                afficheImage(a.Image, pictureBox1);

            }
            dataGridView1.DataSource = articlemanagment.listeArticles();

        }
        public void afficheImage(string imageString, PictureBox pictB)
        {
            if (imageString.Contains("apple"))
            {
                pictB.Image = Properties.Resources.apple_logo;
            }
            else if (imageString.Contains("linux"))
            {
                pictB.Image = Properties.Resources.linux_logo;
            }
            else if (imageString.Contains("windows"))
            {
                pictB.Image = Properties.Resources.windows_logo;
            }
            else
            {
                pictB.Image = null;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            chargerLesDonnees();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formulaireAjout f = new formulaireAjout();
            f.Show();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                IDselected = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                position = dataGridView1.SelectedRows[0].Index;
                formulaireAjout f = new formulaireAjout(IDselected,dataGridView1,position);
                f.Show();
            }
            catch
            {
                MessageBox.Show("Veuillez selectionner un article");
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            position = e.RowIndex;
            if (position >= 0)
            {
                var row = dataGridView1.Rows[position];
                label1.Text = row.Cells["Code"].Value.ToString();
                label2.Text = row.Cells["Name"].Value.ToString();
                label3.Text = row.Cells["Description"].Value.ToString();
                label4.Text = row.Cells["Brand"].Value.ToString();
                label5.Text = row.Cells["Category"].Value.ToString();
                label6.Text = row.Cells["Price"].Value.ToString();
                afficheImage(row.Cells["Image"].Value.ToString(), pictureBox1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
            IDselected = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
            articlemanagment.delete(IDselected);
            chargerLesDonnees();
            }
            catch
            {
                MessageBox.Show("Veuillez selectionner un article");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            position++;
            if (position >= dataGridView1.RowCount) {
                position--;
            }
            
            if (position>0 )
            {
                var row = dataGridView1.Rows[position];
                label1.Text = row.Cells["Code"].Value.ToString();
                label2.Text = row.Cells["Name"].Value.ToString();
                label3.Text = row.Cells["Description"].Value.ToString();
                label4.Text = row.Cells["Brand"].Value.ToString();
                label5.Text = row.Cells["Category"].Value.ToString();
                label6.Text = row.Cells["Price"].Value.ToString();
                afficheImage(row.Cells["Image"].Value.ToString(), pictureBox1);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            position--;
            if (position >= 0)
            {
                var row = dataGridView1.Rows[position];
                label1.Text = row.Cells["Code"].Value.ToString();
                label2.Text = row.Cells["Name"].Value.ToString();
                label3.Text = row.Cells["Description"].Value.ToString();
                label4.Text = row.Cells["Brand"].Value.ToString();
                label5.Text = row.Cells["Category"].Value.ToString();
                label6.Text = row.Cells["Price"].Value.ToString();
                afficheImage(row.Cells["Image"].Value.ToString(), pictureBox1);
            }
            else
            {
                position++;
            }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string mot = textBox1.Text;
            if (mot.Length > 0) { 
                dataGridView1.DataSource = articlemanagment.articlesFiltre(mot);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = articlemanagment.listeArticlesInvalides();
            
        }
    }
}
