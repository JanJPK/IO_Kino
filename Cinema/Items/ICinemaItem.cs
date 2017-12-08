namespace Cinema.Items
{
    public interface ICinemaItem
    {
        #region Public Properties

        int ID { get; set; }

        string ToString();

        #endregion
    }
}