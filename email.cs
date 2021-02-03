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
using System.Net.Mail;

namespace VeriTabProjeDeneme
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connec = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                string mssqlatma = "SELECT avg(zaman) as zaman2 FROM[dbo].[mssqlatma]";
                SqlCommand cmd = new SqlCommand(mssqlatma, connec);
                SqlDataReader reader = null;
                int mssqlat = 0;
                connec.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())   // This is how record is read. Loop through the each record
                    {
                        mssqlat = reader.GetInt32(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("! " + e.ToString());
                }
                finally
                {
                    reader.Close();
                    connec.Close();
                }
                SqlConnection connece = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                string mssqlcekme = "SELECT avg(zaman) as zaman2 FROM[dbo].[mssqlcekme]";
                SqlCommand cmdd = new SqlCommand(mssqlcekme, connece);
                SqlDataReader readerr = null;
                int mssqlcek = 0;
                connece.Open();
                try
                {
                    readerr = cmdd.ExecuteReader();
                    while (readerr.Read())   // This is how record is read. Loop through the each record
                    {
                        mssqlcek = readerr.GetInt32(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("! " + e.ToString());
                }
                finally
                {
                    readerr.Close();
                    connece.Close();
                }
                SqlConnection connecet = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                string mysqlatma = "SELECT avg(zaman) as zaman2 FROM[dbo].[mysqlatma]";
                SqlCommand cmddd = new SqlCommand(mysqlatma, connecet);
                SqlDataReader readerrr = null;
                int mysqlat = 0;
                connecet.Open();
                try
                {
                    readerrr = cmddd.ExecuteReader();
                    while (readerrr.Read())   // This is how record is read. Loop through the each record
                    {
                        mysqlat = readerrr.GetInt32(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("! " + e.ToString());
                }
                finally
                {
                    readerrr.Close();
                    connecet.Close();
                }
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                string mysqlcekme = "SELECT avg(zaman) as zaman2 FROM[dbo].[mysqlcekme]";
                SqlCommand cmdddd = new SqlCommand(mysqlcekme, con);
                SqlDataReader readerrrr = null;
                int mysqlcek = 0;
                con.Open();
                try
                {
                    readerrrr = cmdddd.ExecuteReader();
                    while (readerrrr.Read())   // This is how record is read. Loop through the each record
                    {
                        mysqlcek = readerrrr.GetInt32(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("! " + e.ToString());
                }
                finally
                {
                    readerrrr.Close();
                    con.Close();
                }
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                string postgresqlatma = "SELECT avg(zaman) as zaman2 FROM[dbo].[postgresql]";
                SqlCommand cmddddd = new SqlCommand(postgresqlatma, conn);
                SqlDataReader readerrrrr = null;
                int postgresqlat = 0;
                conn.Open();
                try
                {
                    readerrrrr = cmddddd.ExecuteReader();
                    while (readerrrrr.Read())   // This is how record is read. Loop through the each record
                    {
                        postgresqlat = readerrrrr.GetInt32(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("! " + e.ToString());
                }
                finally
                {
                    readerrrrr.Close();
                    conn.Close();
                }
                SqlConnection conne = new SqlConnection(@"Data Source=DESKTOP-VOC3F1I\SQLEXPRESS;Initial Catalog=zamancizelgesi;Integrated Security = True;");
                string postgresqlcekme = "SELECT avg(zaman) as zaman2 FROM[dbo].[postgresqlatma]";
                SqlCommand cmdddddd = new SqlCommand(postgresqlcekme, conne);
                SqlDataReader readerrrrrr = null;
                int postgresqlcek = 0;
                conne.Open();
                try
                {
                    readerrrrrr = cmdddddd.ExecuteReader();
                    while (readerrrrrr.Read())   // This is how record is read. Loop through the each record
                    {
                        postgresqlcek = readerrrrrr.GetInt32(0);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("! " + e.ToString());
                }
                finally
                {
                    readerrrrrr.Close();
                    conne.Close();
                }
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                string mailll = textBox1.Text;
                if (IsValidEmail(mailll))
                {
                    mail.From = new MailAddress("ilhanmertalan@gmail.com");
                    mail.To.Add(mailll);
                    mail.Subject = "Mailin basligi";
                    mail.Body = "Mssql import taking time: " + mssqlat.ToString() + "\nMssql export taking time: " + mssqlcek.ToString() + "\nMysql import taking time: " + mysqlat.ToString() + "\nMysql export taking time: " + mysqlcek.ToString() + "\nPostgresql import taking time: " + postgresqlat.ToString() + "\nPostgresql export taking time:  " + postgresqlcek.ToString();

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("guycalledilan@gmail.com", "Smtp.1234");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail sent");
                }
                else
                    MessageBox.Show("Mail cannot send");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail cannot send");
            }
        }
    }
}
