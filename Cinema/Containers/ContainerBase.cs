using System.Collections.Generic;
using Cinema.Items;

namespace Cinema.Containers
{
    /// <summary>
    ///     Bazowa klasa dla kontenerów.
    /// </summary>
    /// <typeparam name="T">Typ konteneru.</typeparam>
    public abstract class ContainerBase<T> where T : ICinemaItem
    {
        #region Public Properties

        /// <summary>
        ///     Przechowywane obiekty.
        /// </summary>
        public Dictionary<int, T> Items { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Sprawdza czy kontener przechowuje jakiekolwiek obiekty.
        /// </summary>
        /// <returns>Prawda w przypadku gdy przechowuje 1 lub więcej obiektów.</returns>
        public bool Any()
        {
            if (Items.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Sprawdza czy kontener przechowuje dany obiekt.
        /// </summary>
        /// <param name="model">Obiekt.</param>
        /// <returns>Prawda gdy obiekt znajduje się w Items.</returns>
        public virtual bool Contains(T model)
        {
            if (Items.ContainsValue(model))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Sprawdza czy dwa kontenery są takie same - porównuje zawartość Items.
        /// </summary>
        /// <param name="obj">Kontener.</param>
        /// <returns>Prawda gdy obiekty są takie same.</returns>
        public override bool Equals(object obj)
        {
            var @base = obj as ContainerBase<T>;
            if (@base == null)
                return false;

            foreach (var pair in @base.Items)
            {
                // Jeżeli nie ma takiego klucza => false.
                if (!Items.ContainsKey(pair.Key))
                    return false;

                // Jeżeli wartość pod tym samym kluczem się nie zgadza => false.
                if (!Items[pair.Key].Equals(pair.Value))
                    return false;
            }

            return true;
        }

        /// <summary>
        ///     Usuwa obiekt z Items o zadanym kluczu.
        /// </summary>
        /// <param name="id">Klucz obiektu (miejsce w Dictionary).</param>
        /// <returns>Prawda gdy udało się usunąć obiekt.</returns>
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

        /// <summary>
        ///     Szuka obiektu o zadanym ID i go zwraca.
        /// </summary>
        /// <param name="id">Klucz obiektu.</param>
        /// <returns>Obiekt lub null gdy go nie ma.</returns>
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