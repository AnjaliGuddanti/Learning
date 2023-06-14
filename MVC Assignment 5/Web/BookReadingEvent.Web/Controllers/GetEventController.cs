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

namespace BookReadingEvent.Web.Controllers
{
    public class GetEventController : Controller
    {
        private readonly ICreateEventService _eventServices;
        private readonly IMapper _mapper;
        public GetEventController(ICreateEventService eventser,IMapper mapper)
        {
            _mapper = mapper;
            _eventServices = eventser;
        }
        public IActionResult Index(int id , string name,string layout)
        {
            ViewBag.checkLayout = layout;
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            ViewBag.check = name;
            if (_mapper.Map<List<CommentDTO>, List<Comment>>(_eventServices.GetAllComments(id)).Count > 0)
            {
                ViewBag.count = 1;
            }
            ViewBag.Comments = _mapper.Map<List<CommentDTO>, List<Comment>>(_eventServices.GetAllComments(id));
            CreateEventDTO newEvent = GetEventById(id);
            Event storeEvent = new Event();
            storeEvent.Date = newEvent.Date;
            storeEvent.Description = newEvent.Description;
            storeEvent.Title = newEvent.Title;
            storeEvent.StartTime = newEvent.StartTime;
            storeEvent.Location = newEvent.Location;
            storeEvent.Duration = newEvent.Duration;
            storeEvent.EventId = newEvent.EventId;
            storeEvent.OtherDetails = newEvent.OtherDetails;
            storeEvent.Creator = newEvent.Creator;
            return View(storeEvent);
        }
        public CreateEventDTO GetEventById(int id)
        {
            return  _eventServices.GetEventById(id);
        }
        public IActionResult DeleteByEventId(int id)
        {
            _eventServices.DeleteByEventId(id);
            return RedirectToAction("Index","MyEvent");
        }
        
    } 
}
