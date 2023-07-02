using System.ComponentModel;
using System.Data.Entity.Migrations.Model;
using System.Xml.Linq;

namespace Employees.Models.Wrappers
{
    public class EmployeeWrapper : IDataErrorInfo
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

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
                        }
                        else
                        {
                            Error = string.Empty;
                        }
                        break;
                    case nameof(Surename):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole Nazwisko jest wymagane.";
                        }
                        else
                        {
                            Error = string.Empty;
                        }
                        break;
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole email jest wymagane.";
                        }
                        else
                        {
                            Error = string.Empty;
                        }
                        break;
                    case nameof(Phone):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole Phone jest wymagane.";
                        }
                        else
                        {
                            Error = string.Empty;
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
    }


}
