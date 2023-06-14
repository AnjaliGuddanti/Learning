using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Newtonsoft.Json;

namespace BookReadingEvent.Web.Controllers
{
    public class UpdateEventController : Controller
    {
        private readonly ICreateEventService _userEventService;
        private readonly IMapper _mapper;

        // userservice is called dependency is injected 
        public UpdateEventController(ICreateEventService usereventService,IMapper mapper)
        {
            _mapper = mapper;
            _userEventService = usereventService;
        }
        public IActionResult Index(int id)
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            HttpContext.Session.SetString("EventId", id.ToString());
            return View();
        }

        [HttpPost]
        public IActionResult Index(Event EventDetails)
        {
            CreateEventDTO newEvent = new CreateEventDTO();
            newEvent.Date = EventDetails.Date; 
            newEvent.Description = EventDetails.Description;
            newEvent.Duration = EventDetails.Duration;
            newEvent.Location = EventDetails.Location; 
            newEvent.StartTime = EventDetails.StartTime;
            newEvent.Title = EventDetails.Title; 
            newEvent.Type = EventDetails.Type;
            newEvent.EventId = int.Parse(HttpContext.Session.GetString("EventId"));
            _userEventService.UpdateEvent(newEvent);
            return RedirectToAction("Index","MyEvent");
        }
        public JsonResult GetEventById()
        {
            int eventid = int.Parse(HttpContext.Session.GetString("EventId"));
            CreateEventDTO eventDetailsStore  =_userEventService.GetEventById(eventid);
            Event eventdetails=_mapper.Map<CreateEventDTO, Event>(eventDetailsStore);

            var json = JsonConvert.SerializeObject(eventdetails);
            
            return Json(json);
        }
    }
}
