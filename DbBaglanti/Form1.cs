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
            SqlCommand cmd = new SqlCommand("select Name from Production.Product", con);
            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {

                comboBox1.Items.Add(dr["Name"]);

            }
            dr.Close();
            con.Close();
        }
    }
}