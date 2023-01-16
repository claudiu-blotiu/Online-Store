using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace OnlineStore
{
    class ControlOrderDetails
    {
        private List<OrderDetails> orderDetails;
        private ControlProducts controlProducts;

        public ControlOrderDetails(ControlProducts controlProducts)
        {
            orderDetails = new List<OrderDetails>();

            this.controlProducts = controlProducts;

            load();
        }

        public void Add(OrderDetails a)
        {
            orderDetails.Add(a);

        }

        public void show()
        {
            for (int i = 0; i < orderDetails.Count; i++)
            {
                Console.Write(orderDetails[i].description());
                Console.Write("\n");
            }
        }

        public int poz(int orderId)
        {
            for (int i = 0; i < orderDetails.Count; i++)
            {
                if (orderDetails[i].getOrderId() == orderId)
                {
                    return i;
                }
            }
            return -1;
        }
        public int poz1(int Id)
        {
            for (int i = 0; i < orderDetails.Count; i++)
            {
                if (orderDetails[i].getId() == Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public int nextId()
        {
            if (orderDetails.Count == 0)
            {
                return 1;
            }
            return orderDetails[orderDetails.Count - 1].getId() + 1;
        }

        public int getCount()
        {
            return orderDetails.Count;
        }

        public void Delete(int orderId)
        {
            int p = poz(orderId);

            for (int i = p; i < orderDetails.Count - 1; i++)
            {
                orderDetails[i] = orderDetails[i + 1];
            }
        }

        public void Delete2(int Id)
        {
            int p = poz1(Id);

            for (int i = p; i < orderDetails.Count - 1; i++)
            {
                orderDetails[i] = orderDetails[i + 1];
            }
        }

        public void updateOrderID(int orderId, int newOrderID)
        {
            int p = poz(orderId);
            if (p != -1)
            {
                orderDetails[p].setOrderId(newOrderID);
            }
            else
            {
                Console.Write("OrderID not found");
                Console.Write("\n");
            }
        }

        public void updateProductId(int orderID, int newProductID)
        {
            int p = poz(orderID);
            if (p != -1)
            {
                orderDetails[p].setProductID(newProductID);
            }
            else
            {
                Console.Write("Wrong ProductID.");
                Console.Write("\n");
            }
        }

        public void updatePrice(int orderID, int newPrice)
        {
            int p = poz(orderID);
            if (p != -1)
            {
                orderDetails[p].setPrice(newPrice);
            }
            else
            {
                Console.Write("The Price is wrong");
                Console.Write("\n");
            }
        }

        public void updateQuantity(int orderID, int newQuantity)
        {
            int p = poz(orderID);
            if (p != -1)
            {
                orderDetails[p].setQuantity(newQuantity);
            }
            else
            {
                Console.Write("The Quantity is wrong");
                Console.Write("\n");
            }
        }

        public OrderDetails getOrderDetails(string productName,int orderID)
        {
   
            int productId = this.controlProducts.getProductByName(productName).GetId();

            var result = this.orderDetails.Where(OrderDet => OrderDet.getOrderId() == orderID && OrderDet.getProductId()==productId).FirstOrDefault();

            return result;
        }

        public OrderDetails getOrderDetailsByOrderId(int orderID)
        {
            var result = this.orderDetails.Where(OrderDet => OrderDet.getOrderId() == orderID).FirstOrDefault();

            return result;
        }

        public List<OrderDetails> getProducts(int orderID)
        {
            var result = orderDetails.Where(OrderDet => OrderDet.getOrderId() == orderID).ToList();

            var distincOrderDet = result.OrderBy(orderDet=> orderDet.getQuantity()).GroupBy(prod => prod.getProductId()).Select(grp => grp.First()).ToList();

            return distincOrderDet;
        }

        //foreach(numeVariabila in ObjectList){
        //Console.WriteLine(numeVariabila.Name);

        public void load()
        {
            
            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\OrderDetails.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {

                    var lineread = line.Split(" ");
                    
                      int id;
                      id = int.Parse(lineread[0]);
                      int orderID;
                      orderID = int.Parse(lineread[1]);
                      int productID;
                      productID = int.Parse(lineread[2]);
                      int price;
                      price = int.Parse(lineread[3]);
                      int quantity;
                      quantity = int.Parse(lineread[4]);

                      if(id>0)
                      {
                            OrderDetails od = new OrderDetails(id, orderID, productID, price, quantity);

                            this.Add(od);
                      }

                    
                }

            }
        }

        public string ToSave()
        {
            string text = "";
            int i = 0;

            for (i = 0; i < orderDetails.Count - 1; i++)
            {
                text += orderDetails[i].toSave() + "\n";
            }
            text += orderDetails[i].toSave();

            return text;

        }

        public void save()
        {
            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\OrderDetails.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine(ToSave());

            write.Close();
        }
    }
}

