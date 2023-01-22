using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class customerDAL
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddCustomer(customerDTO cDTO)
        {

            SqlConnection con = new SqlConnection(connectionString);

            SqlParameter p1 = new SqlParameter("n", cDTO.Name);
            SqlParameter p2 = new SqlParameter("a", cDTO.Address);
            SqlParameter p3 = new SqlParameter("p", cDTO.Phone);
            SqlParameter p4 = new SqlParameter("e", cDTO.Email);
            SqlParameter p5 = new SqlParameter("ap", cDTO.AmountPayable);
            SqlParameter p6 = new SqlParameter("s", cDTO.SalesLimit);

            string query = $"insert into Customer (Name, Address, Phone, Email, AmountPayable, SalesLimit) values (@n, @a, @p, @e, @ap, @s)";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);

            int count = cmd.ExecuteNonQuery();
            Console.WriteLine(" Customer Information successfully saved!....");

            con.Close();
        }
        public bool ValidateCustomerId(customerDTO cDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", cDTO.Id);

            string query = $"Select * from Customer where CustomerId = @i";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            return false;
        }
        public void ModifyCustomer(customerDTO cDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", cDTO.Id);
            SqlParameter p2 = new SqlParameter("n", cDTO.Name);
            SqlParameter p3 = new SqlParameter("a", cDTO.Address);
            SqlParameter p4 = new SqlParameter("p", cDTO.Phone);
            SqlParameter p5 = new SqlParameter("e", cDTO.Email);
            SqlParameter p6 = new SqlParameter("ap", cDTO.AmountPayable);
            SqlParameter p7 = new SqlParameter("s", cDTO.SalesLimit);

            string query = $"update Customer set Name = @n, Address = @a, Phone = @p," +
                $" Email = @e, AmountPayable = @ap, SalesLimit = @s where CustomerId = @i";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Update Customer Successfully!....");
            con.Close();
        }

        public bool FindCustomer(customerDTO cDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", cDTO.Id);
            SqlParameter p2 = new SqlParameter("n", cDTO.Name);
            SqlParameter p3 = new SqlParameter("p", cDTO.Phone);
            SqlParameter p4 = new SqlParameter("e", cDTO.Email);
            SqlParameter p5 = new SqlParameter("s", cDTO.SalesLimit);

            string query = $"Select * from Customer where CustomerId = @i OR Name = @n OR Phone = @p" +
                $" OR Email = @e OR SalesLimit = @s";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);


            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                return true;

            }
            return false;
        }


        public void RemoveExistingCustomer(customerDTO cDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", cDTO.Id);

            string query = $"delete from Customer where CustomerId = @i";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Delete Record Successfully!....");
            con.Close();
        }
        public List<customerDTO> ReadAllCustomers(customerDTO cDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", cDTO.Id);

            string query = $"Select * from Customer where CustomerId = @i";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            List<customerDTO> list = new List<customerDTO>();

            while (dr.Read())
            {
                customerDTO cus = new customerDTO()
                {
                    Id = (int)dr[0],
                    Name = (string)dr[1],
                    Address = (string)dr[2],
                    Phone = (string)dr[3],
                    Email = (string)dr[4],
                    AmountPayable = (int)dr[5],
                    SalesLimit = (double)dr[6]
                };
                list.Add(cus);
            }
            con.Close();
            return list;

        }

        public List<customerDTO> ReadFindCustomers(customerDTO cDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", cDTO.Id);
            SqlParameter p2 = new SqlParameter("n", cDTO.Name);
            SqlParameter p3 = new SqlParameter("p", cDTO.Phone);
            SqlParameter p4 = new SqlParameter("e", cDTO.Email);
            SqlParameter p5 = new SqlParameter("s", cDTO.SalesLimit);
            string query = $"Select * from Customer where CustomerId = @i OR Name = @n OR Phone = @p" +
                $" OR Email = @e OR SalesLimit = @s";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            SqlDataReader dr = cmd.ExecuteReader();
            List<customerDTO> list = new List<customerDTO>();

            while (dr.Read())
            {
                customerDTO cus = new customerDTO()
                {
                    Id = (int)dr[0],
                    Name = (string)dr[1],
                    Address = (string)dr[2],
                    Phone = (string)dr[3],
                    Email = (string)dr[4],
                    AmountPayable = (int)dr[5],
                    SalesLimit = (double)dr[6]
                };
                list.Add(cus);
            }
            con.Close();
            return list;

        }


    }
}
