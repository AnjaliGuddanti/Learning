using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.Web.Models;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using AutoMapper;

namespace BookReadingEvent.Web.Controllers
{
   
    public class EventController : Controller
    {

        private readonly ICreateEventService _eventServices;
        private readonly IMapper _mapper;
        public EventController(ICreateEventService eventser,IMapper mapper)
        {
            _mapper = mapper;
            _eventServices = eventser;
        }
        public IActionResult Index()
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            ViewBag.UpcomingEvents = GetUpComingEvents();
            ViewBag.PastEvents = GetPastEvents();
            var data = GetAllEvents();
            return View(data);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public List<Event> GetAllEvents()
        {
            List<Event> result = new List<Event>();
            List<CreateEventDTO> store = _eventServices.GetAllPublicEvent();
            foreach (var x in store)
            {
                result.Add(_mapper.Map<CreateEventDTO, Event>(x));
            }
            return result;
        }
        public List<Event> GetUpComingEvents()
        {
            List<Event> result = new List<Event>();
            List<CreateEventDTO> store = _eventServices.GetUpcomingEvents();
            foreach (var x in store)
            {
                result.Add(_mapper.Map<CreateEventDTO, Event>(x));
            }
            SortByDate sortEventByDate = new SortByDate();
            result.Sort(sortEventByDate);
            result.Reverse();
            return result;
            
        }
        public List<Event> GetPastEvents()
        {
            List<Event> result = new List<Event>();
            List<CreateEventDTO> store = _eventServices.GetPastEvents();
            foreach (var x in store)
            {
                result.Add(_mapper.Map<CreateEventDTO, Event>(x));
            }
            SortByDate sortEventByDate = new SortByDate();
            result.Sort(sortEventByDate);
            result.Reverse();
            return result;
        }
      
    }
}
