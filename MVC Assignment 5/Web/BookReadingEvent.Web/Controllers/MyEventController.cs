using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookReadingEvent.ProductDomain.AppServices;

namespace BookReadingEvent.Web.Controllers
{
    public class MyEventController : Controller
    {
        private readonly ICreateEventService _eventServices;
        public MyEventController(ICreateEventService eventser)
        {
            _eventServices = eventser;
        }
        public IActionResult Index()
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            ViewBag.MyEvents = MyEvents();
            return View();
        }
        public List<Event> MyEvents()
        {
            List<Event> result = new List<Event>();
            var email = HttpContext.Session.GetString("EmailId");
            List<CreateEventDTO> store = _eventServices.MyEvents(email);
            foreach (var x in store)
            {
                Event showEvent = new Event();
                showEvent.Date = x.Date;
                showEvent.Description = x.Description;
                showEvent.Duration = x.Duration;
                showEvent.InviteByEmail = x.InviteByEmail;
                showEvent.Location = x.Location;
                showEvent.OtherDetails = x.OtherDetails;
                showEvent.StartTime = x.StartTime;
                showEvent.Title = x.Title;
                showEvent.Type = x.Type;
                showEvent.EventId = x.EventId;
                result.Add(showEvent);
            }
            return result;
        }
    }
}
