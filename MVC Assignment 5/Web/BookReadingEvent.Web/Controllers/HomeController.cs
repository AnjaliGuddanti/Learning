using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookReadingEvent.Web.Models;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace BookReadingEvent.Web.Controllers
{
    public class SortByDate : IComparer<Event>
    {
        public int Compare(Event x, Event y)
        {
            return (x.Date.ToShortDateString().ToString()).CompareTo((y.Date.ToShortDateString().ToString()));
        }
    }
    public class HomeController : Controller
    {
       
        private readonly ICreateEventService _eventServices;
        private readonly IMapper _mapper;
        public HomeController(ICreateEventService eventser,IMapper mapper)
        {
            _mapper = mapper;
            _eventServices = eventser;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("EmailId") !=null)
            {
                return RedirectToAction("Index","Event");
            }
            ViewBag.UpcomingEvents =GetUpComingEvents();
            ViewBag.PastEvents = GetPastEvents();
            var data = GetAllEvents();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                Event showEvent = new Event();

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
                Event showEvent = new Event();

                result.Add(_mapper.Map<CreateEventDTO, Event>(x));
            }
            SortByDate sortEventByDate = new SortByDate();
            result.Sort(sortEventByDate);
            result.Reverse();
            return result;
        }


    }
}
