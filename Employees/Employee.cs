using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class Employee
    {
        public Employee(
            int _Code, 
            string _ID, 
            string _FirstName, 
            string _LastName, 
            DateTime _Birthday, 
            bool _IsMale, 
            string _Status, 
            string _Telephone, 
            string _Celphone, 
            string _City, 
            string _Street, 
            string _Number) 
        { 
            Code = _Code;
            ID = _ID;   
            FirstName = _FirstName;
            LastName = _LastName;
            Birthday = _Birthday;
            IsMale = _IsMale;
            Status = _Status;
            Telephone = _Telephone;
            Celphone = _Celphone;
            City = _City;
            Street = _Street;
            Number = _Number;
        }   
        public int Code { get; set; }
        public string ID { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName;  } }
        public DateTime Birthday { get; set; }
        public int Age { get { return DateTime.Now.Year - Birthday.Year; } }
        public bool IsMale { get; set; }
        public string Status { get; set; }
        public string Telephone {  get; set; }
        public string Celphone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Addres { get { return Street = " " + Number + " " + City; } }


    }
}
