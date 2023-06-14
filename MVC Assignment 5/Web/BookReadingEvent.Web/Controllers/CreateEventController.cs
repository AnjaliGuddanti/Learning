using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace BookReadingEvent.Web.Controllers
{
    public class CreateEventController : Controller
    {
        private readonly ICreateEventService _userService;


        // userservice is called dependency is injected 
        public CreateEventController(ICreateEventService userService)
        {
            _userService = userService;
        }
     
        public IActionResult Index()
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Event EventDetails)
        {
            CreateEventDTO newEvent = new CreateEventDTO();
            newEvent.Date = EventDetails.Date;
            newEvent.Description = EventDetails.Description;
            newEvent.Duration = EventDetails.Duration;
            newEvent.InviteByEmail = EventDetails.InviteByEmail;
            newEvent.Location = EventDetails.Location;
            newEvent.OtherDetails = EventDetails.OtherDetails;
            newEvent.StartTime = EventDetails.StartTime;
            newEvent.Title = EventDetails.Title;
            newEvent.Type = EventDetails.Type;
            newEvent.Creator = HttpContext.Session.GetString("EmailId");
            _userService.AddEvent(newEvent);
            if (EventDetails.InviteByEmail != null)
            {
                string EmailID = HttpContext.Session.GetString("EmailId");
                _userService.TagInvitedEventToUser(EventDetails.InviteByEmail, EmailID);
            }
            
            return RedirectToAction("Index","MyEvent");
        }
    }
}
