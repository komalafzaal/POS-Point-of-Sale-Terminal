using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class salesDTO
    {
        int orderId;
        int customerId;
        string date;
        string status;
        int quantity;
        double amount;
        string customerName;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double Amount
        {
            get { return amount; }
            set { amount = value; } 
        }
        public string CustomterName
        {
            get { return customerName; }
            set { customerName = value; }
        }

    }
}
