namespace Cinema.Items
{
    /// <summary>
    ///     Interfejs dla obiektów - pozwala na generyczny kontener.
    /// </summary>
    public interface ICinemaItem
    {
        #region Public Properties

        int ID { get;}

        #endregion

        #region Public Methods and Operators

        string ToString();

        #endregion
    }
}