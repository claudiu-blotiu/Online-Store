using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class Customer
    {
		private int id = 1;
		private string email = "";
		private string password = "";
		private string fullName = "";
		private string billingAdress = "";
		private string shippingAdress = "";
		private string country = "";
		private int phone = 1;

		public Customer()
        {

        }

		public Customer(int id, string email, string password, string fullName, string billingAdress, string shippingAdress, string country, int phone)
        {
			this.id = id;
			this.email = email;
			this.password = password;
			this.fullName = fullName;
			this.billingAdress = billingAdress;
			this.shippingAdress = shippingAdress;
			this.country = country;
			this.phone = phone;
        }

		public void setId(int id)
        {
			this.id = id;
        }
		public int getId()
        {
			return this.id;
        }

		public void setEmail(string email)
        {
			this.email = email;
		}
		public string getEmail()
        {
			return this.email;
		}

		public void setPassword(string password)
        {
			this.password = password;
		}
		public string getPassword()
        {
			return this.password;
		}

		public void setFullname(string fullName)
        {
			this.fullName = fullName;
		}
		public string getFullname()
        {
			return this.fullName;
		}

		public void setBillingadress(string billingAdress)
        {
			this.billingAdress = billingAdress;
		}
		public string getBillingadress()
        {
			return this.billingAdress;
		}

		public void setShippingAdress(string shippingAdress)
        {
			this.shippingAdress = shippingAdress;
		}
		public string getShippingAdress()
        {
			return this.shippingAdress;
		}

		public void setCountry(string country)
        {
			this.country = country;
		}
		public string getCountry()
        {
			return this.country;
		}

		public void setPhone(int phone)
        {
			this.phone = phone;
		}
		public int getPhone()
        {
			return this.phone;
		}

		public string description()
        {
			string text = "";

			text += "Id: " + id.ToString() + "\n";
			text += "Email: " + email + "\n";
			text += "Password: " + password + "\n";
			text += "Full Name: " + fullName + "\n";
			text += "Billing Adress: " + billingAdress + "\n";
			text += "Shipping Adress: " + shippingAdress + "\n";
			text += "Country: " + country + "\n";
			text += "Phone: " + phone.ToString() + "\n";

			return text;
		}

		public string toSave()
        {
			string text = "";

			text += id.ToString() + " ";
			text += email + " ";
			text += password + " ";
			text += fullName + " ";
			text += billingAdress + " ";
			text += shippingAdress + " ";
			text += country + " ";
			text += phone.ToString();

			return text;
		}
	}
}
