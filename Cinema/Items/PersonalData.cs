using System;
using System.Collections.Generic;

namespace Cinema.Items
{
    public class PersonalData
    {
        #region Constructors and Destructors

        public PersonalData(string firstName, string secondName, string phone)
        {
            FirstName = firstName;
            SecondName = secondName;
            Phone = phone;
        }

        #endregion

        #region Public Properties

        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string SecondName { get; set; }

        #endregion

        #region Public Methods and Operators

        public override bool Equals(object obj)
        {
            var osobowe = obj as PersonalData;
            return osobowe != null &&
                   FirstName == osobowe.FirstName &&
                   SecondName == osobowe.SecondName &&
                   Phone == osobowe.Phone;
        }

        public override int GetHashCode()
        {
            var hashCode = 1627571942;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SecondName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            return hashCode;
        }

        public override string ToString()
        {
            return "Imię: " + FirstName + Environment.NewLine + "Nazwisko: " + SecondName + Environment.NewLine +
                   "Telefon: " +
                   Phone;
        }

        #endregion
    }
}