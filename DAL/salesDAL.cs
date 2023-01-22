using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class salesDAL
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int ReadLastRecordID(salesDTO sDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", sDTO.OrderId);
            string query = $"select MAX(OrderId) from Sale";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.Add(p1);


            int count = (int)cmd.ExecuteScalar();

            con.Close();
            return count;

        }
        public void newSale(salesDTO sdto)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlParameter p1 = new SqlParameter("o", sdto.OrderId);
            SqlParameter p2 = new SqlParameter("c", sdto.CustomerId);
            SqlParameter p3 = new SqlParameter("date", sdto.Date);
            SqlParameter p4 = new SqlParameter("s", sdto.Status);

            string query = $"insert into Sale (CustomerId, Date, Status) values (@c, @date, @s)";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            int count = cmd.ExecuteNonQuery();

            Console.WriteLine("Sale successfully saved!....");

            con.Close();

        }

        public List<itemDTO> ReadItemInfo(itemDTO idto)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", idto.Id);
            string query = $"select * from Item where ItemId = @i";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            List<itemDTO> list = new List<itemDTO>();

            while (dr.Read())
            {
                itemDTO items = new itemDTO()
                {
                    Id = (int)dr[0],
                    Description = (string)dr[1],
                    Price = (double)dr[2],
                    Quantity = (int)dr[3],
                    CreationDate = (string)dr[4]
                };
                list.Add(items);
            }
            con.Close();
            return list;
        }

        public void addNewSaleLineItem(salesDTO sdto, itemDTO idto)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlParameter p1 = new SqlParameter("o", sdto.OrderId);
            SqlParameter p2 = new SqlParameter("i", idto.Id);
            SqlParameter p3 = new SqlParameter("date", sdto.Quantity);
            SqlParameter p4 = new SqlParameter("a", sdto.Amount);

            string query = $"insert into SaleLineItem (OrderId, ItemId, Quantity, Amount) values (@o, @i, @date, @a)";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            int count = cmd.ExecuteNonQuery();

            Console.WriteLine("insert Sale line Item successfully saved!....");

            con.Close();

        }
        public void DeleteAllSale()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = $"DELETE FROM Sale";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int count = cmd.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteAllSaleLineItem()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query1 = $"DELETE FROM SaleLineItem";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            con.Open();

            int count1 = cmd1.ExecuteNonQuery();
            con.Close();

        }

        public List<salesDTO> ReadDataFromSales(salesDTO dto)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", dto.CustomerId);
            string query = "select * from sale where CustomerId = @i";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.Add(p1);

            List<salesDTO> list = new List<salesDTO>();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                salesDTO sales = new salesDTO()
                {
                    OrderId = (int)dr[0],
                    CustomerId = (int)dr[1],
                    Date = (string)dr[2],
                    Status = (string)dr[3],
                };

                list.Add(sales);
            }
            con.Close();
            return list;
        }
        public void RemoveExistingItemFromSale(itemDTO idto)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", idto.Id);


            string query = $"DELETE FROM SaleLineItem where ItemId =@i";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.Add(p1);

            int count1 = cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
