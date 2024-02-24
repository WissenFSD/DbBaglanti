using System.Collections;
using System.Data.SqlClient;

namespace DbBaglanti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=.;initial catalog=AdventureWorks2019;integrated security=true");
            SqlCommand cmd = new SqlCommand("select ProductId, Name from Production.Product", con);
            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();
            List<Product> productList = new List<Product>();
            while (dr.Read())
            {
                productList.Add(new Product()
                {

                    Id = (int)dr["ProductId"],
                    Name = dr["Name"].ToString(),
                });

            }

            dr.Close();
            con.Close();

            comboBox1.DataSource = productList;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ürün detaylarýný bu aþama da getireceðiz

            if (comboBox1.SelectedValue != null)
            {
                if (comboBox1.SelectedValue is Product)
                {

                }
                else
                {
                    int id = (int)comboBox1.SelectedValue;
                    SqlConnection con = new SqlConnection("data source=.;initial catalog=AdventureWorks2019;integrated security=true");
                    SqlCommand cmd = new SqlCommand("select Name,Color,ListPrice,SafetyStockLevel from Production.Product where ProductId=" + id.ToString(), con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtColor.Text = dr["Color"].ToString();
                        txtName.Text = dr["Name"].ToString();
                        txtPrice.Text = dr["ListPrice"].ToString();
                        txtStock.Text = dr["SafetyStockLevel"].ToString();
                    }
                    dr.Close();
                    con.Close();
                }

            }

        }
    }
}