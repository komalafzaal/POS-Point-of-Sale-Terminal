using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class customerDTO
    {
        int id;
        string name;
        string address;
        string phone;
        string email;
        int amountPayable;
        double salesLimit;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int AmountPayable
        {
            get { return amountPayable; }
            set { amountPayable = value; }
        }
        public double SalesLimit
        {
            get { return salesLimit; }
            set { salesLimit = value; }
        }


    }
}
