using ConsoleTools;
using HLHJZJ_ADT_2023241.Client;
using HLHJZJ_ADT_2023241.Models;

namespace HXINTL_HFT_2022232.Client
{
    class Program
    {

        public static RestService rserv = new RestService("http://localhost:21071");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);


            var menu = new ConsoleMenu()
               .Add("CRUD methods", () => CrudMenu())
               .Add("non-CRUD methods", () => NonCrudMenu())
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void CrudMenu()
        {

            var menu = new ConsoleMenu()
                .Add("Create element", CreatePreMenu)
                .Add("Get one element", ReadPreMenu)
                .Add("Get all elements", ReadAllPreMenu)
                .Add("Update element", UpdatePreMenu)
                .Add("Delete element", DeletePreMenu)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        private static void NonCrudMenu()
        {
            var menu = new ConsoleMenu()
               .Add("Get Interest at the Minions Topic", GetInterestAtMinionsTopic)
               .Add("Get Interest where the Product price is over 4K$", GetInterestWhereProductPriceIsOver4)
               .Add("Get Interest where the Product name is Minions Product1", GetInterestWhereProductModelNameIsMinionsProduct1)
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void PreMenu(Action RentMotor, Action Motor, Action Brand)
        {
            var menu = new ConsoleMenu()
                .Add("RentMotor", RentMotor)
                .Add("Motor", Motor)
                .Add("Brand", Brand)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        //-------------------------------------------------------------------------------------------------------------CRUD------------------------------------------------

        //---------------------Create-------------------------
        private static void CreatePreMenu()
        {
            PreMenu(CreateInterest, CreateProduct, CreateTopic);
        }

        private static void CreateTopic()
        {
            Console.WriteLine("Topic: ");
            string name = Console.ReadLine();
            Console.WriteLine("Age:");
            rserv.Post<Topic>(new Topic() { Name = name, }, "Topic");
        }

        private static void CreateProduct()
        {
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Vendor code:");
            string vendorCode = Console.ReadLine();
            Console.WriteLine("Cost: ");
            int cost = int.Parse(Console.ReadLine());
            rserv.Post<Product>(new Product() { Id = id, VendorCode = vendorCode, Cost = cost }, "Product");
        }

        private static void CreateInterest()
        {
            Console.WriteLine("Name: ");
            string interestName = Console.ReadLine();
            Console.WriteLine("ID:");
            int interestID = int.Parse(Console.ReadLine());
            rserv.Post<Interest>(new Interest() { Name = interestName, Id = interestID }, "Interest");
        }

        //---------------------END-Create-------------------





        //---------------------Read------------------------
        private static void ReadPreMenu()
        {
            PreMenu(ReadInterest, ReadProduct, ReadTopic);
        }

        private static void ReadTopic()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getTopic = rserv.Get<Topic>(id, "Topic");
            Console.WriteLine($"Id: {getTopic.Id}, Name: {getTopic.Name}");
            Console.ReadLine();

        }

        private static void ReadProduct()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getProduct = rserv.Get<Product>(id, "Product");
            Console.WriteLine($"Id: {getProduct.Id}, Vendor code: {getProduct.VendorCode}, Cost: {getProduct.Cost}");
            Console.ReadLine();
        }

        private static void ReadInterest()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getInterest = rserv.Get<Interest>(id, "Interest");
            Console.WriteLine($"Id: {getInterest.Id}, Name: {getInterest.Name}");
            Console.ReadLine();
        }

        //---------------------END-Read-------------------





        //----------------------ReadAll----------------------
        private static void ReadAllPreMenu()
        {
            PreMenu(PrintAllInterest, PrintAllProducts, PrintAllTopics);
        }

        private static void PrintAllInterest()
        {
            var Interest = rserv.Get<Interest>("Interest");
            Console.WriteLine("-------------Interest-------------");
            InterestToConsole(Interest);
            Console.ReadLine();
        }
        private static void PrintAllProducts()
        {
            var Products = rserv.Get<Product>("Products");
            Console.WriteLine("-------------Products-------------");
            ProductToConsole(Products);
            Console.ReadLine();
        }
        private static void PrintAllTopics()
        {
            var Topics = rserv.Get<Topic>("Topics");
            Console.WriteLine("-------------Topics-------------");
            TopicToConsole(Topics);
            Console.ReadLine();
        }
        //---------------END-ReadAll-------------------





        //-----------------Update-------------------
        private static void UpdatePreMenu()
        {
            PreMenu(UpdateInterest, UpdateProduct, UpdateTopic);
        }

        private static void UpdateTopic()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Name: ");
            string TopicName = Console.ReadLine();
            Topic input = new Topic() { Id = id, Name = TopicName};
            rserv.Put(input, "Topic");
        }

        private static void UpdateProduct()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Vendor code: ");
            string vendorCode = Console.ReadLine();
            Console.WriteLine("Cost: ");
            int cost = int.Parse(Console.ReadLine());
            Product input = new Product() { Id = id, VendorCode = vendorCode, Cost = cost };
            rserv.Put(input, "Product");
        }

        private static void UpdateInterest()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Interest input = new Interest() { Id = id, Name = name };
            rserv.Put(input, "Interest");
        }

        //-----------------END-Update-------------





        //-----------------Delete--------------
        private static void DeletePreMenu()
        {
            PreMenu(DeleteInterest, DeleteProduct, DeleteTopic);
        }

        private static void DeleteTopic()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Topic");
        }

        private static void DeleteProduct()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Product");
        }

        private static void DeleteInterest()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Interest");
        }

        //-------------------END-Delete----------













        ////-------------------------------------------------------------------------------------------------------------non-CRUD------------------------------------------------

        private static void GetInterestAtMinionsTopic()
        {
            var output = rserv.Get<Interest>("stat/GetInterestAtMinionsTopic");

            InterestToConsole(output);
            Console.ReadLine();
        }
        private static void GetInterestWhereProductPriceIsOver4()
        {
            var output = rserv.Get<Interest>("stat/GetInterestWhereProductPriceIsOver4");
            InterestToConsole(output);
            Console.ReadLine();
        }

        private static void GetInterestWhereProductModelNameIsMinionsProduct1()
        {
            var output = rserv.Get<Interest>("stat/GetInterestWhereProductModelNameIsMinionsProduct1");
            InterestToConsole(output);
            Console.ReadLine();
        }
        private static void GetInterestWhereTopicIsMinionsProduct()
        {
            var output = rserv.Get<Topic>("stat/GetInterestWhereTopicIsMinionsProduct");
            TopicToConsole(output);
            Console.ReadLine();
        }
       





        ////-------------------------------------------------------------------------------------------------------------ToConsole------------------------------------------------
        private static void InterestToConsole(IEnumerable<Interest> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
            }
        }
        private static void ProductToConsole(IEnumerable<Product> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, Vendor code: {item.VendorCode}, Cost: {item.Cost}, TopicId: {item.Topic_id}");
            }
        }
        private static void TopicToConsole(IEnumerable<Topic> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
            }
        }
    }


}





