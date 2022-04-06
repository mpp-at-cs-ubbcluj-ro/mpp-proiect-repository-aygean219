﻿using ConsoleApp.Domain;
using ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.InterfaceRepository
{
    public interface DonorRepository : Repository<int,Donor>
    {
        Donor getDonor(String name, String phone, String address, int donated_sum);
    }
}
