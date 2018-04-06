using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
     public abstract class UserRegister
    {
        public string username { get; set; }
        public string password { get; set; }

        public abstract bool createUser();

        protected virtual bool validate(string username, string password, string key = "") {
            if (username.Trim().Length != 0 && password.Trim().Length != 0)
            {
                return true;
            } else {
                MessageBox.Show("Blank Username or Password");
                return false;
            }
        }


        /*public UserRegister(string uname, string pass) {
            this.username = uname;
            this.password = pass;
        }*/
    }

    public class Admin : UserRegister {
        private string Masterkey = "59735";

        public string key { get; set; }

        protected override bool validate(string username, string password, string _key)
        {
            if (username.Trim().Length != 0 && password.Length != 0)
            {
                if (key == this.Masterkey)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid Key");
                    return false;
                }

            }
            else {
                MessageBox.Show("Blank Username or Password");
                return false;
            }
     
        }

        public override bool createUser()
        {
            if (validate(this.username, this.password, this.key))
            {
                MessageBox.Show("Admin Created");
                return true;
            }
            else {
                return false;
            }
        }


    }

     public class User : UserRegister {

        protected override bool validate(string username, string password, string key = "")
        {
            return base.validate(username, password, key);
        }

        public override bool createUser()
        {
            if (validate(this.username, this.password))
            {
                MessageBox.Show("User Created");
                return true;
            }
            else {
                return false;
            }
        }
    }
}
