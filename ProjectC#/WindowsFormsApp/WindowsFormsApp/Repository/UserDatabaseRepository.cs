using ConsoleApp.Domain;
using ConsoleApp.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp.Repository
{
    public class UserDatabaseRepository : UserRepository
    {
        private static readonly ILog Log = LogManager.GetLogger("UserDatabaseRepository");

        public UserDatabaseRepository()
        {
            Log.Info("Creating UserDatabaseRepository");
        }


        public List<User> findAll()
        {
            Log.Info("Entering GetAll");
            var users = new List<User>();
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from userr;";
                

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        var email = dataReader.GetString(dataReader.GetOrdinal("email"));
                        var name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        var password = dataReader.GetString(dataReader.GetOrdinal("password"));
                        var status = dataReader.GetString(dataReader.GetOrdinal("status"));
                        UserStatus userStatus;
                        if (status == UserStatus.LOGGEDIN.ToString())
                        {
                            userStatus = UserStatus.LOGGEDIN;
                        }
                        else
                        {
                            userStatus = UserStatus.LOGGEDOUT;
                        }
                        var user = new User(email, password, name, userStatus);
                        user.setId(id);
                        users.Add(user);
                    }
                }
            }
            Log.InfoFormat("Exiting GetAll with values {0}", users);
            return users;
        }

        public User findOne(int id)
        {
            Log.InfoFormat("Entering GetOne with value {0}", id);

            User user = null;
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from userr where userr.id = " + id + ";";
                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        var email = dataReader.GetString(dataReader.GetOrdinal("email"));
                        var name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        var password = dataReader.GetString(dataReader.GetOrdinal("password"));
                        var status = dataReader.GetString(dataReader.GetOrdinal("status"));
                        UserStatus userStatus;
                        if (status == UserStatus.LOGGEDIN.ToString())
                        {
                            userStatus = UserStatus.LOGGEDIN;
                        }
                        else
                        {
                            userStatus = UserStatus.LOGGEDOUT;
                        }
                        user = new User(email, password, name, userStatus);
                        user.setId(id);
                    }
                }
            }
            return user;
        }

        public void save(User user)
        {
            Log.InfoFormat("Entering Add with value {0}", user);
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText =
                "INSERT INTO userr(email,password,name,status) VALUES (@email,@password,@name,@status);";

                var dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@email";
                dataParameter.Value = user.getEmail();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@password";
                dataParameter.Value = user.getPassword();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@name";
                dataParameter.Value = user.getName();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@status";
                dataParameter.Value = user.getStatus().ToString();
                command.Parameters.Add(dataParameter);

                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting getOne with value {0}", user);
        }

        public void update(int id, User newEntity)
        {
            Log.InfoFormat("Entering Modify with value {0}", id);

            var oldUser = findOne(id);
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "UPDATE userr SET " +
                "email = '" + newEntity.getEmail() +
                "',password = '" + newEntity.getPassword() +
                "',name = '" + newEntity.getName() +
                "',status = '" + newEntity.getStatus() +
                "'  WHERE userr.id ='" + id + "';";
                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting Remove with value {0}", oldUser);
        }

        public void delete(int id)
        {
            Log.InfoFormat("Entering Remove with value {0}", id);

            var user = findOne(id);
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "DELETE FROM userr WHERE userr.id = " + id + ";";
                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting Remove with value {0}", user);
        }

        public User getOne(string username, string password)
        {

            User user = null;
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from userr where userr.email = " + username + "and userr.password = " + password + ";";
                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        var name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        var status = dataReader.GetString(dataReader.GetOrdinal("status"));
                        UserStatus userStatus;
                        if (status == UserStatus.LOGGEDIN.ToString())
                        {
                            userStatus = UserStatus.LOGGEDIN;
                        }
                        else
                        {
                            userStatus = UserStatus.LOGGEDOUT;
                        }
                        user = new User(username, password, name, userStatus);
                        user.setId(id);
                    }
                }
            }
            return user;
        }

        public User setUserStatus(int id, UserStatus userStatus)
        {
            User user = findOne(id);

            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "UPDATE userr SET " +
                "status = '" + userStatus.ToString() +
                "'  WHERE userr.id ='" + id + "';";
                var result = command.ExecuteNonQuery();
            }
            return user;
        }
    }
}
