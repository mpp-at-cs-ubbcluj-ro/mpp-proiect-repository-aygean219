package com.example.projectjava.Domain;
import java.util.List;

public class CharityCase extends Entity<Integer>{
    private String name;
    private List<Donor> donors;
    private Integer totalSum;

    public CharityCase(String name, List<Donor> donors, Integer totalSum) {
        this.name = name;
        this.donors = donors;
        this.totalSum = totalSum;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<Donor> getDonors() {
        return donors;
    }

    public void setDonors(List<Donor> donors) {
        this.donors = donors;
    }

    public Integer getTotalSum() {
        return totalSum;
    }

    public void setTotalSum(Integer totalSum) {
        this.totalSum = totalSum;
    }

    @Override
    public String toString() {
        return "CharityCase{" +
                "Name='" + name + '\'' +
                ", donors=" + donors +
                ", totalSum=" + totalSum +
                '}';
    }
}
