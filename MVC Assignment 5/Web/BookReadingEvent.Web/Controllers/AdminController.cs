using BookReadingEvent.ProductDomain.AppServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using AutoMapper;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Http;
namespace BookReadingEvent.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICreateEventService _userEventService;

        private readonly IMapper _mapper;
        // userservice is called dependency is injected 
        public AdminController(ICreateEventService usereventService,IMapper mapper)
        {
            _mapper = mapper;
            _userEventService = usereventService;
        }
        public IActionResult Index()
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            List<CreateEventDTO> allEvent = _userEventService.GetAllEvent();
            List<Event> allEventList= _mapper.Map<List<CreateEventDTO>, List<Event>>(allEvent);
            ViewBag.AdminEvent = allEventList;
            return View();
        }
    }
}
