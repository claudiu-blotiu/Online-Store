using System;


namespace OnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {

            //Products test = new Products(1,"Apa",10,100,1000);


            Customer f = new Customer(3, "Alinutza", "Scoala", "AlinutzaA", "acasa", "job", "RO", 98234);

            ViewUser viewUser=new ViewUser(f);

            viewUser.play();


            //Console.WriteLine("Hello World!");
        }
    }
}
