namespace Cinema.Items
{
    public interface ICinemaItem
    {
        #region Public Properties

        int ID { get; set; }

        #endregion

        #region Public Methods and Operators

        string ToString();

        #endregion
    }
}