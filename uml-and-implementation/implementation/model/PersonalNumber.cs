using System;
using System.Text.RegularExpressions;

namespace MemberRegistry.model
{
    class PersonalNumber
    {
        //validates swedish personal numbers
        //accepts formats YYMMDD-NNNN, YYMMDDNNNN, YYYYMMDD-NNNN, YYYYMMDDNNNN
        private Regex _validationRegEx = new Regex("^(19|20)?[0-9]{6}[- ]?[0-9]{4}$");
        private string _personalNumber;

        public string Number
        {
            get
            {
                return this._personalNumber;
            }
            set
            {
                this.ValidatePersonalNumber(value);
                this._personalNumber = value;
            }
        }

        public PersonalNumber(string number)
        {
            this.Number = number;
        }

        private void ValidatePersonalNumber(string number)
        {
            if (number != null)
            {
                if (!this._validationRegEx.IsMatch(number)) 
                {
                    throw new InvalidPersonalNumberException();
                }    
            }
        }
    }
}