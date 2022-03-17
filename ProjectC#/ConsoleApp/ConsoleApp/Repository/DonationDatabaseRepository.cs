using ConsoleApp.Domain;
using ConsoleApp.InterfaceRepository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repository
{
    public class DonationDatabaseRepository : DonationRepository
    {
        private static readonly ILog Log = LogManager.GetLogger("DonationDatabaseRepository");

        public DonationDatabaseRepository()
        {
            Log.Info("Creating DonationDatabaseRepository");
        }
        public List<Donation> findAll()
        {
            throw new NotImplementedException();
        }

        public Donation findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Donation donor)
        {
            Log.InfoFormat("Entering Add with value {0}", donor);

            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText =
                    "INSERT INTO donation(idCharityCase,idDonor) VALUES (@id1,@id2);";

                var dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@id1";
                dataParameter.Value = donor.getCharityCase().getId();
                command.Parameters.Add(dataParameter);

                dataParameter = command.CreateParameter();
                dataParameter.ParameterName = "@id2";
                dataParameter.Value = donor.getDonor().getId();
                command.Parameters.Add(dataParameter);

                var result = command.ExecuteNonQuery();
            }

        }

        public void update(int id, Donation newEntity)
        {
            Log.InfoFormat("Entering Modify with value {0}", id);

            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
            {
                connection.Open(); command.CommandText = "UPDATE donation SET " +
                "idCharityCase = '" + newEntity.getCharityCase().getId() +
                "',idDonor = '" + newEntity.getDonor().getId() +
                "'  WHERE donation.id ='" + id + "';";
                var result = command.ExecuteNonQuery();
            }

        }

        public void delete(int id)
        {
            Log.InfoFormat("Entering Remove with value {0}", id);

            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection("Data source = C:\\Users\\skump\\MPP_Project\\database\\CharityDatabase.db");
            using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(connection))
            {
                connection.Open();
                command.CommandText = "DELETE FROM donation WHERE donation.id = " + id + ";";
                var result = command.ExecuteNonQuery();
            }
        }
    }
}
