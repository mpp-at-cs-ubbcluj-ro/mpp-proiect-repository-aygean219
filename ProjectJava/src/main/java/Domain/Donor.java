package Domain;

public class Donor extends Entity<Integer>{
    private String name;
    private String phone;
    private String address;
    private Integer donated_sum;

    public Donor(String name, String phone, String address, Integer donated_sum) {
        this.name = name;
        this.phone = phone;
        this.address = address;
        this.donated_sum = donated_sum;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        name = name;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Integer getDonated_sum() {
        return donated_sum;
    }

    public void setDonated_sum(Integer donated_sum) {
        this.donated_sum = donated_sum;
    }

    @Override
    public String toString() {
        return "Donor{" +
                "Name='" + name + '\'' +
                ", phone='" + phone + '\'' +
                ", address='" + address + '\'' +
                ", donated_sum=" + donated_sum +
                '}';
    }
}
