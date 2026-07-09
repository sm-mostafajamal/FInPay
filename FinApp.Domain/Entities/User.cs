namespace FinApp.Domain.Entities;

public class User
{
    public int Id {get; private set;} = default!;
    public string FirstName {get; private set;} = default!;
    public string LastName {get; private set;} = default!;
    public string PhoneNumber {get; private set;} = default!;
    public string Email {get; private set;} = default!;
    public string Password {get; private set;} = default!;

    public User(){}
    
    public User(string FirstName, string LastName, string PhoneNumber, string Email, string Password)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.PhoneNumber = PhoneNumber;
        this.Email = Email;
        this.Password = Password;
    }
}