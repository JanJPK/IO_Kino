using System.Collections.Generic;
using Cinema.Items;

namespace Cinema.Containers
{
    public abstract class ContainerBase<T> where T : ICinemaItem
    {
        #region Constructors and Destructors

        public ContainerBase()
        {
            Items = new Dictionary<int, T>();
        }

        #endregion

        #region Public Properties

        public abstract Dictionary<int, T> Items { get; set; }

        #endregion

        #region Public Methods and Operators

        public virtual bool Remove(int id)
        {
            ICinemaItem item = Search(id);
            if (item != null)
            {
                Items.Remove(id);
                return true;
            }
            return false;
        }

        public virtual T Search(int id)
        {
            //return Items.First(p => p.ID == id);
            return Items[id];
        }

        #endregion
    }
}