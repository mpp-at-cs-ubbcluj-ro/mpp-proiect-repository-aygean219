using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Domain
{
    public class CharityCase:Entity<int>
    {
        private String name;
        private List<Donor> donors;
        private int totalSum;

        public CharityCase(String name, List<Donor> donors, int totalSum)
        {
            this.name = name;
            this.donors = donors;
            this.totalSum = totalSum;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            name = name;
        }

        public List<Donor> getDonors()
        {
            return donors;
        }

        public void setDonors(List<Donor> donors)
        {
            this.donors = donors;
        }

        public int getTotalSum()
        {
            return totalSum;
        }

        public void setTotalSum(int totalSum)
        {
            this.totalSum = totalSum;
        }
    }
}
