using BookReadingEvent.Core.ValueObjects;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserLoginService _userLogin;

        public LoginController(IUserLoginService userService)
        {
            _userLogin = userService;
        }

        public IActionResult Index(bool isSucess = false)
        {
            ViewBag.IsSucess = isSucess;
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserLogin userDetails)
        {
           
            LoginDTO obj = new LoginDTO
            {
                EmailID = userDetails.EmailID,
                Password = userDetails.Password

            };
            if (userDetails.EmailID== "myadmin@bookevents.com" && userDetails.Password=="admin")
            {
                HttpContext.Session.SetString("EmailId", userDetails.EmailID);
                return RedirectToAction("Index","Admin");
            }
            bool user = _userLogin.AddUser(obj);
            if(user== true)
            {
                HttpContext.Session.SetString("EmailId",userDetails.EmailID);
                return RedirectToAction("Index","Event");
            }
            else
            {
                ViewBag.IsSucess = true;
                return View();
            }    
     
        }
    }
}
