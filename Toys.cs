using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class Toys : Products
    {
        private int minimAge = 0;

        public Toys()
        {

        }

        public Toys(int minimAge, int id, int weight, int price, int stock) : base(id, "Toys", weight, price, stock)
        {
            this.minimAge = minimAge;
        }

        public void SetMinimAge(int minimAge)
        {
            this.minimAge = minimAge;
        }

        public int GetMinimAge()
        {
            return this.minimAge;
        }

        public override string description()
        {
            string text = base.description();

            text += "Minim Age: " + minimAge.ToString() + "\n";

            return text;
        }

        public override string toSave()
        {
            string text = "";

            text += this.GetName() + " ";
            text += GetId().ToString() + " ";
            text += GetWeight().ToString() + " ";
            text += GetPrice().ToString() + " ";
            text += GetStock().ToString()+" ";
            text += GetMinimAge().ToString() ;

            return text;
        }

    }
}
