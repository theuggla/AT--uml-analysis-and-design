
namespace MemberRegistry.model
{
    class Password
    {
        const int MIN_VALID_LENGTH = 6;
        private string _password;

        public Password(string password)
        {
            this._password = password;
            this.ValidatePassword();
        }

        public bool IsPasswordCorrect(string attemptedPassword)
        {
            return this._password == attemptedPassword;
        }

        public string GetPassword()
        {
            return this._password;
        }

        private void ValidatePassword()
        {
            if (this.PasswordIsMissing()) 
            {
                throw new PasswordIsMissingException("Password is missing");
            } 
            else if (this.PasswordIsTooShort()) 
            {
                throw new PasswordIsTooShortException($"Password has too few characters, at least {MIN_VALID_LENGTH} characters.");
            }
        }

        private bool PasswordIsMissing()
        {
            return this._password.Length == 0;
        }

        private bool PasswordIsTooShort()
        {
            return this._password.Length < MIN_VALID_LENGTH;
        }
    }
}
