using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace WindowsFormsApplication8
{
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
        }

        private void setDisplay()
        {
            pictureBox6.Hide();
            panel3.Hide();
            textBox3.Visible = false;

            pictureBox2.Location = new Point(782, 189);
            textBox1.Location = new Point(491, 209);
            panel1.Location = new Point(491, 228);

            pictureBox3.Location = new Point(784, 267);
            textBox2.Location = new Point(491, 288);
            panel2.Location = new Point(491, 306);

            comboBox1.Location = new Point(489, 353);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            setDisplay();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.BackColor = Color.YellowGreen;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
        }

        private void textBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.YellowGreen;
            panel2.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.BackColor = Color.YellowGreen;
            panel1.BackColor = Color.DimGray;
            panel2.BackColor = Color.DimGray;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "User") {
                setDisplay();


            }
            else if (comboBox1.Text == "Admin")
            {
                pictureBox6.Show();
                panel3.Show();
                textBox3.Visible = true;

                pictureBox2.Location = new Point(780, 158);
                panel1.Location = new Point(489, 197);
                textBox1.Location = new Point(489, 178);

                pictureBox3.Location = new Point(782, 236);
                panel2.Location = new Point(489, 275);
                textBox2.Location = new Point(489, 257);

                pictureBox6.Location = new Point(782, 299);
                panel3 .Location = new Point(489, 338);
                textBox3.Location = new Point(489, 320);

                comboBox1.Location = new Point(489, 353);

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void showLogin() {
            this.Hide();
            Login frm = new Login();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Admin")
            {
                //Admin admin = new Admin(textBox1.Text, textBox2.Text, textBox3.Text);
                Admin admin = new Admin() { username = textBox1.Text, password = textBox2.Text, key = textBox3.Text };
           
                if (admin.createUser()) {
                    XmlSerializer xs = new XmlSerializer(typeof(Admin));
                    FileStream fs = File.Create("admins.xml");
                    xs.Serialize(fs, admin);
                    fs.Close();

                    showLogin();
                }

            }
            else if (comboBox1.Text == "User")
            {
                //User user = new User(textBox1.Text, textBox2.Text);
                User user = new User() { username = textBox1.Text, password = textBox2.Text };

                if (user.createUser()) {
                    XmlSerializer xs = new XmlSerializer(typeof(User));
                    FileStream fs = File.Create("users.xml");
                    xs.Serialize(fs, user);
                    fs.Close();

                    showLogin();
                }
            }
        }

    }
}

