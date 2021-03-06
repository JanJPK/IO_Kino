﻿using System;

namespace Cinema.System.Items
{
    /// <summary>
    ///     Dane klienta.
    /// </summary>
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
            var data = obj as PersonalData;
            return data != null &&
                   FirstName == data.FirstName &&
                   Phone == data.Phone &&
                   SecondName == data.SecondName;
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