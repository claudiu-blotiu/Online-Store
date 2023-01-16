using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace OnlineStore
{
    class ControlCustomer
    {
        private List<Customer> customer;
        private ControlOrder order;

        public ControlCustomer(ControlOrder order)
        {
            customer = new List<Customer>();

            this.order = order;

            load();
        }

        public void Add(Customer a)
        {
            customer.Add(a);

        }

        public void show()
        {
            for (int i = 0; i < customer.Count; i++)
            {
                Console.Write(customer[i].description());
                Console.Write("\n");
            }
        }

        public int poz(string email)
        {
            for (int i = 0; i < customer.Count; i++)
            {
                if (customer[i].getEmail() == email)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Delete(string email)
        {
            int p = poz(email);

            for (int i = p; i < customer.Count - 1; i++)
            {
                customer[i] = customer[i + 1];
            }
        }

        public void updateEmail(string email, string newEmail)
        {
            int p = poz(email);
            if (p != -1)
            {
                customer[p].setEmail(newEmail);
            }
            else
            {
                Console.Write("Email not found");
                Console.Write("\n");
            }
        }

        public void updatePassword(string email, string newPassword)
        {
            int p = poz(email);
            if (p != -1)
            {
                customer[p].setPassword(newPassword);
            }
            else
            {
                Console.Write("Wrong Password.");
                Console.Write("\n");
            }
        }

        public void updateFullname(string email, string newFullname)
        {
            int p = poz(email);
            if (p != -1)
            {
                customer[p].setFullname(newFullname);
            }
            else
            {
                Console.Write("The Full name is wrong");
                Console.Write("\n");
            }
        }

        public void updateBillingAdress(string email, string newBillingadress)
        {
            int p = poz(email);
            if (p != -1)
            {
                customer[p].setBillingadress(newBillingadress);
            }
            else
            {
                Console.Write("The Billing adress is wrong");
                Console.Write("\n");
            }
        }

        public void updateShippingAdress(string email, string newShippingadress)
        {
            int p = poz(email);
            if (p != -1)
            {
                customer[p].setShippingAdress(newShippingadress);
            }
            else
            {
                Console.Write("The Shipping adress is wrong");
                Console.Write("\n");
            }
        }
        public void updateCountry(string email, string newCountry)
        {
            int p = poz(email);
            if (p != -1)
            {
                customer[p].setCountry(newCountry);
            }
            else
            {
                Console.Write("The Country is wrong");
                Console.Write("\n");
            }
        }

        public void updatePhone(string email, int newPhone)
        {
            int p = poz(email);
            if (p != -1)
            {
                customer[p].setPhone(newPhone);
            }
            else
            {
                Console.Write("The Phone is wrong");
                Console.Write("\n");
            }
        }
        public Customer getCustomerByEmail(String email)
        {
            var result = this.customer.Where(Customer => Customer.getEmail() == email).FirstOrDefault();

            return result;
        }

        public Customer getUser(string email,string password)
        {
            var result = this.customer.Where(Customer => Customer.getEmail() == email && Customer.getPassword()==password).FirstOrDefault();

            return result;
        }

        //foreach(numeVariabila in ObjectList){
        //Console.WriteLine(numeVariabila.Name);

        public void load()
        {

            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\Customer.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {

                    var lineread = line.Split(" ");

                    int id;
                    id = int.Parse(lineread[0]);
                    string email;
                    email = lineread[1];
                    string password;
                    password = lineread[2];
                    string fullName;
                    fullName = lineread[3];
                    string billingAdress;
                    billingAdress = lineread[4];
                    string shippingAdress;
                    shippingAdress = lineread[5];
                    string country;
                    country = lineread[6];
                    int phone;
                    phone = int.Parse(lineread[7]);

                    if (id > 0)
                    {
                        Customer o = new Customer(id, email, password, fullName, billingAdress, shippingAdress, country, phone);

                        this.Add(o);
                    }
                }
            }
        }

        public string ToSave()
        {
            string text = "";
            int i = 0;

            for (i = 0; i < customer.Count - 1; i++)
            {
                text += customer[i].toSave() + "\n";
            }
            text += customer[i].toSave();

            return text;

        }

        public void save()
        {
            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\Customer.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine(ToSave());

            write.Close();
        }










    }
}
