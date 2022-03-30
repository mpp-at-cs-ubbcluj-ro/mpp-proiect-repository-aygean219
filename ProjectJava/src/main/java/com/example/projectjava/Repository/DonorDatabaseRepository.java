package com.example.projectjava.Repository;

import com.example.projectjava.Domain.Donor;
import com.example.projectjava.InterfaceRepositories.DonorRepository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class DonorDatabaseRepository implements DonorRepository {
    private final JdbcUtils dbUtils;
    private static final Logger logger= LogManager.getLogger();

    public DonorDatabaseRepository(Properties properties) {
        logger.info("Initializing DonorDatabaseRepository with properties: {}",properties);
        dbUtils = new JdbcUtils(properties);
    }

    @Override
    public Iterable<Donor> getAll() {
        logger.traceEntry();

        Connection connection = dbUtils.getConnection();
        List<Donor> donorsList = new ArrayList<>();
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM donor;")){
            try(ResultSet result = preparedStatement.executeQuery()){
                while(result.next()){
                    Integer donorId = result.getInt("id");
                    String address = result.getString("address");
                    String phone = result.getString("phone");
                    String name = result.getString("name");
                    Integer donated_sum = result.getInt("donated_sum");
                    Donor donor = new Donor(name,phone,address,donated_sum);
                    donor.setId(donorId);
                    donorsList.add(donor);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return donorsList;
    }

    @Override
    public Donor getOne(Integer id) throws Exception {
        logger.traceEntry();

        Connection connection = dbUtils.getConnection();
        Donor  donor=null;
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM donor WHERE donor.id = " + id + ";")){
            try(ResultSet result = preparedStatement.executeQuery()){
                if(result.next()){
                    String address = result.getString("address");
                    String phone = result.getString("phone");
                    String name = result.getString("name");
                    Integer donated_sum = result.getInt("donated_sum");
                    donor = new Donor(name,phone,address,donated_sum);
                    donor.setId(id);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return donor;
    }

    @Override
    public Donor add(Donor entity) throws Exception {
        logger.traceEntry();
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement=connection.prepareStatement("INSERT INTO donor(name,phone,address,donated_sum) VALUES (?,?,?,?);")){
            preparedStatement.setString(1,entity.getName());
            preparedStatement.setString(2,entity.getPhone());
            preparedStatement.setString(3,entity.getAddress());
            preparedStatement.setInt(4,entity.getDonated_sum());
            int result = preparedStatement.executeUpdate();
            logger.trace("Saved {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return entity;
    }

    @Override
    public Donor remove(Integer id) throws Exception {
        logger.traceEntry("Removing donor with id {}",id);
        Donor donor = getOne(id);
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("DELETE FROM donor WHERE donor.id = " + id+ ";")){
            int result = preparedStatement.executeUpdate();
            logger.trace("Deleted {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        return donor;
    }

    @Override
    public Donor update(Integer id, Donor newEntity) throws Exception {
        logger.traceEntry("Modifying donor with id  {}",id);
        Donor oldDonor = getOne(id);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("UPDATE donor SET " +
                "name = '" + newEntity.getName() +
                "',phone = '"+ newEntity.getPhone()+
                "',address = '" + newEntity.getAddress() +
                "',donated_sum = '" + newEntity.getDonated_sum()+
                "'  WHERE donor.id ='" + id + "';"
        )){
            int result = preparedStatement.executeUpdate();
            logger.trace("Modified {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return oldDonor;
    }

    @Override
    public Donor getDonor(String name, String phone, String address, Integer donated_sum) throws Exception {
        logger.traceEntry();

        Connection connection = dbUtils.getConnection();
        Donor  donor=null;
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM donor WHERE donor.name = '" + name +
                "'AND donor.phone = '" +phone +"' AND donor.donated_sum = '"+ donated_sum+ "';")){
            try(ResultSet result = preparedStatement.executeQuery()){
                if(result.next()){
                    Integer id = result.getInt("id");
                    donor = new Donor(name,phone,address,donated_sum);
                    donor.setId(id);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return donor;
    }
}
