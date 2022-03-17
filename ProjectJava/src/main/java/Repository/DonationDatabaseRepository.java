package Repository;

import Domain.Donation;
import Domain.User;
import InterfaceRepositories.DonationRepository;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Properties;

public class DonationDatabaseRepository implements DonationRepository {
    private final JdbcUtils dbUtils;
    private static final Logger logger= LogManager.getLogger();

    public DonationDatabaseRepository(Properties properties) {
        logger.info("Initializing UserDatabaseRepository with properties: {}",properties);
        dbUtils = new JdbcUtils(properties);
    }

    @Override
    public Donation add(Donation entity) throws Exception {
        logger.traceEntry();
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement=connection.prepareStatement("INSERT INTO donation(idCharityCase,idDonor) VALUES (?,?);")){
            preparedStatement.setInt(1,entity.getCharityCase().getId());
            preparedStatement.setInt(2,entity.getDonor().getId());
            int result = preparedStatement.executeUpdate();
            logger.trace("Saved {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return entity;
    }

    @Override
    public Donation remove(Integer id) throws Exception {
        logger.traceEntry("Removing donation with id {}",id);
        Connection connection= dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("DELETE FROM donation WHERE donation.id = " + id+ ";")){
            int result = preparedStatement.executeUpdate();
            logger.trace("Deleted {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        return null;
    }

    @Override
    public Donation update(Integer id, Donation newEntity) throws Exception {
        logger.traceEntry("Modifying donation with id  {}",id);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("UPDATE donation SET " +
                "idCharityCase = '" + newEntity.getCharityCase().getId()+
                "',idDonor = '"+ newEntity.getDonor().getId()+
                "'  WHERE donation.id ='" + id + "';"
        )){
            int result = preparedStatement.executeUpdate();
            logger.trace("Modified {} instances",result);
        }catch (SQLException exception){
            logger.error(exception);
        }
        logger.traceExit();
        return null;
    }

    @Override
    public Iterable<Donation> getAll() {
        return null;
    }

    @Override
    public Donation getOne(Integer integer) throws Exception {
        return null;
    }
}
