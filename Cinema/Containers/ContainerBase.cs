using System.Collections.Generic;
using Cinema.Items;

namespace Cinema.Containers
{
    public abstract class ContainerBase<T> where T : ICinemaItem
    {
        #region Public Properties

        public Dictionary<int, T> Items { get; set; }

        #endregion

        #region Public Methods and Operators

        public bool Any()
        {
            if (Items.Count > 0)
            {
                return true;
            }
            return false;
        }

        public virtual bool Contains(T model)
        {
            if (Items.ContainsValue(model))
            {
                return true;
            }
            return false;
        }

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

        public T Search(int id)
        {
            //return Items.First(p => p.ID == id);
            if (Items.ContainsKey(id))
            {
                return Items[id];
            }
            return default(T);
        }

        #endregion
    }
}