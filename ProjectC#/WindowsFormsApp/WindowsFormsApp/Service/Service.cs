using ConsoleApp.Domain;
using ConsoleApp.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service
{
    public class Service
    {
        private readonly UserRepository userRepository;
        private readonly DonorRepository donorRepository;
        private readonly CharityCaseRepository charityCaseRepository;
        private readonly DonationRepository donationRepository;

        public Service(UserRepository userRepository, DonorRepository donorRepository, CharityCaseRepository charityCaseRepository, DonationRepository donationRepository)
        {
            this.userRepository = userRepository;
            this.donationRepository = donationRepository;
            this.donorRepository = donorRepository;
            this.charityCaseRepository = charityCaseRepository;
        }

        public void logInUser(String email, String password)
        {
            User user = userRepository.getOne(email, password);
            if(user.getStatus().Equals(UserStatus.LOGGEDIN)){
            throw new Exception("Already logged in !!");
            }
            userRepository.setUserStatus(user.getId(),UserStatus.LOGGEDIN);
        }

        public void logOutUser(String email, String password)
        {
            User user = userRepository.getOne(email, password);
            if(user.getStatus().Equals(UserStatus.LOGGEDOUT)){
            throw new Exception("Already logged out !!");
            }
            userRepository.setUserStatus(user.getId(),UserStatus.LOGGEDOUT);
        }

        public void signUpUser(String email, String password, String name)
        {
           userRepository.save(new User(email, password, name, UserStatus.LOGGEDIN));
        }

        public Donor addDonor(String name, String phone, String address, int donated_sum)
        {
            Donor donor = new Donor(name, phone, address, donated_sum);
            if(donor.Equals(null)){
            throw new Exception("Null donor");
            }
            donorRepository.save(new Donor(name, phone, address, donated_sum));
            return donorRepository.getDonor(name, phone, address, donated_sum);
        }

        public void addDonation(int idCharityCase, String name, String phone, String address,int donated_sum)
        {
            Donor donor = addDonor(name, phone, address, donated_sum);
            CharityCase charityCase = charityCaseRepository.findOne(idCharityCase);
            donationRepository.save(new Donation(charityCase, donor));
            charityCaseRepository.addDonation(idCharityCase, donated_sum);
        }

        public void deleteDonation(int idCharityCase, int id)
        {
            Donor donor = donorRepository.findOne(id);
            CharityCase charityCase = charityCaseRepository.findOne(idCharityCase);
            charityCaseRepository.removeDonation(charityCase.getId(),donor.getDonated_sum());
            donationRepository.removeDonation(idCharityCase, id);
            donorRepository.delete(id);
        }

        public void addCharityCase(String name)
        {
            List<Donor> listDonors =new List<Donor>();
            CharityCase charityCase = new CharityCase(name, listDonors, 0);
            charityCaseRepository.save(charityCase);
        }

        public void deleteCharityCase(int id)
        {
            charityCaseRepository.delete(id);
        }

        public List<CharityCase> getCharityCases()
        {
            List<CharityCase> all = charityCaseRepository.findAll();
            return all;
        }
        
        public CharityCase GetCharityCase(int id)
        {
            return charityCaseRepository.findOne(id);
        }

        public List<Donor> getAllDonors()
        {
            List<Donor> all = donorRepository.findAll();
            return all;
        }

        public Donor getDonor(int id)
        {
            return donorRepository.findOne(id);
        }

        public User getLoggetUser(String email,String password)
        {
            return userRepository.getOne(email, password);
        }
    }
}
