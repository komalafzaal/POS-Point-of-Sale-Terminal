using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class itemDTO
    {
        int id;
        string description;
        double price;
        int quantity;
        string creationDate;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
       
    }
}
