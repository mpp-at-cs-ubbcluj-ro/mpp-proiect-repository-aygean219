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
            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText = "select * from user;";

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
            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText = "select * from user where user.id = " + id + ";";
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
            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText =
                    "INSERT INTO user(email,password,name,status) VALUES (@email,@password,@name,@status);";

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

        public void update(int id,User newEntity)
        {
            Log.InfoFormat("Entering Modify with value {0}", id);

            var oldUser = findOne(id);
            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText = "UPDATE user SET " +
                "email = '" + newEntity.getEmail() +
                "',password = '" + newEntity.getPassword() +
                "',name = '" + newEntity.getName() +
                "',status = '" + newEntity.getStatus() +
                "'  WHERE user.id ='" + id + "';";
                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting Remove with value {0}", oldUser);
        }

        public void delete(int id)
        {
           Log.InfoFormat("Entering Remove with value {0}", id);

            var user = findOne(id);
            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText = "DELETE FROM user WHERE user.id = " + id + ";";
                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting Remove with value {0}", user);
        }
    }
}
