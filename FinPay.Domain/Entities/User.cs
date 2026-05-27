namespace FinPay.Domain.Entities;

public class User
{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string PhoneNumber {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}

    public User(string FirstName, string LastName, string PhoneNumber, string Email, string Password)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.PhoneNumber = PhoneNumber;
        this.Email = Email;
        this.Password = Password;
    }
}