using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class OrderDetails
    {
        private int id=1;
        private int orderID = 1;
        private int productID = 1;
        private int price = 1;
        private int quantity = 1;

        public OrderDetails()
        {

        }

        public OrderDetails(int id,int orderID,int productID,int price,int quantity)
        {
            this.id = id;
            this.orderID = orderID;
            this.productID = productID;
            this.price = price;
            this.quantity = quantity;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }
        public void setOrderId(int orderID)
        {
            this.orderID = orderID;
        }
        public int getOrderId()
        {
            return this.orderID;
        }
        public void setProductID(int productID)
        {
            this.productID = productID;
        }
        public int getProductId()
        {
            return this.productID;
        }
        public void setPrice(int price)
        {
            this.price = price;
        }
        public int getPrice()
        {
            return this.price;
        }
        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }
        public int getQuantity()
        {
            return this.quantity;
        }

        public string description()
        {
            string text = "";

            text += "Id: " + id.ToString() + "\n";
            text += "OrderId: " + orderID.ToString() + "\n";
            text += "ProductId: " + productID.ToString() + "\n";
            text += "Price: " + price.ToString() + "\n";
            text += "Quantity: " + quantity.ToString() + "\n";

            return text;

        }
        public string toSave()
        {
            string text = "";

            text += id.ToString() + " ";
            text += orderID.ToString() + " ";
            text += productID.ToString() + " ";
            text += price.ToString() + " ";
            text += quantity.ToString();

            return text;

        }


    }
}
