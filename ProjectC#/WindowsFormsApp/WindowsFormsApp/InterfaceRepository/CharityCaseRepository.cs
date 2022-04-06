using ConsoleApp.Domain;
using ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.InterfaceRepository
{
    public interface CharityCaseRepository: Repository<int,CharityCase>
    {
        void addDonation(int idCharityCase, int donation);
        void removeDonation(int idCharityCase, int donation);
    }
}
