using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Domain
{
    public class Donor:Entity<int>
    {
        private String name;
        private String phone;
        private String address;
        private int donated_sum;

        public Donor(String name, String phone, String address, int donated_sum)
        {
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.donated_sum = donated_sum;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            name = name;
        }

        public String getPhone()
        {
            return phone;
        }

        public void setPhone(String phone)
        {
            this.phone = phone;
        }

        public String getAddress()
        {
            return address;
        }

        public void setAddress(String address)
        {
            this.address = address;
        }

        public int getDonated_sum()
        {
            return donated_sum;
        }

        public void setDonated_sum(int donated_sum)
        {
            this.donated_sum = donated_sum;
        }

    }
}
