using ConsoleApp.Domain;
using ConsoleApp.Repository;
using ConsoleApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        static void Main()
        {
            UserDatabaseRepository userDatabaseRepository = new UserDatabaseRepository();
            DonorDatabaseRepository donorDatabaseRepository = new DonorDatabaseRepository();
            DonationDatabaseRepository donationDatabaseRepository = new DonationDatabaseRepository();
            CharityCaseDatabaseRepository charityCaseDatabaseRepository = new CharityCaseDatabaseRepository();
            Service service = new Service(userDatabaseRepository, donorDatabaseRepository, charityCaseDatabaseRepository, donationDatabaseRepository);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(service));
            

        }
    }
}
