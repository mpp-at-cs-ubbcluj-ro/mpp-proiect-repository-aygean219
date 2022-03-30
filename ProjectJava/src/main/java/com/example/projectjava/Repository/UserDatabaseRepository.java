package com.example.projectjava.Repository;



import com.example.projectjava.Domain.*;
import com.example.projectjava.InterfaceRepositories.UserRepository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class UserDatabaseRepository implements UserRepository {
    private final JdbcUtils dbUtils;
    private static final Logger logger= LogManager.getLogger();

    public UserDatabaseRepository(Properties properties) {
        logger.info("Initializing UserDatabaseRepository with properties: {}",properties);
        dbUtils = new JdbcUtils(properties);
    }


    @Override
    public Iterable<User> getAll() {
        logger.traceEntry();

        Connection connection = dbUtils.getConnection();
        List<User> usersList = new ArrayList<>();
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM user;")){
            try(ResultSet result = preparedStatement.executeQuery()){
                while(result.next()){
                    Integer userId = result.getInt("id");
                    String email = result.getString("email");
                    String password = result.getString("password");
                    String name = result.getString("name");
                    String status = result.getString("status");
                    UserStatus status1;
                    if(status=="LOGGEDIN")
                        status1=UserStatus.LOGGEDIN;
                    else
                        status1=UserStatus.LOGGEDOUT;
                    User user = new User(email,password,name,status1);
                    user.setId(userId);
                    usersList.add(user);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return usersList;
    }

    @Override
    public User getOne(Integer id) throws Exception {
        logger.traceEntry();

        Connection connection = dbUtils.getConnection();
        User  user=null;
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM user WHERE user.id = " + id + ";")){
            try(ResultSet result = preparedStatement.executeQuery()){
                if(result.next()){
                    String email = result.getString("email");
                    String password = result.getString("password");
                    String name = result.getString("name");
                    String status = result.getString("status");
                    UserStatus status1;
                    if(status.equals("LOGGEDIN"))
                        status1=UserStatus.LOGGEDIN;
                    else
                        status1=UserStatus.LOGGEDOUT;
                    user = new User(email,password,name,status1);
                    user.setId(id);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return user;
    }

    @Override
    public User add(User entity) throws Exception {
        logger.traceEntry();
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement=connection.prepareStatement("INSERT INTO user(email,password,name,status) VALUES (?,?,?,?);")){
            preparedStatement.setString(1,entity.getEmail());
            preparedStatement.setString(2,entity.getPassword());
            preparedStatement.setString(3,entity.getName());
            preparedStatement.setString(4,entity.getStatus().toString());
            int result = preparedStatement.executeUpdate();
            logger.trace("Saved {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return entity;
    }

    @Override
    public User remove(Integer id) throws Exception {
        logger.traceEntry("Removing user with id {}",id);
        User user = getOne(id);
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("DELETE FROM user WHERE user.id = " + id+ ";")){
            int result = preparedStatement.executeUpdate();
            logger.trace("Deleted {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        return user;
    }

    @Override
    public User update(Integer id, User newEntity) throws Exception {
        logger.traceEntry("Modifying user with id  {}",id);
        User oldUser = getOne(id);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("UPDATE user SET " +
                "email = '" + newEntity.getEmail() +
                "',password = '"+ newEntity.getPassword()+
                "',name = '" + newEntity.getName() +
                "',status = '" + newEntity.getStatus().toString()+
                "'  WHERE user.id ='" + id + "';"
        )){
            int result = preparedStatement.executeUpdate();
            logger.trace("Modified {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return oldUser;
    }

    @Override
    public User getOne(String username,String password) throws Exception {
        logger.traceEntry();

        Connection connection = dbUtils.getConnection();
        User user=null;
        try(PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM user WHERE user.email = " + username +
                " AND user.password = "+  password +";")){
            try(ResultSet result = preparedStatement.executeQuery()){
                if(result.next()){
                    Integer id = result.getInt("id");
                    String name = result.getString("name");
                    String status = result.getString("status");
                    UserStatus status1;
                    if(status.equals("LOGGEDIN"))
                        status1=UserStatus.LOGGEDIN;
                    else
                        status1=UserStatus.LOGGEDOUT;
                    user = new User(username,password,name,status1);
                    user.setId(id);
                }
            }
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return user;
    }

    @Override
    public User setUserStatus(Integer id, UserStatus userStatus) throws Exception {
        logger.traceEntry("Modifying user status  {}",id);
        User oldUser = getOne(id);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("UPDATE user SET status = '" + userStatus.toString()+
                "' WHERE user.id = '" + id + "';"
        )){
            int result = preparedStatement.executeUpdate();
            logger.trace("Modified {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return oldUser;
    }
}
