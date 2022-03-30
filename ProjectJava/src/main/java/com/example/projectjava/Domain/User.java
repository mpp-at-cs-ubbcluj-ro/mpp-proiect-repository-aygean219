package com.example.projectjava.Domain;

public class User extends Entity<Integer>{
    private String email;
    private String password;
    private String name;
    private UserStatus status = UserStatus.LOGGEDOUT ;

    public User(String email, String password, String name, UserStatus status) {
        this.email = email;
        this.password = password;
        this.name = name;
        this.status = status;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public UserStatus getStatus() {
        return status;
    }

    public void setStatus(UserStatus status) {
        this.status = status;
    }

    @Override
    public String toString() {
        return "User{" +
                "email='" + email + '\'' +
                ", password='" + password + '\'' +
                ", name='" + name + '\'' +
                ", status=" + status +
                '}';
    }
}
