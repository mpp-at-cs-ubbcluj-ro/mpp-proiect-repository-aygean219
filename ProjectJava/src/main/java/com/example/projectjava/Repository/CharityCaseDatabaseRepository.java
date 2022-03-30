package com.example.projectjava.Repository;

import com.example.projectjava.Domain.CharityCase;
import com.example.projectjava.Domain.Donor;
import com.example.projectjava.InterfaceRepositories.CharityCaseRepository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class CharityCaseDatabaseRepository implements CharityCaseRepository {
    private final JdbcUtils dbUtils;
    private static final Logger logger= LogManager.getLogger();

    public CharityCaseDatabaseRepository(Properties properties) {
        logger.info("Initializing CharityCaseDatabaseRepository with properties: {}",properties);
        dbUtils = new JdbcUtils(properties);
    }

    @Override
    public Iterable<CharityCase> getAll() {
        logger.traceEntry();

        Connection connection = dbUtils.getConnection();
        List<CharityCase> charityCasesList = new ArrayList<>();
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM charityCase;")){
            try(ResultSet result = preparedStatement.executeQuery()){
                while(result.next()){
                    Integer charityId = result.getInt("id");
                    String name = result.getString("name");
                    Integer totalSum = result.getInt("totalSum");
                    List<Integer> listDonors= new ArrayList<>();

                    ///list of ids of donors
                    try(PreparedStatement preparedStatement1 = connection.prepareStatement("SELECT * FROM donation WHERE donation.idCharityCase = ?;"))
                    {
                        preparedStatement1.setInt(1,charityId);
                        try(ResultSet result1 =preparedStatement1.executeQuery()){
                            while(result1.next()){
                                Integer idDonor = result1.getInt("id");
                                listDonors.add(idDonor);
                            }
                        }
                    }catch (SQLException exception){
                        logger.error(exception);}

                    //list of donors
                    List<Donor> donors= new ArrayList<>();
                    for (Integer donor : listDonors) {
                        try(PreparedStatement preparedStatement2 = connection.prepareStatement("SELECT * FROM donor WHERE donor.id = ?;"))
                        {
                            preparedStatement2.setInt(1, donor);
                            ResultSet resultSet2 = preparedStatement2.executeQuery();
                            Donor donorExtracted = null;
                            if(resultSet2.next()){
                                String address = resultSet2.getString("address");
                                String phone = resultSet2.getString("phone");
                                String name2 = resultSet2.getString("name");
                                Integer donated_sum = resultSet2.getInt("donated_sum");
                                donorExtracted = new Donor(name2,phone,address,donated_sum);
                                donorExtracted.setId(donor);
                            }
                            donors.add(donorExtracted);
                        }catch (SQLException exception){
                            logger.error(exception);}
                    }
                    CharityCase charityCase = new CharityCase(name,donors,totalSum);
                    charityCase.setId(charityId);
                    charityCasesList.add(charityCase);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return charityCasesList;
    }

    @Override
    public CharityCase getOne(Integer id) throws Exception {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        CharityCase charityCase = null;
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM charityCase WHERE charityCase.id = ?;")){
            preparedStatement.setInt(1,id);
            try(ResultSet result = preparedStatement.executeQuery()){
                if(result.next()){
                    String name = result.getString("name");
                    Integer totalSum = result.getInt("totalSum");
                    List<Integer> listDonors= new ArrayList<>();

                    ///list of ids of donors
                    try(PreparedStatement preparedStatement1 = connection.prepareStatement("SELECT * FROM donation WHERE donation.idCharityCase = ?;"))
                    {
                        preparedStatement1.setInt(1,id);
                        try(ResultSet result1 =preparedStatement1.executeQuery()){
                            while(result1.next()){
                                Integer idDonor = result1.getInt("id");
                                listDonors.add(idDonor);
                            }
                        }
                    }catch (SQLException exception){
                        logger.error(exception);}

                    //list of donors
                    List<Donor> donors= new ArrayList<>();
                    for (Integer donor : listDonors) {
                        try(PreparedStatement preparedStatement2 = connection.prepareStatement("SELECT * FROM donor WHERE donor.id = ?;"))
                        {
                            preparedStatement2.setInt(1, donor);
                            ResultSet resultSet2 = preparedStatement2.executeQuery();
                            Donor donorExtracted = null;
                            if(resultSet2.next()){
                                String address = resultSet2.getString("address");
                                String phone = resultSet2.getString("phone");
                                String name2 = resultSet2.getString("name");
                                Integer donated_sum = resultSet2.getInt("donated_sum");
                                donorExtracted = new Donor(name2,phone,address,donated_sum);
                                donorExtracted.setId(donor);
                            }
                            donors.add(donorExtracted);
                        }catch (SQLException exception){
                            logger.error(exception);}
                    }
                    charityCase = new CharityCase(name,donors,totalSum);
                    charityCase.setId(id);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return charityCase;
    }

    @Override
    public CharityCase add(CharityCase entity) throws Exception {
        logger.traceEntry();
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement=connection.prepareStatement("INSERT INTO charityCase(name,totalSum) VALUES (?,?);")){
            preparedStatement.setString(1,entity.getName());
            preparedStatement.setInt(2,entity.getTotalSum());
            int result = preparedStatement.executeUpdate();
            logger.trace("Saved {} instances",result);

        }catch (SQLException exception){
            logger.error(exception);
        }

        /*List<Donor> donors = entity.getDonors();
        for (Donor donor : donors) {
            try(PreparedStatement preparedStatement = connection.prepareStatement("INSERT INTO donation(idCharityCase,idDonor) VALUES (?,?)"))
                {
                    preparedStatement.setInt(1, entity.getId());
                    preparedStatement.setInt(2, donor.getId());
                    preparedStatement.executeUpdate();
                }catch (SQLException exception){
                logger.error(exception);}
        }*/
        logger.traceExit();
        return entity;
    }

    @Override
    public CharityCase remove(Integer id) throws Exception {
        logger.traceEntry("Removing donor with id {}",id);
        CharityCase charityCase = getOne(id);
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("DELETE FROM charityCase WHERE charityCase.id = " + id+ ";")){
            int result = preparedStatement.executeUpdate();
            logger.trace("Deleted {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        return charityCase;
    }

    @Override
    public CharityCase update(Integer id, CharityCase newEntity) throws Exception {
        logger.traceEntry("Modifying donor with id  {}",id);
        CharityCase oldCharityCase = getOne(id);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("UPDATE charityCase SET " +
                "name = '" + newEntity.getName() +
                "',totalSum = '"+ newEntity.getTotalSum()+
                "'  WHERE charityCase.id ='" + id + "';"
        )){
            int result = preparedStatement.executeUpdate();
            logger.trace("Modified {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return oldCharityCase;
    }

    @Override
    public void updateSumOfTotalDonations(int idCharityCase, int donation) throws Exception {
        logger.traceEntry("Modifying sum with id  {}",idCharityCase);
        CharityCase charityCaseOld = getOne(idCharityCase);
        Integer oldSum = charityCaseOld.getTotalSum();
        Integer newSum = oldSum +donation;
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("UPDATE charityCase SET " +
                "totalSum = "+ newSum+
                "  WHERE charityCase.id =" + idCharityCase + ";"
        )){
            int result = preparedStatement.executeUpdate();
            logger.trace("Modified {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
    }

    @Override
    public void removeDonation(int idCharityCase, int donation) throws Exception {
        logger.traceEntry("Modifying sum with id  {}",idCharityCase);
        CharityCase charityCaseOld = getOne(idCharityCase);
        Integer oldSum = charityCaseOld.getTotalSum();
        Integer newSum = oldSum - donation;
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("UPDATE charityCase SET " +
                "totalSum = "+ newSum+
                "  WHERE charityCase.id =" + idCharityCase + ";"
        )){
            int result = preparedStatement.executeUpdate();
            logger.trace("Modified {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
    }
}
