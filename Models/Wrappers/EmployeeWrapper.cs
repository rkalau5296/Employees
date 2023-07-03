using System.ComponentModel;

namespace Employees.Models.Wrappers
{
    public class EmployeeWrapper : IDataErrorInfo
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        private bool _isNameValid;
        private bool _isSurenameValid;
        private bool _isEmailValid;
        private bool _isPhoneValid;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole Imię jest wymagane.";
                            _isNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isNameValid = true;
                        }
                        break;
                    case nameof(Surename):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole Nazwisko jest wymagane.";
                            _isSurenameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isSurenameValid = true;
                        }
                        break;
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole email jest wymagane.";
                            _isEmailValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isEmailValid = true;
                        }
                        break;
                    case nameof(Phone):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole Phone jest wymagane.";
                            _isPhoneValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isPhoneValid = true;
                        }
                        break;
                    default:
                        break;
                }
                return Error;
            }

        }

        public string Error
        {
            get; set;
        }
        public bool IsValid
        {
            get 
            {
                return _isNameValid && _isSurenameValid && _isEmailValid && _isPhoneValid;
            }
        }
    }


}
