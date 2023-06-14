using BookReadingEvent.Core.ValueObjects;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BookReadingEvent.Web.Controllers
{
    public class SignupController : Controller
    {

        private readonly IUserService _userService;


        // userservice is called dependency is injected 
        public SignupController(IUserService userService)
        {
            _userService = userService;
        }
        

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult Index(SignUp userDetails)  
        {
            if (ModelState.IsValid)
            {
                SignUpDTO obj = new SignUpDTO
                {
                    EmailID = userDetails.EmailID,
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    Password = userDetails.Password
                };
                bool user = _userService.AddUser(obj);
                if (user == true)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();

        }
    }
}
