using ConsoleApp.Domain;
using ConsoleApp.InterfaceRepository;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repository
{
    public class DonorDatabaseRepository : DonorRepository
    {
        private static readonly ILog Log = LogManager.GetLogger("DonorDatabaseRepository");

        public DonorDatabaseRepository()
        {
            Log.Info("Creating DonorDatabaseRepository");
        }

        public List<Donor> findAll()
        {
            Log.Info("Entering GetAll");

            var donors = new List<Donor>();
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from donor;";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        var phone = dataReader.GetString(dataReader.GetOrdinal("phone"));
                        var name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        var address = dataReader.GetString(dataReader.GetOrdinal("address"));
                        var donated_sum = dataReader.GetInt32(dataReader.GetOrdinal("donated_sum"));
                        var donor = new Donor(name, phone, address, donated_sum);
                        donor.setId(id);
                        donors.Add(donor);
                    }
                }
            }
            Log.InfoFormat("Exiting GetAll with values {0}", donors);
            return donors;
        }

        public Donor findOne(int id)
        {
            Log.InfoFormat("Entering GetOne with value {0}", id);

            Donor donor = null ;
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from donor where donor.id = " + id + ";";
                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        var phone = dataReader.GetString(dataReader.GetOrdinal("phone"));
                        var name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        var address = dataReader.GetString(dataReader.GetOrdinal("address"));
                        var donated_sum = dataReader.GetInt32(dataReader.GetOrdinal("donated_sum"));
                        donor = new Donor(name, phone, address, donated_sum);
                        donor.setId(id);
                    }
                }
            }
            return donor;
        }

        public void save(Donor donor)
        {
            Log.InfoFormat("Entering Add with value {0}", donor);

            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText =
                    "INSERT INTO donor(name,phone,address,donated_sum) VALUES (@name,@phone,@address,@donated_sum);";

                var dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@name";
                dataParameter.Value = donor.getName();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@phone";
                dataParameter.Value = donor.getPhone();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@address";
                dataParameter.Value = donor.getAddress();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@donated_sum";
                dataParameter.Value = donor.getDonated_sum();
                command.Parameters.Add(dataParameter);

                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting getOne with value {0}", donor);
        }

        public void update(int id, Donor newEntity)
        {
            Log.InfoFormat("Entering Modify with value {0}", id);

            var oldDonor = findOne(id);
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "UPDATE donor SET " +
                "name = '" + newEntity.getName() +
                "',phone = '" + newEntity.getPhone() +
                "',address = '" + newEntity.getAddress() +
                "',donated_sum = '" + newEntity.getDonated_sum() +
                "'  WHERE donor.id ='" + id + "';";
                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting Remove with value {0}", oldDonor);
        }
        public void delete(int id)
        {
            Log.InfoFormat("Entering Remove with value {0}", id);

            var donor = findOne(id);
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "DELETE FROM donor WHERE donor.id = " + id + ";";
                var result = command.ExecuteNonQuery();
            }

            Log.InfoFormat("Exiting Remove with value {0}", donor);
        }

        public Donor getDonor(string name, string phone, string address, int donated_sum)
        {
            Donor donor = null;
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from donor where donor.phone = '" + phone + "' and donor.donated_sum = " + donated_sum + ";";
                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        var id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        donor = new Donor(name, phone, address, donated_sum);
                        donor.setId(id);
                    }
                }
            }
            return donor;
        }


    }
}
