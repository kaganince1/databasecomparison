using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Npgsql;

namespace VeriTabProjeDeneme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security = True;");
            SqlCommand cmd = new SqlCommand("SELECT [id],[UserID],[name],[date_],[class],[tagbase]FROM[proje_deneme].[dbo].[badges]", con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
            SqlCommand cmdd = new SqlCommand("INSERT INTO [dbo].[mssqlcekme]([zaman]) VALUES(@zaman)", conn);
            conn.Open();
            cmdd.Parameters.AddWithValue("@zaman", elapsedMs);
            cmdd.ExecuteNonQuery();
            conn.Close();

            label1.Text = "Export icin gecen sure=>  " + elapsedMs.ToString() + "ms";
        }
    }
}
