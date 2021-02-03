using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.SqlClient;

namespace VeriTabProjeDeneme
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string connString = "Server=" + "localhost" + ";Port=" + "5432" + "; User Id=" + "postgres" + ";Password=" + "123456" + ";Database=" + "deneme" + "";
            string query = "SELECT id, userid, name, date, class, tagbased FROM public.denemetablo;";
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                SqlConnection conne = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                SqlCommand cmddd = new SqlCommand("INSERT INTO [dbo].[postgresql]([zaman]) VALUES(@zaman)", conne);
                conne.Open();
                cmddd.Parameters.AddWithValue("@zaman", elapsedMs);
                cmddd.ExecuteNonQuery();
                conne.Close();

                label1.Text = "Export icin gecen sure=>  " + elapsedMs.ToString() + "ms";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
