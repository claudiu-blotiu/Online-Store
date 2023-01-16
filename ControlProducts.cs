using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace OnlineStore
{
    class ControlProducts
    {
         private List<Products> products;

        

        public ControlProducts()
        {
             products = new List<Products>();

            load();
        }

        public void Add(Products a)
        {
            products.Add(a);
            

        }

        public void show()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write(products[i].description());
                Console.Write("\n");
            }
        }

        public int poz(string name)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].GetName() == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public int nextId()
        {
            if (products.Count == 0)
            {
                return 1;
            }
            return products[products.Count - 1].GetId() + 1;
        }

        public void Delete(string name)
        {
            int p = poz(name);

            for(int i=p;i< products.Count - 1;i++)
            {
                products[i] = products[i + 1];
            }
            
        }

        public void updateName(string name, string newName)
        {
            int p = poz(name);
            if (p != -1)
            {
                products[p].SetName(newName);
            }
            else
            {
                Console.Write("Name not found");
                Console.Write("\n");
            }
        }

        public void updateWeight(string name, int newWeight)
        {
            int p = poz(name);
            if (p != -1)
            {
                products[p].SetWeight(newWeight);
            }
            else
            {
                Console.Write("Wrong weight.");
                Console.Write("\n");
            }
        }

        public void updatePrice(string name, int newPrice)
        {
            int p = poz(name);
            if (p != -1)
            {
                products[p].SetPrice(newPrice);
            }
            else
            {
                Console.Write("The Price is wrong");
                Console.Write("\n");
            }
        }

        public void updateStock(string name, int newStock)
        {
            int p = poz(name);
            if (p != -1)
            {
                products[p].SetStock(newStock);
            }
            else
            {
                Console.Write("The Product dosent exist");
                Console.Write("\n");
            }
        }

        public Products getProductByName(string name)
        {
            var result = this.products.Where(produs => produs.GetName() == name).FirstOrDefault();

            return result;
        }

        public Products getProductByProductId(int productID)
        {
            var result = this.products.Where(produs => produs.GetId() == productID).FirstOrDefault();
            

            return result;
        }

        //foreach(numeVariabila in ObjectList){
        //Console.WriteLine(numeVariabila.Name);

        public void load()
        {
            string name = "";
           
            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\Products.txt";

            using (StreamReader reader=new StreamReader(path))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {

                    var lineread = line.Split(" ");
                    name = lineread[0];
                    if (name != "")
                    {
                        int id;
                        id = int.Parse(lineread[1]);
                        int weight;
                        weight = int.Parse(lineread[2]);
                        int price;
                        price = int.Parse(lineread[3]);
                        int stock;
                        stock = int.Parse(lineread[4]);

                        if (name.Contains("Food"))
                        {
                            string type;
                            type = lineread[5];

                            Products a = new Food(type, id, weight, price, stock);

                            this.Add(a);
                        }
                        if (name.Contains("Toys"))
                        {
                            int minimAge;
                            minimAge = int.Parse(lineread[5]);

                            Products b = new Toys(minimAge, id, weight, price, stock);

                            this.Add(b);
                        }
                        if (name.Contains("Electronics"))
                        {
                            string brand;
                            brand = lineread[5];

                            Products c = new Electronics(brand, id, weight, price, stock);

                            this.Add(c);
                        }

                    }
                }

            }
        }

        public string ToSave()
        {
            string text = "";
            int i = 0;

            for(i=0;i<products.Count-1;i++)
            {
                text += products[i].toSave() + "\n";
            }
            text += products[i].toSave();

            return text;

        }

        public void save()
        {
            string path = @"H:\Facultate\Anul 3\Medii de programare\OnlineStore\Products.txt";

            StreamWriter write = new StreamWriter(path);

            write.WriteLine(ToSave());

            write.Close();
        }

    }
}
