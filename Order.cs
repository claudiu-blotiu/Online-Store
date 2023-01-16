using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class Order
    {
        private int id = 1;
		private int customerId = 1;
		private int ammount = 1;
		private string shippingAdress = "";
		private string orderAdress = "";
		private string orderEmail = "";
		private int orderDate = 1;
		private bool orderStatus = true;

		public Order()
        {

        }

		public Order(int id,int customerId,int ammount,string shippingAdress,string orderAdress,string orderEmail,int orderDate,bool orderStatus)
        {
			this.id = id;
			this.customerId = customerId;
			this.ammount = ammount;
			this.shippingAdress = shippingAdress;
			this.orderAdress = orderAdress;
			this.orderEmail = orderEmail;
			this.orderDate = orderDate;
			this.orderStatus = orderStatus;
        }

		public void setId(int id)
        {
			this.id = id;
        }
		public int getId()
        {
			return this.id;
        }

		public void setCumstomerID(int customerId)
        {
			this.customerId = customerId;

		}
		public int getCustomerId()
        {
			return this.customerId;

		}

		public void setAmmount(int ammount)
        {
			this.ammount = ammount;

		}
		public int getAmmount()
        {
			return this.ammount;

		}

		public void setShippingAdress(string shippingAdress)
        {
			this.shippingAdress = shippingAdress;

		}
		public string getShippingAdress()
        {
			return this.shippingAdress;

		}

		public void setOrderAdress(string orderAdress)
        {
			this.orderAdress = orderAdress;

		}
		public string getOrderAdress()
        {
			return this.orderAdress;

		}

		public void setOrderEmail(string orderEmail)
        {
			this.orderEmail = orderEmail;

		}
		public string getOrderEmail()
        {
			return this.orderEmail;

		}

		public void setOrderDate(int orderDate)
        {
			this.orderDate = orderDate;

		}
		public int getOrderDate()
        {
			return this.orderDate;

		}

		public void setOrderStatus(bool orderStatus)
        {
			this.orderStatus = orderStatus;

		}
		public bool getOrderStatus()
        {
			return this.orderStatus;

        }

		public string description()
		{
			string text = "";

			text += "Id: " + id.ToString() + "\n";
			text += "Customer Id: " + customerId.ToString() + "\n";
			text += "Ammount:" + ammount.ToString() + "\n";
			text += "Shipping Adress: " + shippingAdress + "\n";
			text += "Order Adress: " + orderAdress + "\n";
			text += "Order Email: " + orderEmail + "\n";
			text += "Order Date: " + orderDate.ToString() + "\n";
			if (orderStatus != false)
			{
				text += "Avalible.\n";
			}
			else
			{
				text += "Processing.\n";
			}

			return text;
		}

        public string toSave()
        {
			string text = "";
			text += id.ToString() + " ";
			text += customerId.ToString() + " ";
			text += ammount.ToString() + " ";
			text += shippingAdress + " ";
			text += orderAdress + " ";
			text += orderEmail + " ";
			text += orderDate.ToString() + " ";
			text += orderStatus.ToString();
			return text;
		}
	}
}
