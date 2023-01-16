using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class Electronics:Products
    {
        private string brand = "";

        public Electronics()
        {

        }

        public Electronics(string brand, int id, int weight, int price, int stock):base(id,"Electronics",weight,price,stock)
        {
            this.brand = brand;
        }

        public void SetBrand(string brand)
        {
            this.brand = brand;
        }

        public string GetBrand()
        {
            return this.brand;
        }

        public override string description()
        {
            string text = base.description();

            text += "Brand: " + brand + "\n";

            return text;
        }

        public override string toSave()
        {
            string text = "";

            text += this.GetName() + " ";
            text += GetId().ToString() + " ";
            text += GetWeight().ToString() + " ";
            text += GetPrice().ToString() + " ";
            text += GetStock().ToString() + " ";
            text += this.GetBrand() ;

            return text;
        }


    }
}
