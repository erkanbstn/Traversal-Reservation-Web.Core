using Microsoft.AspNetCore.Identity;

namespace TraversalSite.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Password Must be At Least 20 Characters"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code= "PasswordRequiresUpper",
                Description="Password Must Contain at Least 1 Upper Case"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Password Must Contain at Least 1 Lower Case"
            };
        }
    }
}
