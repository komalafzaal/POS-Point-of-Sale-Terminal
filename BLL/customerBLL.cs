using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class customerBLL
    {
        public void AddCustomer(customerDTO cdto)
        {
            customerDAL cdal = new customerDAL();
            cdal.AddCustomer(cdto);
        }

        public void ModifyCustomer(customerDTO cdto)
        {
            customerDAL cdal = new customerDAL();
            cdal.ModifyCustomer(cdto);
        }
        public bool ValidateCustomerId(customerDTO cdto)
        {
            customerDAL cdal = new customerDAL();
            bool flag = cdal.ValidateCustomerId(cdto);
            if (flag)
            {
                return true;
            }
            return false;
        }
        public bool FindCustomer(customerDTO cdto)
        {
            customerDAL cdal = new customerDAL();
            bool flag = cdal.FindCustomer(cdto);
            if(flag)
            {
                return true;
            }
            return false;
        }

        public void RemoveExistingCustomer(customerDTO cdto)
        {
            customerDAL cdal = new customerDAL();
            cdal.RemoveExistingCustomer(cdto);
        }
        public List<customerDTO> ReadCustomer(customerDTO cdto)
        {
            customerDAL cdal = new customerDAL();
            List<customerDTO> list = new List<customerDTO>();
            List<customerDTO> activeList = new List<customerDTO>();

            list = cdal.ReadAllCustomers(cdto);
            foreach (customerDTO cus in list)
            {
                activeList.Add(cus);
            }
            return list;

        }
        public List<customerDTO> ReadFindCustomers(customerDTO cdto)
        {
            customerDAL cdal = new customerDAL();
            List<customerDTO> list = new List<customerDTO>();
            List<customerDTO> activeList = new List<customerDTO>();

            list = cdal.ReadFindCustomers(cdto);
            foreach (customerDTO cus in list)
            {
                activeList.Add(cus);
            }
            return list;

        }
    }
}
