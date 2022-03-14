package Domain;

public class Donation extends Entity<Integer>{
    private CharityCase charityCase;
    private Donor donor;

    public Donation(CharityCase charityCase, Donor donor) {
        this.charityCase = charityCase;
        this.donor = donor;
    }

    public CharityCase getCharityCase() {
        return charityCase;
    }

    public void setCharityCase(CharityCase charityCase) {
        this.charityCase = charityCase;
    }

    public Donor getDonor() {
        return donor;
    }

    public void setDonor(Donor donor) {
        this.donor = donor;
    }

    @Override
    public String toString() {
        return "Donation{" +
                "charityCase=" + charityCase +
                ", donor=" + donor +
                '}';
    }
}
