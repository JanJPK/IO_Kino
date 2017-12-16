using System.Collections.Generic;
using CinemaMk2.Items;

namespace CinemaMk2.Containers
{
    public abstract class ContainerBase<T> where T : ICinemaItem
    {
        #region Constructors and Destructors

        protected ContainerBase()
        {
        }

        #endregion

        #region Public Properties

        public Dictionary<int, T> Items { get; set; }

        #endregion

        #region Public Methods and Operators

        public bool Remove(int id)
        {
            ICinemaItem item = Search(id);
            if (item != null)
            {
                Items.Remove(id);
                return true;
            }
            return false;
        }

        public T Search(int id)
        {
            //return Items.First(p => p.ID == id);
            if (Items.ContainsKey(id))
            {
                return Items[id];
            }
            return default(T);
        }

        public virtual bool Contains(T model)
        {
            if (Items.ContainsValue(model))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}