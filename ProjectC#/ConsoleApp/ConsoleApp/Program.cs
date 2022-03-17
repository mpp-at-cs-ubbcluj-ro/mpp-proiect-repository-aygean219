using ConsoleApp.Domain;
using ConsoleApp.Repository;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            UserDatabaseRepository userDatabaseRepository = new UserDatabaseRepository();
            userDb.save(new User("33", "44", "55", UserStatus.LOGGEDIN));
            List<User> list = userDatabaseRepository.findAll();
            foreach (User u in list)
            {
                Console.Out.WriteLine("USER EMAIL FIRST TIME: " + u.getEmail());

            }
            userDatabaseRepository.update(1, new User("77", "44", "55", UserStatus.LOGGEDIN));
            list = userDatabaseRepository.findAll();
            foreach (User u in list)
            {
                Console.Out.WriteLine("USER EMAIL SECOND TIME: " + u.getEmail());

            }
            userDatabaseRepository.delete(1);
            list = userDatabaseRepository.findAll();
            foreach (User u in list)
            {
                Console.Out.WriteLine("USER EMAIL FINAL: " + u.getEmail());

            }*/

            /*DonorDatabaseRepository donorDatabaseRepository = new DonorDatabaseRepository();
            donorDatabaseRepository.save(new Donor("Ana", "07188383", "cluj", 10));
            List<Donor> listDonors = donorDatabaseRepository.findAll();
            foreach(Donor d in listDonors)
            {
                Console.Out.WriteLine("DONORS 1 TIME: " + d.getName());
            }
            donorDatabaseRepository.update(1, new Donor("AnaMaria", "07188383", "cluj", 230));
            listDonors = donorDatabaseRepository.findAll();
            foreach (Donor d in listDonors)
            {
                Console.Out.WriteLine("DONORS 2 TIME: " + d.getName());
            }
            donorDatabaseRepository.delete(1);
            listDonors = donorDatabaseRepository.findAll();
            foreach (Donor d in listDonors)
            {
                Console.Out.WriteLine("DONORS 3 TIME: " + d.getName());
            }*/

         


        }
    }
}
