using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApplication8
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.BackColor = Color.YellowGreen;
            panel1.BackColor = Color.DimGray;
        }

        private void textBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.YellowGreen;
            panel2.BackColor = Color.DimGray;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var reg = new Register();
            reg.Closed += (s, args) => this.Close();
            reg.Show();

        }

        private void DoLogin() { 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                if (comboBox1.Text == "Admin") {
                    XmlSerializer serializer = new XmlSerializer(typeof(Admin));

                    FileStream fs = new FileStream("admins.xml", FileMode.Open);

                    XmlReader reader = XmlReader.Create(fs);

                    Admin i;

                    i = (Admin)serializer.Deserialize(reader);
                    fs.Close();

                    if (i.username == textBox1.Text && i.password == textBox2.Text)
                    {
                        this.Hide();
                        CMS frm = new CMS();
                        frm.Closed += (s, args) => this.Close();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                else if (comboBox1.Text == "User")
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(User));

                    FileStream fs = new FileStream("users.xml", FileMode.Open);

                    XmlReader reader = XmlReader.Create(fs);

                    User i;

                    i = (User)serializer.Deserialize(reader);
                    fs.Close();

                    if (i.username == textBox1.Text && i.password == textBox2.Text)
                    {
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.Closed += (s, args) => this.Close();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                } 
                    
                } catch(FileNotFoundException) {
                    MessageBox.Show("No Users");
                }
                

            }

        }

    }


