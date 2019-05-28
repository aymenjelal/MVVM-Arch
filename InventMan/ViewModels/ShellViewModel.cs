using Caliburn.Micro;
using InventMan.Models;
using InventMan.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventMan.ViewModels
{
    class ShellViewModel: Conductor<object>
    {

        public UserModel user;

        private string _userName;
        private string _password;
        private string _success;


        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        public string Success
        {
            get { return _success; }
            set
            {
                _success = value;
                NotifyOfPropertyChange(() => Success);
            }
        }


        public void Login(string userName, string passowrd, object sender)
        {
            user = new UserModel();
            user = user.getUser(userName);

            if (user != null)
            {
                if (user.Password.Equals(this.Password))
                {
                    Success = "Login successfull";

                }
            }
            
            else
            {
                Success = "sorry username and password dont match";
            }



        }

        public void close()
        {
            TryClose();
        }

    }
}
