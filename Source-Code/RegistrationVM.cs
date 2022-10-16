using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace B_Validation_ByDataErrorInfo
{
    public class RegistrationVM : ObservableObject, IDataErrorInfo
    {
        public string Error { get { return null;  } }
        private string _username;
        private string _password;
        private string _hostname;
        private string _hostphone;
        private string _hostemail;
        private string _programname;
        

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;

                switch(name)
                {
                    case "Username":
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Username cannot be empty";
                       
                        
                        else if (Username.Length < 3)
                            result = "Username must be a minimum of 3 characters.";
                        break;
                    case "Password":
                        if (string.IsNullOrWhiteSpace(Password))
                            result = "Password cannot be empty";
                        break;

                    case "HostName":
                        if (string.IsNullOrWhiteSpace(HostName))
                            result = "Host Name can't be null or empty";
                        else if (HostName.Length < 3)
                            result = "hostname should be longer than 2 characters";
                        break;

                    case "HostEmail":
                        if (string.IsNullOrWhiteSpace(HostEmail))
                            result = "Email cant be empty";
                        else if (string.IsNullOrWhiteSpace(HostEmail))
                            result = "Email cant be empty";
                        else if (!HostEmail.Contains("@gmail.com") || !HostEmail.Contains("@yahoo.com") || !HostEmail.Contains("@outlook.com"))
                            result = "Make sure to add email annotations. (i.e. @gmail.com, outlook.com)";
                        break;


                    case "HostPhone":
                        if (string.IsNullOrWhiteSpace(HostPhone))
                            result = "Phone Number cant be empty";
                        else if (string.IsNullOrWhiteSpace(HostPhone))
                            result = "Phone Number cant be empty";
                        else if (HostPhone.Length < 10)
                            result = "Phone Number can't be less than 10 digits";

                        else if (checkphone()==false)
                            result = "A phone number field can't contain a letter";
                        break;


                    case "ProgramName":

                        if (string.IsNullOrWhiteSpace(ProgramName))
                            result = "Program Name cant be empty";
                        else if (string.IsNullOrWhiteSpace(ProgramName))
                            result = "Program Name cant be empty";

                        break;

                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        public Boolean checkphone()
        {
            string s = HostPhone.ToString();


            try
            {
                int.Parse(s);
                return true;
                
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }


        public string ProgramName
        {
            get { return _programname; }
            set
            {
                OnPropertyChanged(ref _programname, value);
            }
        }


        public string Password
        {
            get { return _password; }
            set
            {
                OnPropertyChanged(ref _password, value);
            }
        }

        public string HostName
        {
            get { return _hostname; }
            set
            {
                OnPropertyChanged(ref _hostname, value);
            }
        }

        public string HostPhone
        {
            get { return _hostphone; }
            set
            {
                OnPropertyChanged(ref _hostphone, value);
            }
        }

        public string HostEmail
        {
            get { return _hostemail; }
            set
            {
                OnPropertyChanged(ref _hostemail, value);
            }
        }

    }
}
