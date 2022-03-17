import Domain.CharityCase;
import Domain.Donor;
import Domain.User;
import Domain.UserStatus;
import Repository.CharityCaseDatabaseRepository;
import Repository.DonorDatabaseRepository;
import Repository.UserDatabaseRepository;

import java.io.FileReader;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class Main {
    public static void main(String[] args) {

        Properties props = new Properties();
        try {
            props.load(new FileReader("db.properties"));
        } catch (IOException e) {
            System.out.println("Cannot find bd.config " + e);
        }

        UserDatabaseRepository userDatabaseRepository = new UserDatabaseRepository(props);
        DonorDatabaseRepository donorDatabaseRepository = new DonorDatabaseRepository(props);
        CharityCaseDatabaseRepository charityCaseDatabaseRepository = new CharityCaseDatabaseRepository(props);
        User user1 = new User("nurlaay@yahoo.com","aygean","Nurla Aygean", UserStatus.LOGGEDIN);
        User user2 = new User("mama@yahoo.com","mama","mama", UserStatus.LOGGEDIN);
        Donor donor1 = new Donor("aa","00","bb",10);
        Donor donor2 = new Donor("cc","11","dd",20);
        List<Donor> list1 = new ArrayList<>();
        list1.add(donor1);
        //list1.add(donor2);
        CharityCase charityCase1= new CharityCase("charity1",list1,20);
        try{
            //userDatabaseRepository.add(user1);
            //userDatabaseRepository.update(1,user2);
            //userDatabaseRepository.remove(1);
            //donorDatabaseRepository.add(donor1);
            //donorDatabaseRepository.update(1,donor2);
            //donorDatabaseRepository.remove(1);
            //charityCaseDatabaseRepository.add(charityCase1);
            System.out.println(charityCaseDatabaseRepository.getOne(1).getTotalSum());
        }catch (Exception exception){
            System.out.println("Error");
        }
    }
}
