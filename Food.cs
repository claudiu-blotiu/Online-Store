using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class Food:Products
    {
        private string type = "";

        public Food()
        {

        }

        public Food(string type,int id,int weight,int price,int stock):base(id,"Food",weight,price,stock)
        {
            this.type = type;
        }

        public void Set_Type(string type)
        {
            this.type = type;
        }

        public string Get_Type()
        {
            return this.type;
        }

        public override string description()
        {
            string text = base.description();

            text += "Type: " + this.type + "\n";

            return text;
        }

        public override string toSave()
        {
            string text = "";

            text += this.GetName() + " ";
            text += GetId().ToString() + " ";
            text += GetWeight().ToString() + " ";
            text += GetPrice().ToString() + " ";
            text += GetStock().ToString()+ " ";
            text += this.type ;

            return text;
        }

    }
}
