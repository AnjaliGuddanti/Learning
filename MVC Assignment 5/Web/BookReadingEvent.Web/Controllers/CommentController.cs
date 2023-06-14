using AutoMapper;
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
    public class CommentController : Controller
    {

        private readonly ICreateEventService _eventServices;
        private readonly IMapper _mapper;
        public CommentController(ICreateEventService eventser, IMapper mapper)
        {
            _mapper = mapper;
            _eventServices = eventser;
        }
        public IActionResult Index(int id)
        {
            HttpContext.Session.SetString("Id", id.ToString());
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Comment commentDetails)
        {
            commentDetails.Email= HttpContext.Session.GetString("EmailId");
            commentDetails.EventID = int.Parse(HttpContext.Session.GetString("Id"));
            CommentDTO store = _mapper.Map<Comment, CommentDTO>(commentDetails);
            _eventServices.AddComment(store); // comment to commentDTO
            return RedirectToAction("Index", "MyEvent");
        }
    }
}
