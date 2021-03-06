﻿using System;
using System.Collections.Generic;
using System.Linq;
using CinemaMk2.Items;

namespace CinemaMk2.Containers
{
    public class Movies : ContainerBase<Movie>
    {


        #region Public Methods and Operators

        public void Add(string title, DateTime releaseDate, int length, string director, int viewerAge,
            string language)
        {
            //int id = Items.OrderBy(p => p.ID).Last().ID;
            int id = Items.Keys.Max();
            id++;
            Items.Add(id, new Movie(id, title, releaseDate, length, director, viewerAge, language));
        }

        public Movie Search(string title)
        {
            //return Items.First(p => p.Title == title);
            return Items.FirstOrDefault(x => x.Value.Title == title).Value;
        }

        #endregion

        public Movies()
        {
            Items = new Dictionary<int, Movie>();
        }
    }
}