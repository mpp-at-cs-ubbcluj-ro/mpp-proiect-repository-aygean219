using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp.Repository
{
    public interface Repository<ID,E> where E: Domain.Entity<ID>
    {
        void findOne(ID id);
        List<E> findAll();
        void save(E entity);
        void update(E entity);
        void delete(ID id);
    }
}
