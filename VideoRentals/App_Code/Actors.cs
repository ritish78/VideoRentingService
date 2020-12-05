using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRentals
{
    public class Actors
    {
        private int actorID;
        private string name;

        public Actors(int actorID, string name)
        {
            this.actorID = actorID;
            this.name = name;
        }

        public int ActorsID { get => actorID; set => actorID = value; }
        public string Name { get => name; set => name = value; }
    }
}