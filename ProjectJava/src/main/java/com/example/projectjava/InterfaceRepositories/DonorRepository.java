package com.example.projectjava.InterfaceRepositories;


import com.example.projectjava.Domain.Donor;

public interface DonorRepository extends Repository<Integer, Donor>{
    Donor getDonor(String name,String phone,String address,Integer donated_sum) throws Exception;
}
