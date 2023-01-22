using Microsoft.Data.SqlClient;
using DTO;
using System.Collections.Generic;


namespace DAL
{
    public class itemDAL
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void AddItem(itemDTO iDTO)
        {

            SqlConnection con = new SqlConnection(connectionString);

            SqlParameter p1 = new SqlParameter("d", iDTO.Description);
            SqlParameter p2 = new SqlParameter("p", iDTO.Price);
            SqlParameter p3 = new SqlParameter("q", iDTO.Quantity);
            SqlParameter p4 = new SqlParameter("date", iDTO.CreationDate);

            string query = $"insert into Item (Description, Price, Quantity, CreationDate) values (@d, @p, @q, @date)";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            int count = cmd.ExecuteNonQuery();
            //Console.WriteLine($"Count: " + count);
            SqlDataReader dr = cmd.ExecuteReader();

           
            Console.WriteLine(" Item Information successfully saved!....");
            
            con.Close();
        }

        public bool ValidateItemId(itemDTO iDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", iDTO.Id);

            string query = $"Select * from Item where ItemId = @i";

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
        public void ModifyItem(itemDTO iDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", iDTO.Id);
            SqlParameter p2 = new SqlParameter("d", iDTO.Description);
            SqlParameter p3 = new SqlParameter("p", iDTO.Price);
            SqlParameter p4 = new SqlParameter("q", iDTO.Quantity);
            SqlParameter p5 = new SqlParameter("date", iDTO.CreationDate);

            string query = $"update Item set Description = @d, Price = @p," +
                $" Quantity = @q, CreationDate = @date where ItemId = @i";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Update Successfully!....");
            con.Close();
        }

        public bool FindItem(itemDTO iDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", iDTO.Id);
            SqlParameter p2 = new SqlParameter("d", iDTO.Description);
            SqlParameter p3 = new SqlParameter("p", iDTO.Price);
            SqlParameter p4 = new SqlParameter("q", iDTO.Quantity);
            SqlParameter p5 = new SqlParameter("date", iDTO.CreationDate);

            string query = $"Select * from Item where ItemId = @i OR Description = @d OR Price = @p" +
                $" OR Quantity = @q OR CreationDate = @date";

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

        public void RemoveExistingItem(itemDTO iDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", iDTO.Id);

            string query = $"delete from Item where ItemId = @i";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Delete Successfully!....");
            con.Close();
        }
        
        public List<itemDTO> ReadAllItems(itemDTO iDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", iDTO.Id);

            string query = $"Select * from Item where ItemId = @i";

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
                Console.WriteLine(items);
                list.Add(items);
            }
            con.Close();
            return list;

        }

        public List<itemDTO> ReadFindItems(itemDTO iDTO)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlParameter p1 = new SqlParameter("i", iDTO.Id);
            SqlParameter p2 = new SqlParameter("d", iDTO.Description);
            SqlParameter p3 = new SqlParameter("p", iDTO.Price);
            SqlParameter p4 = new SqlParameter("q", iDTO.Quantity);
            SqlParameter p5 = new SqlParameter("date", iDTO.CreationDate);

            string query = $"Select * from Item where ItemId = @i OR Description = @d OR Price = @p" +
                $" OR Quantity = @q OR CreationDate = @date";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            SqlDataReader dr = cmd.ExecuteReader();
            List<itemDTO> list = new List<itemDTO>();

            while (dr.Read())
            {
                itemDTO i = new itemDTO()
                {
                    Id = (int)dr[0],
                    Description = (string)dr[1],
                    Price = (double)dr[2],
                    Quantity = (int)dr[3],
                    CreationDate = (string)dr[4]
                };
                list.Add(i);
            }
            con.Close();
            return list;

        }
    }
}