package com.example.projectjava.InterfaceRepositories;


import com.example.projectjava.Domain.CharityCase;

public interface CharityCaseRepository extends Repository<Integer, CharityCase> {

    void updateSumOfTotalDonations(int idCharityCase,int donation) throws Exception;

    void removeDonation(int id,int donation) throws Exception;
}
