module com.example.projectjava {
    requires javafx.controls;
    requires javafx.fxml;

    requires org.controlsfx.controls;
    requires com.dlsc.formsfx;
    requires org.kordamp.bootstrapfx.core;
    requires java.sql;
    requires org.apache.logging.log4j;

    opens com.example.projectjava to javafx.fxml;
    exports com.example.projectjava;
    opens com.example.projectjava.controller to javafx.fxml;
    exports com.example.projectjava.controller;
    opens com.example.projectjava.Domain to javafx.fxml;
    exports com.example.projectjava.Domain;


}