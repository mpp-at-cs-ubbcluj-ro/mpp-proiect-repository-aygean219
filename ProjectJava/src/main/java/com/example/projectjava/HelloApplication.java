package com.example.projectjava;

import com.example.projectjava.Repository.CharityCaseDatabaseRepository;
import com.example.projectjava.Repository.DonationDatabaseRepository;
import com.example.projectjava.Repository.DonorDatabaseRepository;
import com.example.projectjava.Repository.UserDatabaseRepository;
import com.example.projectjava.Service.Service;
import com.example.projectjava.controller.LoginController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

public class HelloApplication extends Application {
    @Override
    public void start(Stage stage) throws IOException {
        /*Properties props = new Properties();
        try {
            props.load(new FileReader("db.properties"));
        } catch (IOException e) {
            System.out.println("Cannot find bd.config " + e);
        }

        try{
        UserDatabaseRepository userDatabaseRepository = new UserDatabaseRepository(props);
        DonorDatabaseRepository donorDatabaseRepository = new DonorDatabaseRepository(props);
        CharityCaseDatabaseRepository charityCaseDatabaseRepository = new CharityCaseDatabaseRepository(props);
        Service service = new Service(userDatabaseRepository,donorDatabaseRepository,charityCaseDatabaseRepository);
        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(getClass().getResource("controller/loginController.fxml"));
        AnchorPane root = loader.load();
        LoginController ctrl = loader.getController();
        ctrl.setService(service);
        stage.setScene(new Scene(root));
        stage.setTitle("Social Network");
            //primaryStage.setResizable(false);
        stage.show();
        }catch (Exception e){
            System.out.println("Exception " + e);
        }*/
        Properties props = new Properties();
        try {
            props.load(new FileReader("db.properties"));
        } catch (IOException e) {
            System.out.println("Cannot find bd.config " + e);
        }


        UserDatabaseRepository userDatabaseRepository = new UserDatabaseRepository(props);
        DonorDatabaseRepository donorDatabaseRepository = new DonorDatabaseRepository(props);
        CharityCaseDatabaseRepository charityCaseDatabaseRepository = new CharityCaseDatabaseRepository(props);
        DonationDatabaseRepository donationDatabaseRepository = new DonationDatabaseRepository(props);
        Service service = new Service(userDatabaseRepository,donorDatabaseRepository,charityCaseDatabaseRepository, donationDatabaseRepository);



        FXMLLoader fxmlLoader = new FXMLLoader();
        fxmlLoader.setLocation(getClass().getResource("controller/loginController.fxml"));
        AnchorPane root = fxmlLoader.load();
        LoginController ctrl = fxmlLoader.getController();
        ctrl.setService(service);
        Scene scene = new Scene(root);
        stage.setTitle("Hello!");
        stage.setScene(scene);
        stage.show();
    }

    public static void main(String[] args) {
        launch();
    }
}