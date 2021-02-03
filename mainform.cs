using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;
using MySql.Data;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Net.Mail;
namespace VeriTabProjeDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string csa;
                csa = @"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security = True;";
                SqlConnection con = new SqlConnection(csa);
                string query = "INSERT INTO [dbo].[badges]([id],[UserID],[name],[date_],[class],[tagbase]) VALUES(@id,@userid,@name,@date,@class,@tagbase)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                for (int j = 0; j < 100; j++)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@userid", dataGridView1.Rows[i].Cells[1].Value);
                        cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[2].Value);
                        cmd.Parameters.AddWithValue("@date", dataGridView1.Rows[i].Cells[3].Value);
                        cmd.Parameters.AddWithValue("@class", dataGridView1.Rows[i].Cells[4].Value);
                        cmd.Parameters.AddWithValue("@tagbase", dataGridView1.Rows[i].Cells[5].Value);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                con.Close();
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                label1.Text = "Import icin gecen sure=>  " + elapsedMs.ToString() + "ms";
                label1.Visible = true;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                SqlCommand cmdd = new SqlCommand("INSERT INTO [dbo].[mssqlatma]([zaman]) VALUES(@zaman)", conn);
                conn.Open();
                cmdd.Parameters.AddWithValue("@zaman", elapsedMs);
                cmdd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public class confirm
        {
            public void method(DataGridView dataGridView1, Label label)
            {
                try
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    string MyConnectionString = "datasource = localhost;database=veritabdeneme; port = 3306; username = root; password = 123456";
                    MySqlConnection connection = new MySqlConnection(MyConnectionString);
                    string query = "INSERT INTO deneme3(id, userid, name, date, class, tagbased)VALUES(@id, @userid, @name, @date, @class, @tagbased)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    connection.Open();
                    for (int j = 0; j < 50; j++)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@userid", dataGridView1.Rows[i].Cells[1].Value);
                            cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[2].Value);
                            cmd.Parameters.AddWithValue("@date", dataGridView1.Rows[i].Cells[3].Value);
                            cmd.Parameters.AddWithValue("@class", dataGridView1.Rows[i].Cells[4].Value);
                            cmd.Parameters.AddWithValue("@tagbased", dataGridView1.Rows[i].Cells[5].Value);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                        }
                    }
                    connection.Close();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    label.Text = "Import icin gecen sure=>  " + elapsedMs.ToString() + "ms";
                    label.Visible = true;
                    SqlConnection connec = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                    SqlCommand cmdddd = new SqlCommand("INSERT INTO [dbo].[mysqlatma]([zaman]) VALUES(@zaman)", connec);
                    connec.Open();
                    cmdddd.Parameters.AddWithValue("@zaman", elapsedMs);
                    cmdddd.ExecuteNonQuery();
                    connec.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Xml Dosyası |*.xml";
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Xml Dosyası Seçiniz..";
            file.Multiselect = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string DosyaYolu = file.FileName;
                string DosyaAdi = file.SafeFileName;
                XmlReader xmlFile = XmlReader.Create(DosyaYolu, new XmlReaderSettings());

                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFile);
                dataGridView1.DataSource = dataSet.Tables["record"];
                xmlFile.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            confirm exec = new confirm();
            exec.method(dataGridView1, label1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string MyConnectionString = "Server=" + "localhost" + ";Port=" + "5432" + "; User Id=" + "postgres" + ";Password=" + "123456" + ";Database=" + "deneme" + "";
                NpgsqlConnection connection = new NpgsqlConnection(MyConnectionString);
                string query = "INSERT INTO public.denemetablo(id, userid, name, date, class, tagbased)VALUES(@id, @userid, @name, @date, @class, @tagbased);";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                connection.Open();
                for (int j = 0; j < 100; j++)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@userid", dataGridView1.Rows[i].Cells[1].Value);
                        cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[2].Value);
                        cmd.Parameters.AddWithValue("@date", dataGridView1.Rows[i].Cells[3].Value);
                        cmd.Parameters.AddWithValue("@class", dataGridView1.Rows[i].Cells[4].Value);
                        cmd.Parameters.AddWithValue("@tagbased", dataGridView1.Rows[i].Cells[5].Value);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                connection.Close();
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                label1.Text = "Import icin gecen sure=>  " + elapsedMs.ToString() + "ms";
                label1.Visible = true;
                SqlConnection conne = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                SqlCommand cmddd = new SqlCommand("INSERT INTO [dbo].[postgresqlatma]([zaman]) VALUES(@zaman)", conne);
                conne.Open();
                cmddd.Parameters.AddWithValue("@zaman", elapsedMs);
                cmddd.ExecuteNonQuery();
                conne.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }
    }
}
