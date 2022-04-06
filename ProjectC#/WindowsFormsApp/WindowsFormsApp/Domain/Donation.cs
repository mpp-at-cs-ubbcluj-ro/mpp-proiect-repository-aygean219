using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Domain
{
    public class Donation:Entity<int>
    {
        private CharityCase charityCase;
        private Donor donor;

        public Donation(CharityCase charityCase, Donor donor)
        {
            this.charityCase = charityCase;
            this.donor = donor;
        }

        public CharityCase getCharityCase()
        {
            return charityCase;
        }

        public void setCharityCase(CharityCase charityCase)
        {
            this.charityCase = charityCase;
        }

        public Donor getDonor()
        {
            return donor;
        }

        public void setDonor(Donor donor)
        {
            this.donor = donor;
        }
    }
}
