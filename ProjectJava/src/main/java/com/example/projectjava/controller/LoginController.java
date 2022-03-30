package com.example.projectjava.controller;


import com.example.projectjava.Domain.User;
import com.example.projectjava.Service.Service;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;


public class LoginController {
    @FXML
    private TextField emailLogIn;
    @FXML
    private PasswordField paswordLogIn;
    @FXML
    private TextField nameSignUp;
    @FXML
    private TextField emailSignUp;
    @FXML
    private Button logInButton;
    @FXML
    private Button signUpButton;
    @FXML
    private PasswordField passwordSignUp;
    @FXML
    private Label errorLabel1;
    @FXML
    private Label errorLabel2;

    private Service service;
    private User loggedInUser;

    public void setService(Service service){
        this.service = service;
    }

    public void logInAction(ActionEvent actionEvent) throws Exception{
        try{
            service.logInUser(emailLogIn.getText(),paswordLogIn.getText());
            loggedInUser = service.getLoggedUser(emailLogIn.getText(),paswordLogIn.getText());
            FXMLLoader mainLoader = new FXMLLoader();
            mainLoader.setLocation(getClass().getResource("mainController.fxml"));
            AnchorPane root = mainLoader.load();
            Stage main_stage = new Stage();
            MainController mainController = mainLoader.getController();
            mainController.setService(service,loggedInUser);
            main_stage.setScene(new Scene(root));
            main_stage.show();

            Stage stage = (Stage) logInButton.getScene().getWindow();
            stage.close();
        }catch (Exception e){
            errorLabel1.setText(e.getMessage());
            System.out.println(e.getMessage());
        }
    }

    public void signInAction(ActionEvent actionEvent) throws Exception{
        try{
            service.signUpUser(emailSignUp.getText(),passwordSignUp.getText(),nameSignUp.getText());

        }catch (Exception e){
            errorLabel2.setText(e.getMessage());
        }
    }



}
