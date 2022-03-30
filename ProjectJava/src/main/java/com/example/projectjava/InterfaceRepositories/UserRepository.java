package com.example.projectjava.InterfaceRepositories;


import com.example.projectjava.Domain.*;

public interface UserRepository extends Repository<Integer, User> {

    User getOne(String username,String password) throws Exception;

    User setUserStatus(Integer id, UserStatus userStatus) throws Exception;
}
