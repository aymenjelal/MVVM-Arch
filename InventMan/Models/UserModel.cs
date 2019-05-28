using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventMan.Models
{
    public class UserModel
    {
        public string  Id{get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Type { get; set; }

        MySqlConnection conn = DBUtils.GetDBConnection();
        

        public UserModel(string uid, string firstName, string lastName, string password, string email, int type)
        {
            Id = uid;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Type = type;
        }

        public UserModel()
        {

        }

        public UserModel getUser(string id)
        {
            
            string query = "SELECT * FROM USERS WHERE id ='" + id + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            UserModel u=null;

            while (reader.Read())
            {

                string uid = reader["id"].ToString();
                string firstName = reader["first_name"].ToString();
                string lastName = reader["last_name"].ToString();
                string password = reader["password"].ToString();
                string email = reader["email"].ToString();
                int type = (int)reader["type"];

                u = new UserModel(uid, firstName, lastName, password, email, type);


            }



            
            return u;

        }

        public void update(string id, string firstName, string lastName, string password, string email)
        {
            try
            {
                string query = string.Format("UPDATE users SET first_name='{0}',last_name='{1}',password='{2}',email='{3}' where id ='{4}'",firstName,lastName,password,email,id);
                Console.WriteLine(query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();




                conn.Close();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

        public void addUser(string id, string firstName, string lastName, string password, string email)
        {
            int type = 1;
            try
            {
                string query = string.Format("INSERT INTO users(id,first_name,last_name,password,email,type) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", id, firstName, lastName, password, email, type);
                Console.WriteLine(query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
}
