﻿using ConsoleApp.Domain;
using ConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.InterfaceRepository
{
    public interface UserRepository : Repository<int,User>
    {
        User getOne(String username, String password);
        User setUserStatus(int id, UserStatus userStatus);
    }
}
