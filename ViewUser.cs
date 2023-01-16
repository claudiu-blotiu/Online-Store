using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    class ViewUser
    {
        private Customer customer;
        private ControlProducts controlProducts;
        private ControlOrderDetails controlOrderDetails;
        private ControlOrder controlOrder;
        private Order order;

        public ViewUser(Customer customer)
        {
            this.customer = customer;

            controlProducts = new ControlProducts();

            controlOrderDetails = new ControlOrderDetails(controlProducts);

            controlOrder = new ControlOrder(controlOrderDetails);

            order = new Order(controlOrder.nextId(), customer.getId(), 0, customer.getShippingAdress(), customer.getBillingadress(), customer.getEmail(), 1, true);

            controlOrder.Add(order);
        }

        public string meniu()
        {
            string text = "";
            text += "--------------------------------------";
            text += "\nApasati tasta 1 pentru a adauga produse in cos";
            text += "\nApasati tasta 2 pentru a elimina produse din cos";
            text += "\nApasati tasta 3 pentru a vedea produsele din cos";
            text += "\nApasati tasta 4 pentru a vedea toate produsele din magazin";
            text += "\nApasati tasta 5 pentru a cumpara ce este in cos";
            text += "\nApasati tasta 6 pentru a vedea istoricul comenzilor";
            text += "\nApasati tasta 0 pentru a iesii in meniu";
            text += "\n--------------------------------------";
            text += "\n";

            return text;
        }

        public void play()
        {
            bool quit = false;
            int choice;

            while(quit==false)
            {
                Console.Write(meniu());

                string x = Console.ReadLine().ToString();

                while(x=="")
                {
                    x = Console.ReadLine().ToString();
                }

                choice = int.Parse(x);

                switch(choice)
                {
                    case 1:add();
                        break;
                    case 2:remove();
                        break;
                    case 3:viewCos();
                        break;
                    case 4:viewShop();
                        break;
                    case 5:buy();
                        break;
                    case 6:history();
                        break;
                    case 0:Console.WriteLine("La revedere"+ "\n");
                        break;
                }
            }
        }

        public void add()
        {
            string name = "";

            Console.WriteLine("Introduceti numele produsului." + "\n");

            name = Console.ReadLine().ToString();

            Products choice = controlProducts.getProductByName(name);

            if(choice.GetName()==name)
            {
                Console.WriteLine("Introduceti cantitatea dorita" + "\n");

                string cant;
                cant = Console.ReadLine().ToString();

                int Quantity = int.Parse(cant);

                if(choice.GetStock()>Quantity)
                {
                    OrderDetails detalii = new OrderDetails(controlOrderDetails.nextId(), order.getId(), choice.GetId(), choice.GetPrice() * Quantity, Quantity);

                    controlOrderDetails.Add(detalii);

                    controlProducts.updateStock(choice.GetName(), choice.GetStock() - Quantity);
                }
                else
                {
                    Console.WriteLine("Cantitatea introdusa nu este disponibila" + "\n");
                }


            }
        }

        public void viewShop()
        {
            controlProducts.show();
        }

        public void viewCos()
        {

            
            var orders = controlOrder.getOrders(this.customer.getId());

            foreach(var order in orders)
            {
                var produseDinCos = controlOrderDetails.getProducts(order.getId());

                foreach (var prod in produseDinCos)
                {

                    Products p = controlProducts.getProductByProductId(prod.getProductId());

                    string descriere = "";

                    descriere += "Produs " + p.GetName() + "\n";
                    descriere += "Pret Total " + prod.getPrice().ToString() + "\n";
                    descriere += "Cantitate " + prod.getQuantity().ToString() + "\n";

                    Console.WriteLine(descriere);
                }
            }
                
            
        }

        public void remove()
        {
            string name = "";

            Console.WriteLine("Introduceti numele produsului" + "\n");

            name = Console.Read().ToString();

            Products produse = controlProducts.getProductByName(name);

            for(int i=0;i<=controlOrderDetails.getCount();i++)
            {
                var produseDetaliate= controlOrderDetails.getProducts(i);

                foreach(var prod in produseDetaliate)
                {
                    if(prod.getProductId()==produse.GetId())
                    {
                        controlOrderDetails.Delete2(prod.getId());
                    }
                }

            }
        }

        public void buy()
        {
            
            controlOrder.save();

            controlOrderDetails.save();

            controlProducts.save();
        }

        public void history()
        {
            var istoric = controlOrder.getHistory(customer.getId());

            foreach(var order in istoric)
            {
                Console.WriteLine(order.description() + "\n");
            }

        }
    }
}
