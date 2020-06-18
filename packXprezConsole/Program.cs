using System;
using PackXprezDataAccessLayer;

namespace packXprezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestConnection();
            PackXprezRepository repository = new PackXprezRepository();
            //var users = repository.GetAllUsers();
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine("EmailId\t\t\tName");
            //Console.WriteLine("----------------------------------");
            //foreach (var category in users)
            //{
            //    Console.WriteLine("{0}\t{1}", category.EmailId, category.Name);
            //}

            //Customer login
            //var status = repository.ValidateLogin("deepika@gmail.com", "lilas@123");
            //if (status)
            //    Console.WriteLine("Login Successful");
            //else
            //    Console.WriteLine("Invalid Credentials.Please try again!");


            //Registration
            //var status = repository.RegisterUser("pqr", "pqr@gmail.com", "pqr@123", 8722000584, "58", "3", "Ropar", 140001, "Home");
            //if (status)
            //    Console.WriteLine("Registration Successful");
            //else
            //    Console.WriteLine("Registration failed.Please try again!");

            //Check Service Availability
            var status = repository.CheckServiceAvailability(140001, 160012);
            if (status)
                Console.WriteLine("Service Available");
            else
                Console.WriteLine("Service is not Available here!");

            //Schedule PickUp
            //int approxCost = repository.SchedulePickup("Heavy", "deepika@gmail.com", 100, 2, 3, 6, "no", "Overnight", "12:00pm-1:30pm", 3, "51", "4", "Chandigarh", 160012, 8798761234);
            //if (approxCost == -1)
            //    Console.WriteLine("Some Error occured!");
            //else
            //    Console.WriteLine("Shipment Placed Succesfully and approx cost will be Rs." + approxCost);

            //Track Package
            //string status = repository.TrackOrder(1006);
            //Console.WriteLine(status);


            //Package History
            //var orders = repository.OrderHistory("deepika@gmail.com");
            //if (orders.Count != 0)
            //{
            //    Console.WriteLine("----------------------------------");
            //    Console.WriteLine("TransactionId\tAWBNumber\tFrom Location\tTo Location\tStatus");
            //    Console.WriteLine("----------------------------------");
            //    foreach (var order in orders)
            //    {
            //        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", order.TransactionId, order.Awbnumber, order.SenderAddressId, order.ReceiverAddressId, order.OrderStatus);
            //    }
            //}
            //else
            //    Console.WriteLine("Not placed any orders yet!");

        }
        //public static void TestConnection()
        //{

        //    DataAccessLayer dal = new DataAccessLayer();
        //    if (dal.TestConnection())
        //    {
        //        Console.WriteLine("\n\n Connection successful \n");
        //    }
        //    else
        //    {
        //        Console.WriteLine("\n\n Some error occured \n");
        //    }

        //}
    }
}
