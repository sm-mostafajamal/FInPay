using ErrorOr;

namespace FinPay.Domain.Errors;

public partial class Errors
{
    public class Users
    {

        public static Error DuplicateUser => Error.Validation(code: "DuplicateUser", description: "User with the email already exists!");
        public static Error UserNotFound => Error.Unauthorized(code: "UserNotFound", description: "Login with wrong username/password");
    }    
}