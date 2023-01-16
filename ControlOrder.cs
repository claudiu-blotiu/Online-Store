using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace OnlineStore
{
    class ControlOrder
    {
        private List<Order> order;
        private ControlOrderDetails orderDetails;

        public ControlOrder(ControlOrderDetails orderDetails)
        {
            order = new List<Order>();

            this.orderDetails = orderDetails;

            load();
        }

        public void Add(Order a)
        {
            order.Add(a);

        }

        public void show()
        {
            for (int i = 0; i < order.Count; i++)
            {
                Console.Write(order[i].description());
                Console.Write("\n");
            }
        }

        public int poz(int customerId)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].getCustomerId() == customerId)
                {
                    return i;
                }
            }
            return -1;
        }

        public int nextId()
        {
            if(order.Count==0)
            {
                return 1;
            }
            return order[order.Count - 1].getId() + 1;
        }
       
        public void Delete(int customerID)
        {
            int p = poz(customerID);

            for (int i = p; i < order.Count - 1; i++)
            {
                order[i] = order[i + 1];
            }
        }

        public void updateCustomerId(int customerID, int newCustomerID)
        {
            int p = poz(customerID);
            if (p != -1)
            {
                order[p].setCumstomerID(newCustomerID);
            }
            else
            {
                Console.Write("CustomerId not found");
                Console.Write("\n");
            }
        }

        public void updateAmmount(int customerId, int newAmmount)
        {
            int p = poz(customerId);
            if (p != -1)
            {
                order[p].setAmmount(newAmmount);
            }
            else
            {
                Console.Write("Wrong Ammount.");
                Console.Write("\n");
            }
        }

        public void updateShippingAdress(int customerId, string newShippingAdress)
        {
            int p = poz(customerId);
            if (p != -1)
            {
                order[p].setShippingAdress(newShippingAdress);
            }
            else
            {
                Console.Write("The Shipping adress is wrong");
                Console.Write("\n");
            }
        }

        public void updateOrderAdress(int customerId, string newOrderAdress)
        {
            int p = poz(customerId);
            if (p != -1)
            {
                order[p].setOrderAdress(newOrderAdress);
            }
            else
            {
                Console.Write("The Order adress is wrong");
                Console.Write("\n");
            }
        }

        public void updateOrderDate(int customerId, int newOrderDate)
        {
            int p = poz(customerId);
            if (p != -1)
            {
                order[p].setOrderDate(newOrderDate);
            }
            else
            {
                Console.Write("The Order Date is wrong");
                Console.Write("\n");
            }
        }
        public void updateOrderStatus(int customerId, bool newOrderStatus)
        {
            int p = poz(customerId);
            if (p != -1)
            {
                order[p].setOrderStatus(newOrderStatus);
            }
            else
            {
                Console.Write("The Order Status is wrong");
                Console.Write("\n");
            }
        }

        public List<Order> getHistory(int customerId)
        {
            var result = order.Where(Order => Order.getCustomerId() == customerId).ToList();

            //var distincOrder = result.OrderBy(order => order.getQuantity()).GroupBy(prod => prod.getProductId()).Select(grp => grp.First()).ToList();

            return result;

            //var result = this.order.Where(Order => Order.getCustomerId() == customerId).FirstOrDefault();

            //return result;
        }

        public List<Order> getOrders(int customerID)
        {
            var result=order.Where(ord=>ord.getCustomerId()==customerID).ToList();

            return result;
        }

        //foreach(numeVariabila in ObjectList){
        //Console.WriteLine(numeVariabila.Name);

        public void load()
        {

            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\Order.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {

                    var lineread = line.Split(" ");

                    int id;
                    id = int.Parse(lineread[0]);
                    int customerId;
                    customerId = int.Parse(lineread[1]);
                    int ammount;
                    ammount = int.Parse(lineread[2]);
                    string shippingAdress;
                    shippingAdress = lineread[3];
                    string orderAdress;
                    orderAdress = lineread[4];
                    string orderEmail;
                    orderEmail = lineread[5];
                    int orderDate;
                    orderDate = int.Parse(lineread[6]);
                    bool orderStatus;
                    orderStatus = bool.Parse(lineread[7]);

                    if (id > 0)
                    {
                        Order o = new Order(id, customerId, ammount, shippingAdress, orderAdress, orderEmail, orderDate, orderStatus);

                        this.Add(o);
                    }
                }
            }
        }

        public string ToSave()
        {
            string text = "";
            int i = 0;

            for (i = 0; i < order.Count - 1; i++)
            {
                text += order[i].toSave() + "\n";
            }
            text += order[i].toSave();

            return text;

        }

        public void save()
        {
            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\Order.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine(ToSave());

            write.Close();
        }
    }
}

