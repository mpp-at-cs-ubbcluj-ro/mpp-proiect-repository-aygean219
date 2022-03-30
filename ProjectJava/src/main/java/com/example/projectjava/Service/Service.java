package com.example.projectjava.Service;


import com.example.projectjava.Domain.*;
import com.example.projectjava.Repository.CharityCaseDatabaseRepository;
import com.example.projectjava.Repository.DonationDatabaseRepository;
import com.example.projectjava.Repository.DonorDatabaseRepository;
import com.example.projectjava.Repository.UserDatabaseRepository;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.StreamSupport;

public class Service {

    private final UserDatabaseRepository userDatabaseRepository ;
    private final DonorDatabaseRepository donorDatabaseRepository ;
    private final CharityCaseDatabaseRepository charityCaseDatabaseRepository;
    private final DonationDatabaseRepository donationDatabaseRepository;

    public Service(UserDatabaseRepository userDatabaseRepository, DonorDatabaseRepository donorDatabaseRepository, CharityCaseDatabaseRepository charityCaseDatabaseRepository, DonationDatabaseRepository donationDatabaseRepository) {
        this.userDatabaseRepository = userDatabaseRepository;
        this.donorDatabaseRepository = donorDatabaseRepository;
        this.charityCaseDatabaseRepository = charityCaseDatabaseRepository;
        this.donationDatabaseRepository = donationDatabaseRepository;
    }

    public void logInUser(String email,String password) throws Exception{
        User user = userDatabaseRepository.getOne(email,password);
        if(user.getStatus().equals(UserStatus.LOGGEDIN)){
            throw new Exception("Already logged in !!");
        }
        userDatabaseRepository.setUserStatus(user.getId(),UserStatus.LOGGEDIN);
    }

    public void logOutUser(String email,String password) throws Exception{
        User user = userDatabaseRepository.getOne(email,password);
        if(user.getStatus().equals(UserStatus.LOGGEDOUT)){
            throw new Exception("Already logged out !!");
        }
        userDatabaseRepository.setUserStatus(user.getId(),UserStatus.LOGGEDOUT);
    }

    public void signUpUser(String email,String password,String name)throws Exception{
        User user = userDatabaseRepository.add(new User(email,password,name,UserStatus.LOGGEDIN));

    }

    public User deleteUser(Integer id) throws Exception{
        User user = userDatabaseRepository.remove(id);
        return user;
    }

    public User updateUser(Integer id,String email,String password,String name) throws Exception{
        User user = userDatabaseRepository.update(id,new User(email,password,name,UserStatus.LOGGEDIN));
        return user;
    }

    public Donor addDonor(String name,String phone,String address,Integer donated_sum) throws Exception{
        Donor donor = new Donor(name,phone,address,donated_sum);
        if(donor.equals(null)){
            throw new Exception("Null donor");
        }
        donorDatabaseRepository.add(new Donor(name,phone,address,donated_sum));
        return donorDatabaseRepository.getDonor(name,phone,address,donated_sum);
    }

    public void deleteDonor(Integer id) throws Exception{
        donorDatabaseRepository.remove(id);
    }

    public Donor updateDonor(Integer id,String name,String phone,String address,Integer donated_sum) throws Exception{
        Donor donor = new Donor(name,phone,address,donated_sum);
        if(donor.equals(null)){
            throw new Exception("Null donor");
        }
        return donorDatabaseRepository.update(id,donor);
    }

    public CharityCase addCharityCase(String name)throws Exception {
        List<Donor> listDonors =new ArrayList<>();
        CharityCase charityCase = new CharityCase(name,listDonors,0);
        return charityCaseDatabaseRepository.add(charityCase);
    }

    public void deleteCharityCase(Integer id) throws Exception{
        charityCaseDatabaseRepository.remove(id);
    }

    public void addDonation(Integer idCharityCase,String name,String phone,String address,Integer donated_sum)throws Exception{
        Donor donor =addDonor(name,phone,address,donated_sum);
        CharityCase charityCase = charityCaseDatabaseRepository.getOne(idCharityCase);
        donationDatabaseRepository.add(new Donation(charityCase,donor));
        charityCaseDatabaseRepository.updateSumOfTotalDonations(idCharityCase,donated_sum);
    }

    public void deleteDonation(Integer idCharityCase,Integer id)throws Exception{
        Donor donor = donorDatabaseRepository.getOne(id);
        CharityCase charityCase = charityCaseDatabaseRepository.getOne(idCharityCase);
        charityCaseDatabaseRepository.removeDonation(charityCase.getId(),donor.getDonated_sum());
        donationDatabaseRepository.remove(id);
    }

    public List<CharityCase> getAllCharityCases(){
        Iterable<CharityCase> all = charityCaseDatabaseRepository.getAll();
        return StreamSupport.stream(all.spliterator(), false)
                .collect(Collectors.toList());
    }

    public List<Donor> getAllDonors(){
        Iterable<Donor> all = donorDatabaseRepository.getAll();
        return StreamSupport.stream(all.spliterator(), false)
                .collect(Collectors.toList());
    }

    public User getLoggedUser(String email,String password) throws Exception{
        return userDatabaseRepository.getOne(email,password);
    }
}
