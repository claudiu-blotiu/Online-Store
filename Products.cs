using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
      class Products
    {
        private int id = 1;
        private string name = "";
        private int weight = 1;
        private int price = 1;
        private int stock = 1;

        public Products()
        {

        }

        public Products(int id,string name,int weight,int price,int stock)
        {
            this.id = id;
            this.name = name;
            this.weight = weight;
            this.price = price;
            this.stock = stock;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return this.id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        public void SetWeight(int weight)
        {
            this.weight = weight;
        }
        public int GetWeight()
        {
            return this.weight;
        }

        public void SetPrice(int price)
        {
            this.price = price;
        }
        public int GetPrice()
        {
            return this.price;
        }

        public void SetStock(int stock)
        {
            this.stock = stock;
        }
        public int GetStock()
        {
            return this.stock;
        }
        
         public virtual string description()
        {
            string text = "";

            text += "Id: " + id.ToString() + "\n";
            text += "Name: " + this.name + "\n";
            text += "Weight: " + weight.ToString() + "\n";
            text += "Price: " + price.ToString() + "\n";
            text += "Stock: " + stock.ToString() + "\n";

            return text;
        }

        public virtual string toSave()
        {
            string text = "";

            text += id.ToString() + " ";
            text += this.name + " ";
            text += weight.ToString() + " ";
            text += price.ToString() + " ";
            text += stock.ToString();

            return text;
        }

        
    }
}
