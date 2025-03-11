using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    internal class ArticleManagment
    {
        private List<Article> articles;
        private string connectionString;
        private int id;
        

        public ArticleManagment()
        {
            this.connectionString = "Data Source=PC404-24;Initial Catalog=TP2;Integrated Security=True";
           

            
        }
        public List<Article> listeArticles()
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("SELECT * FROM Articles1", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                articles = new List<Article>();
                while (reader.Read())
                {
                    articles.Add(new Article
                    (
                       (int)reader["ID"],
                        reader["Code"].ToString(),
                        reader["Name"].ToString(),
                        reader["Description"].ToString(),
                        reader["Brand"].ToString(),
                        reader["Category"].ToString(),
                        (decimal)reader["Price"],
                        reader["image"].ToString()
                    ));
                }
            }
            return articles;
        }
        public List<Article> listeArticlesInvalides()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM Articles1 WHERE image IS NULL", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                articles = new List<Article>();
                while (reader.Read())
                {
                    articles.Add(new Article
                    (
                       (int)reader["ID"],
                        reader["Code"].ToString(),
                        reader["Name"].ToString(),
                        reader["Description"].ToString(),
                        reader["Brand"].ToString(),
                        reader["Category"].ToString(),
                        (decimal)reader["Price"],
                        reader["image"].ToString()
                    ));
                }
            }
            return articles;
        }
        public List<Article> articlesFiltre(string mot)
        {
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM Articles1 WHERE Name LIKE '%' + @mot + '%' OR Code LIKE '%' + @mot + '%' OR Category LIKE '%' + @mot + '%'", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@mot", mot);
                SqlDataReader reader = cmd.ExecuteReader();
                
                articles = new List<Article>();
                while (reader.Read())
                {
                    articles.Add(new Article
                    (
                       (int)reader["ID"],
                        reader["Code"].ToString(),
                        reader["Name"].ToString(),
                        reader["Description"].ToString(),
                        reader["Brand"].ToString(),
                        reader["Category"].ToString(),
                        (decimal)reader["Price"],
                        reader["image"].ToString()
                    ));
                }
            }
            return articles;
        }
        public Article getArticle(int id)
        {
            Article article = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Articles1 WHERE ID = @ID", conn); 
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                     article = new Article
                    (
                       (int)reader["ID"],
                        reader["Code"].ToString(),
                        reader["Name"].ToString(),
                        reader["Description"].ToString(),
                        reader["Brand"].ToString(),
                        reader["Category"].ToString(),
                        (decimal)reader["Price"],
                        reader["image"].ToString()
                    );
                    
                }
                return article;
            }
            
        }
        public void add(Article article)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Articles1 (Code,Name,Description,Brand,Category,Price) VALUES (@Code,@Name,@Description,@Brand,@Category,@Price)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Code", article.Code);
                    cmd.Parameters.AddWithValue("@Name", article.Name);
                    cmd.Parameters.AddWithValue("@Description", article.Description);
                    cmd.Parameters.AddWithValue("@Brand", article.Brand);
                    cmd.Parameters.AddWithValue("@Category", article.Category);
                    cmd.Parameters.AddWithValue("@Price", article.Price);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insertion reussie");
                }
            }
            catch (Exception ex) { 
                MessageBox.Show("Erreur lors de l'insertion");
                Console.WriteLine(ex.ToString());
            }
        }
            public void update(Article article)
        {
            if (article != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Articles1 SET Code =  @Code ,Name=@Name, Description=@Description, Brand=@Brand, Category=@Category, Price=@Price WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Code", article.Code);
                    cmd.Parameters.AddWithValue("@Name", article.Name);
                    cmd.Parameters.AddWithValue("@Description", article.Description);
                    cmd.Parameters.AddWithValue("@Brand", article.Brand);
                    cmd.Parameters.AddWithValue("@Category", article.Category);
                    cmd.Parameters.AddWithValue("@Price", article.Price);
                    cmd.Parameters.AddWithValue("@ID", article.Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update reussie");
                }
            }

        }
        public void delete(int id)
        {
            if (id > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE Articles1 WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Suppression reussie");
                }
            }

        }
        
    } 
}