package com.example.projectjava.controller;

import com.example.projectjava.Domain.CharityCase;
import com.example.projectjava.Domain.Donor;
import com.example.projectjava.Domain.User;
import com.example.projectjava.Service.Service;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Stage;

import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.StreamSupport;

public class MainController {
    public TableColumn<Donor,String> donorNameColumn;
    public TableColumn<Donor,String> phoneColumn;
    public TableColumn<Donor,String> addressColumn;
    public TableColumn<Donor,Integer> sumColumn;
    public TextField nameOfDonor;
    public TextField phone;
    public TextField address;
    public TextField donatedSum;
    public Button addDonorButton;
    public TableView<Donor> donorsTable;
    public Button deleteDonor;
    public Button refreshButton;
    @FXML
    private Label errorLabel3;
    @FXML
    private Label labelWelcome;
    @FXML
    public TableView<CharityCase> charityCaseTable;
    @FXML
    public TableColumn<CharityCase,String> nameOfCharityCaseColumn;
    @FXML
    public TableColumn<CharityCase,Integer> totalSumColumn;
    @FXML
    private TextField nameOfCharityCase;
    @FXML
    private Button addCharityCaseButton;
    @FXML
    private Button deleteCharityCaseButton;
    @FXML
    private Button logOutButton;


    private Service service;
    private User loggedUser;
    ObservableList<CharityCase> charityCasesObservableList = FXCollections.observableArrayList();
    ObservableList<Donor> donorsObservableList = FXCollections.observableArrayList();

    @FXML
    public void initialize(){
        nameOfCharityCaseColumn.setCellValueFactory(new PropertyValueFactory<CharityCase,String>("name"));
        totalSumColumn.setCellValueFactory(new PropertyValueFactory<CharityCase,Integer>("totalSum"));
        donorNameColumn.setCellValueFactory(new PropertyValueFactory<Donor,String>("name"));
        phoneColumn.setCellValueFactory(new PropertyValueFactory<Donor,String>("phone"));
        addressColumn.setCellValueFactory(new PropertyValueFactory<Donor,String>("address"));
        sumColumn.setCellValueFactory(new PropertyValueFactory<Donor,Integer>("donated_sum"));
        charityCaseTable.setItems(charityCasesObservableList);
        donorsTable.setItems(donorsObservableList);
    }

    public void setService(Service service,User user){
        this.service=service;
        this.loggedUser = user;
        labelWelcome.setText("Welcome " + loggedUser.getName() + "! :)");
        init();
        initDonors();

    }

    public void initDonors(){
        if(charityCaseTable.getSelectionModel().getSelectedItem()!=null){
            List<Donor> list = charityCaseTable.getSelectionModel().getSelectedItem().getDonors();

            donorsObservableList.setAll(StreamSupport.stream(list.spliterator(), false)
                    .collect(Collectors.toList()));
        }
        donorsObservableList.setAll(service.getAllDonors());
    }
    public void init(){
        charityCasesObservableList.setAll(service.getAllCharityCases());
        if(charityCaseTable.getSelectionModel().getSelectedItem()!=null){
            donorsObservableList.setAll(charityCaseTable.getSelectionModel().getSelectedItem().getDonors());
        }
    }

    public void logOutAction(ActionEvent actionEvent) throws Exception{
        try{
            service.logOutUser(loggedUser.getEmail(),loggedUser.getPassword());
            Stage stage = (Stage) logOutButton.getScene().getWindow();
            stage.close();
        }catch (Exception e){
            errorLabel3.setText(e.getMessage());
        }
    }

    public void addCharityCaseAction(ActionEvent actionEvent) throws Exception{
        try{
            service.addCharityCase(nameOfCharityCase.getText());
            nameOfCharityCase.clear();
            init();
        }catch (Exception e){
            errorLabel3.setText(e.getMessage());
        }
    }

    public void deleteCharityCaseAction(ActionEvent actionEvent) throws Exception{
        try{
            if(charityCaseTable.getSelectionModel().getSelectedItem()!=null){
                service.deleteCharityCase(charityCaseTable.getSelectionModel().getSelectedItem().getId());
            }
        }catch (Exception e){
            errorLabel3.setText(e.getMessage());
        }
    }

    public void deleteDonor(ActionEvent actionEvent) throws Exception{
        try{
            if(charityCaseTable.getSelectionModel().getSelectedItem()!=null){
                service.deleteCharityCase(charityCaseTable.getSelectionModel().getSelectedItem().getId());
            }
        }catch (Exception e){
            errorLabel3.setText(e.getMessage());
        }
    }

    public void refreshAction(ActionEvent actionEvent) throws Exception {
        init();
        initDonors();
    }

    public void addDonationAction(ActionEvent actionEvent) throws Exception{
        try{
            if(nameOfDonor.getText()!=""&&phone.getText()!=""&&address.getText()!=""&&donatedSum.getText()!=""&&charityCaseTable.getSelectionModel().getSelectedItem()!=null){
                service.addDonation(charityCaseTable.getSelectionModel().getSelectedItem().getId(),nameOfDonor.getText(),phone.getText(),address.getText(),Integer.parseInt(donatedSum.getText()));
                initDonors();
            }
            nameOfDonor.clear();
            phone.clear();
            address.clear();
            donatedSum.clear();
        }catch (Exception e){
            errorLabel3.setText(e.getMessage());
        }
    }



}
