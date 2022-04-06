using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Domain
{
    public abstract class Entity<ID>
    {
        private ID id;

        public ID getId()
        {
            return id;
        }

        public void setId(ID id)
        {
            this.id = id;
        }
    }
}
