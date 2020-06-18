using System;
using PackXprezDataAccessLayer.Models;
using System.Linq;
using System.Collections.Generic;


namespace PackXprezDataAccessLayer
{
    public class PackXprezRepository
    {
        PackXprezContext context;
        public PackXprezRepository()
        {
            context = new PackXprezContext();
        }

        //Testing connection
        public List<Users> GetAllUsers()
        {
            var usersList = (from user in context.Users
                                  select user).ToList();

            return usersList;
        }

        //Customer Register
        public bool RegisterUser(string name,string emailId,string password,long contactno,
            string buildingno,string streetno,string locality,int pincode,string addressType)
        {
            bool status_user=false;
            bool status_add=false;
            Users user = new Users();
            Users user_x;
            user.EmailId = emailId;
            user.Name = name;
            user.UserPassword = password;
            user.ContactNo = contactno;
            try
            {
                if (user != null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    status_user = true;

                    user_x =  (from user1 in context.Users
                                  where user1.EmailId == emailId
                                  select user1).FirstOrDefault<Users>();

                    int userId = user_x.UserId;
                    Address add = new Address();
                    add.UserId = userId;
                    add.BuildingNo = buildingno;
                    add.StreetNo = streetno;
                    add.Locality = locality;
                    add.Pincode = pincode;
                    add.AddressType = addressType;

                        try
                        {
                            context.Address.Add(add);
                            context.SaveChanges();
                            status_add = true;
                        }
                        catch (Exception e1)
                        {
                            try
                            {
                                context.Users.Remove(user_x);
                                context.SaveChanges();
                            }
                            catch (Exception e2)
                            {
                                Console.WriteLine(e2.InnerException);
                                status_user = false;
                            }
                            Console.WriteLine(e1.InnerException);
                            status_add = false;
                        }
                                        
                }
                else
                {
                    status_user = false;
                }

            }
            catch (Exception)
            {
                status_user = false;
            }


            return status_user && status_add;
        }

        //Customer Login
        public bool ValidateLogin(string emailId, string password)
        {
            bool status = false;
            try
            {
                var objUser = (from usr in context.Users
                               where usr.EmailId == emailId && usr.UserPassword == password
                               select usr).FirstOrDefault<Users>(); 

                if (objUser != null)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        //Check Service Availability
        public bool CheckServiceAvailability(int fromPincode,int toPincode) {
            var status = false;
            try
            {
                var serviceAvailableFrom = (from service in context.ServiceAvailable
                                        where service.Pincode == fromPincode
                                        select service).FirstOrDefault<ServiceAvailable>();

                var serviceAvailableTo= (from service in context.ServiceAvailable
                                         where service.Pincode == toPincode
                                         select service).FirstOrDefault<ServiceAvailable>();

                if (serviceAvailableFrom != null && serviceAvailableTo != null)
                    status = true;
            }
            catch (Exception e) {
                status = false;
            }
            return status;
        }

        //Schedule Pickup
        public int SchedulePickup(string shipmentType, string EmailId, int packageLength, int packageBreadth, int packageHeight, int packageWeight,
            string PackagingRequired, string deliveryType, string pickupTime, int SenderAddressId,
            string buildingno, string streetno, string locality, int pincode, long contactno)
        {
            
            int resPrice = -1;
            var status_add = false;
            Address add = new Address();

            add.BuildingNo = buildingno;
            add.StreetNo = streetno;
            add.Locality = locality;
            add.Pincode = pincode;

            try
            {
                context.Address.Add(add);
                context.SaveChanges();
                status_add = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                status_add = false;
            }

            if (status_add)
            {
                var add_x = (from add1 in context.Address
                             orderby add1.AddressId descending
                             select add1).FirstOrDefault<Address>();

                var lastShipment=(from shipment1 in context.Shipment orderby shipment1.TransactionId descending select shipment1).FirstOrDefault<Shipment>();

                int pickUpCharges = 200;
                int distance = 300;
                int perKmCharge = 7;
                int packagingCharge = 500;
                int costPerKg = 50;
                int costOfVolume = 50;
                int packageVolume = packageLength * packageBreadth * packageHeight;

                try
                {
                    Shipment shipment = new Shipment();
                    shipment.ShipmentType = shipmentType;
                    shipment.EmailId = EmailId;
                    shipment.Awbnumber = lastShipment.Awbnumber + 1;
                    shipment.PackageLength = packageLength;
                    shipment.PackageHeight = packageHeight;
                    shipment.PackageBreadth = packageBreadth;
                    shipment.PackageWeight = packageWeight;
                    shipment.PackagingRequired = PackagingRequired;
                    shipment.DeliveryType = deliveryType;
                    shipment.PickUpTime = pickupTime;
                    shipment.SenderAddressId = SenderAddressId;
                    shipment.ReceiverAddressId = add_x.AddressId;
                    shipment.OrderStatus = "Pending";

                    int TotalCost = pickUpCharges + distance * perKmCharge;
                    if (packageWeight > 5)
                        TotalCost += ((packageWeight - 5) * costPerKg);

                    if (packageVolume > 100)
                        TotalCost += ((packageVolume - 100) * costOfVolume);

                    if (PackagingRequired.ToLower() == "yes")
                        TotalCost += packagingCharge;

                    if (deliveryType.ToLower() == "overnight")
                        TotalCost += 500;

                    if (deliveryType.ToLower() == "express")
                        TotalCost += 100;



                    shipment.TotalCost = TotalCost;
                    resPrice = TotalCost;
                    context.Shipment.Add(shipment);
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException);
                    resPrice = -1;
                }
            }

            else
            {
                resPrice = -1;
            }

            return resPrice;

        }

        //Track Package
        public string TrackOrder(int AWBNumber)
        {
            string res = "";
            var shipment = (from order in context.Shipment
                            where order.Awbnumber == AWBNumber
                            select order).FirstOrDefault<Shipment>();

            if (shipment.OrderStatus == "Pending")
                res = "In transit!";

            else if (shipment.OrderStatus == "Received")
                res = "Reached Warehouse!";

            else if (shipment.OrderStatus == "Accepted")
                res = "Reached Delivery Centre!";

            else if (shipment.OrderStatus == "Delivered")
                res = "At receiver's location";

            else
                res = "On the way!";

            return res;

        }

        //Package History
        public List<Shipment> OrderHistory(string emailId)
        {
            var list1 = (from orders in context.Shipment
                         where orders.EmailId == emailId
                         select orders).ToList();

            

            //foreach(var x in list1)
            //{
               
            //    var senderAddress = (from add in context.Address
            //                         where add.AddressId == x.SenderAddressId
            //                         select add).FirstOrDefault<Address>();

            //    var receiverAddress = (from add in context.Address
            //                           where add.AddressId == x.ReceiverAddressId
            //                           select add).FirstOrDefault<Address>();


            //}

            return list1;
        }

    }
}
