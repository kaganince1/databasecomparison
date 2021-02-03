using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace VeriTabProjeDeneme
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DataTable dt = new DataTable();
            string MyConnectionString = "datasource = localhost;database=veritabdeneme; port = 3306; username = root; password = 123456";
            string query = "SELECT * FROM veritabdeneme.deneme3";
            MySqlConnection con = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            SqlConnection connec = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
            SqlCommand cmdddd = new SqlCommand("INSERT INTO [dbo].[mysqlcekme]([zaman]) VALUES(@zaman)", connec);
            connec.Open();
            cmdddd.Parameters.AddWithValue("@zaman", elapsedMs);
            cmdddd.ExecuteNonQuery();
            connec.Close();

            label1.Text = "Export icin gecen sure=>  " + elapsedMs.ToString() + "ms";
        }
    }
}
