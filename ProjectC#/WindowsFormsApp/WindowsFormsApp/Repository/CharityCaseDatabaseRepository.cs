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
    public class CharityCaseDatabaseRepository : CharityCaseRepository
    {
        private static readonly ILog Log = LogManager.GetLogger("CharityCaseDatabaseRepository");
        
        public CharityCaseDatabaseRepository()
        {
            Log.Info("Creating CharityCaseDatabaseRepository");
        }


        public List<CharityCase> findAll()
        {
            Log.InfoFormat("Entering findall with value {0}");
            List<CharityCase> charityCases = new List<CharityCase>();

            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from charityCase;";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var idCharityCase = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        var nameCharityCase = dataReader.GetString(dataReader.GetOrdinal("name"));
                        var totalSum = dataReader.GetInt32(dataReader.GetOrdinal("totalSum"));

                        //Donors ids
                        List<int> idListInt = new List<int>();
                        using (SqlConnection connection2 = new SqlConnection(connectionString))
                        {
                            SqlCommand command2 = new SqlCommand();
                            command2.Connection = connection2;
                            connection2.Open();
                            command2.CommandText = "SELECT * FROM donation WHERE donation.idCharityCase = = " + idCharityCase + ";";
                            var dataParameter = command2.CreateParameter();
                            dataParameter.ParameterName = "@idCharity";
                            dataParameter.Value = idCharityCase;
                            command.Parameters.Add(dataParameter);
                            
                            using(var dataReader2 = command2.ExecuteReader())
                            {
                                while (dataReader2.Read())
                                {
                                    int idDonor = dataReader2.GetInt32(dataReader2.GetOrdinal("idDonor"));
                                    idListInt.Add(idDonor);

                                }
                            }
                        }

                        //Donors
                        List<Donor> donors = new List<Donor>();
                        using (SqlConnection connection3 = new SqlConnection(connectionString))
                        {
                            
                            foreach (int id in idListInt)
                            {
                                SqlCommand command3 = new SqlCommand();
                                command3.Connection = connection3;
                                connection3.Open();
                                command3.CommandText = "SELECT * FROM donor WHERE donor.id = " + id + ";";
                                var dataParameter = command3.CreateParameter();
                                dataParameter.ParameterName = "@idd";
                                dataParameter.Value = id;
                                command.Parameters.Add(dataParameter);
                                using (var dataReader3 = command3.ExecuteReader())
                                {
                                    while (dataReader3.Read())
                                    {
                                        var phone = dataReader3.GetString(dataReader3.GetOrdinal("phone"));
                                        var name = dataReader3.GetString(dataReader3.GetOrdinal("name"));
                                        var address = dataReader3.GetString(dataReader3.GetOrdinal("address"));
                                        var donated_sum = dataReader3.GetInt32(dataReader3.GetOrdinal("donated_sum"));
                                        var donor = new Donor(name, phone, address, donated_sum);
                                        donor.setId(id);
                                        donors.Add(donor);

                                    }
                                }
                            }
                            
                        }
                        CharityCase charityCase = new CharityCase(nameCharityCase, donors, totalSum);
                        charityCase.setId(idCharityCase);
                        charityCases.Add(charityCase);

                    }
                }
            }
            return charityCases;
        }

        public CharityCase findOne(int id)
        {
            Log.InfoFormat("Entering findOne with value {0}");
            CharityCase charityCase = null;

            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select * from charityCase where charityCase.id = " + id + ";" ;
                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        var idCharityCase = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        var nameCharityCase = dataReader.GetString(dataReader.GetOrdinal("name"));
                        var totalSum = dataReader.GetInt32(dataReader.GetOrdinal("totalSum"));

                        //Donors ids
                        List<int> idListInt = new List<int>();
                        using (SqlConnection connection2 = new SqlConnection(connectionString))
                        {
                            SqlCommand command2 = new SqlCommand();
                            command2.Connection = connection2;
                            connection2.Open();
                            command2.CommandText = "SELECT * FROM donation WHERE donation.idCharityCase = " +idCharityCase + ";";
                            //var dataParameter = command2.CreateParameter();
                            //dataParameter.ParameterName = "@idCharity";
                            //dataParameter.Value = idCharityCase;
                            //command.Parameters.Add(dataParameter);

                            using (var dataReader2 = command2.ExecuteReader())
                            {
                                while (dataReader2.Read())
                                {
                                    int idDonor = dataReader2.GetInt32(dataReader2.GetOrdinal("idDonor"));
                                    idListInt.Add(idDonor);

                                }
                            }
                        }

                        //Donors
                        List<Donor> donors = new List<Donor>();
                        using (SqlConnection connection3 = new SqlConnection(connectionString))
                        {

                            foreach (int idDonor in idListInt)
                            {
                                SqlCommand command3 = new SqlCommand();
                                command3.Connection = connection3;
                                connection3.Open();
                                command3.CommandText = "SELECT * FROM donor WHERE donor.id = " + idDonor + ";";
                                //var dataParameter = command3.CreateParameter();
                                //dataParameter.ParameterName = "@idd";
                                //dataParameter.Value = idDonor;
                                //command.Parameters.Add(dataParameter);
                                using (var dataReader3 = command3.ExecuteReader())
                                {
                                    while (dataReader3.Read())
                                    {
                                        var phone = dataReader3.GetString(dataReader3.GetOrdinal("phone"));
                                        var name = dataReader3.GetString(dataReader3.GetOrdinal("name"));
                                        var address = dataReader3.GetString(dataReader3.GetOrdinal("address"));
                                        var donated_sum = dataReader3.GetInt32(dataReader3.GetOrdinal("donated_sum"));
                                        var donor = new Donor(name, phone, address, donated_sum);
                                        donor.setId(idDonor);
                                        donors.Add(donor);

                                    }
                                }
                                connection3.Close();    
                            }

                        }
                        charityCase = new CharityCase(nameCharityCase, donors, totalSum);
                        charityCase.setId(id);

                    }
                }
            }
            
            return charityCase;
        }

        public void save(CharityCase charityCase)
        {
            Log.InfoFormat("Entering Add with value {0}", charityCase);

            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText =
                    "INSERT INTO charityCase(name,totalSum) VALUES (@name,@totalSum);";

                var dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@name";
                dataParameter.Value = charityCase.getName();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@totalSum";
                dataParameter.Value = charityCase.getTotalSum();
                command.Parameters.Add(dataParameter);

                var result = command.ExecuteNonQuery();
            }

        }

        public void update(int id, CharityCase newEntity)
        {
            Log.InfoFormat("Entering Modify with value {0}", id);

            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "UPDATE charityCase SET " +
                "name = '" + newEntity.getName() +
                "',totalSum = '" + newEntity.getTotalSum() +
                "'  WHERE charityCase.id ='" + id + "';";
                var result = command.ExecuteNonQuery();
            }

        }
        public void delete(int id)
        {
            Log.InfoFormat("Entering Remove with value {0}", id);

            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "DELETE FROM charityCase WHERE charityCase.id = " + id + ";";
                var result = command.ExecuteNonQuery();
            }

        }

        public void addDonation(int idCharityCase, int donation)
        {
            CharityCase charityCase = findOne(idCharityCase);
            int oldSum = charityCase.getTotalSum();
            int newSum = oldSum + donation;
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "UPDATE charityCase SET " +
                "totalSum = '" + newSum +
                "'  WHERE charityCase.id ='" + idCharityCase + "';";
                var result = command.ExecuteNonQuery();
            }
        }

        public void removeDonation(int idCharityCase, int donation)
        {
            CharityCase charityCase = findOne(idCharityCase);
            int oldSum = charityCase.getTotalSum();
            int newSum = oldSum - donation;
            string connectionString = "Data Source=LAPTOP-ON333H5E\\SQLEXPRESS;Initial Catalog=charityCaseSQLDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = "UPDATE charityCase SET " +
                "totalSum = '" + newSum +
                "'  WHERE charityCase.id ='" + idCharityCase + "';";
                var result = command.ExecuteNonQuery();
            }
        }
    }
}
