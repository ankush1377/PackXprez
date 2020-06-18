using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackXprezDataAccessLayer;

namespace Logistics.PackXprez.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        PackXprezRepository repository; 
        public AdminController() {
            repository = new PackXprezRepository();
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<PackXprezDataAccessLayer.Models.Users> userList = null;
            try
            {
                userList = repository.GetAllUsers();
            }
            catch (Exception ex)
            {
                userList = null;
            }
            return Json(userList);
        }

        [HttpPost]
        public bool RegisterUser(PackXprezDataAccessLayer.Models.Users user)
        {
            bool res = false;
            try
            {

                res = repository.RegisterUser(user.Name, user.EmailId, user.UserPassword,8727957268, "56","2","Ropar",140001,"Home") ;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }

        [HttpPost]
        public bool ValidateLogin(PackXprezDataAccessLayer.Models.Users user)
        {
            bool res = false;
            try
            {

                res = repository.ValidateLogin(user.EmailId,user.UserPassword);
            }
            catch (Exception)
            {
                res = false; 
            }
            return res;
        }

        [HttpPost]
        public bool CheckServiceAvailability(int fromPincode,int toPincode)
        {
            bool res = false;
            try
            {
                res = repository.CheckServiceAvailability(fromPincode,toPincode);
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }

        [HttpPost]
        public JsonResult SchedulePickUp(PackXprezDataAccessLayer.Models.Shipment package)
        {
           int res = -1;
            try
            {

                res = repository.SchedulePickup(package.ShipmentType, package.EmailId,(int)package.PackageLength, (int)package.PackageBreadth, 
                    (int)package.PackageHeight, 
                    (int)package.PackageWeight,
            package.PackagingRequired, package.DeliveryType, package.PickUpTime, (int)package.SenderAddressId,
            "49-p","27","Gurgaon",122002,8765643210);
            }
            catch (Exception)
            {
                res = -1;
            }
            return Json(res);
        }

        [HttpGet]
        public JsonResult TrackOrder(int AWBNumber)
        {
            string res = "";
            try
            {
                res = repository.TrackOrder(AWBNumber);
            }
            catch (Exception)
            {
                res = "On the way!";
            }
            return Json(res);
             

        }

        [HttpGet]
        public JsonResult OrderHistory(string emailId)
        {
            List<PackXprezDataAccessLayer.Models.Shipment> orders = null;
            try
            {
               orders = repository.OrderHistory(emailId);
            }
            catch (Exception)
            {
                orders = null;
            }
            return Json(orders);


        }

    }
}