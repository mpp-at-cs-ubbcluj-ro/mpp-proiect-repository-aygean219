using ConsoleApp.Domain;
using ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.InterfaceRepository
{
    public interface DonationRepository: Repository<int,Donation>
    {
        void removeDonation(int id1, int id2);
    }
}
