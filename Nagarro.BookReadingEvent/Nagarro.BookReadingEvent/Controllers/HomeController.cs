using Microsoft.AspNet.Identity;
using Nagarro.BookReadingEvent.Models;
using Nagarro.BookReadingEvent.Shared;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Nagarro.BookReadingEvent.Controllers
{
    public class HomeController : Controller
    {
        IEventFacade eventFacade = null;
        ICommentFacade commentFacade = null;
        IBookingEnrollmentFacade bookingFacade = null;

        public HomeController()
        {
            eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            commentFacade = (ICommentFacade)FacadeFactory.Instance.Create(FacadeType.CommentFacade);
            bookingFacade = (IBookingEnrollmentFacade)FacadeFactory.Instance.Create(FacadeType.BookingEnrollment);
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<EventDTO> events = null;
            List<EventDTO> list = eventFacade.GetAllEvents();
            events = list.ToPagedList(pageIndex, pageSize);
            return View(events);
        }

        public ActionResult CustomerSupport()
        {
            return Redirect("https://www.nagarro.com/en");
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        //  
        // POST: /Home/Create 
        [HttpPost]
        public ActionResult CreateEvent(EventDTO eventDTO)
        {
            eventDTO.Creator = User.Identity.GetUserName();
            OperationResult<EventDTO> result = eventFacade.CreateEvent(eventDTO);
            if (result.IsValid())
            {
                ViewBag.IsSuccess = "Data added successfully";
                
            }
            return View(eventDTO);
        }

        public ActionResult UpdateEvent(int EventId)
        {
            EventDTO eventDTO = eventFacade.GetEventById(EventId);
            return View(eventDTO);
        }

        [HttpPost]
        public ActionResult UpdateEvent(EventDTO eventDTO)
        {
            bool IsUpdated = eventFacade.UpdateEvent(eventDTO);
            if (IsUpdated == true)
            {
                ViewBag.IsSuccess = "Data updated successfully";
            }

            return View();
        }

        public ActionResult DeleteEvent(int EventId)
        {
            EventDTO eventDTO = eventFacade.GetEventById(EventId);
            return View(eventDTO);
        }


        [HttpPost]
        public ActionResult DeleteEvent(EventDTO eventDTO)
        {
            bool IsDeleted = eventFacade.DeleteEvent(eventDTO);
            if (IsDeleted == true)
            {
                ViewBag.IsSuccess = "Data deleted successfully";

            }
            return RedirectToAction("MyEvents");
        }

        public ActionResult Details(int EventId)
        {
            EventDTO eventDTO = eventFacade.GetEventById(EventId);
            return View(eventDTO);
        }

        public ActionResult MyEvents()
        {
            List<EventDTO> myEventList = eventFacade.GetAllEvents();
            string Username = User.Identity.GetUserName();
            List<EventDTO> bookedEventList = bookingFacade.GetAllEventsOfAUser(Username);
            var viewModel = new EventViewModel
            {
                Events = myEventList,
                BookedEvents = bookedEventList
            };
            return View(viewModel);
        }

        public ActionResult Invitations()
        {
            List<EventDTO> list = eventFacade.GetAllEvents();
            var viewModel = new EventViewModel
            {
                Events = list
            };
            return View(viewModel);
        }

        public ActionResult AddComment(int EventId)
        {
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.EventId = EventId;
            return View(commentDTO);
        }

        [HttpPost]
        public ActionResult AddComment(CommentDTO commentDTO)
        {

            commentDTO.Username = User.Identity.GetUserName();
            commentDTO.DatePosted = DateTime.Today;

            OperationResult<CommentDTO> result = commentFacade.AddNewComment(commentDTO);
            if (result.IsValid())
            {
                ViewBag.IsSuccess = "Comment added successfully";
            }
            return PartialView(commentDTO);
        }
        public ActionResult GetComments(int EventId)
        {
            List<CommentDTO> list = commentFacade.GetAllCommentsOfAnEvent(EventId);
            return PartialView(list);

        }

        public ActionResult GetAllUsersOfAnEvent(int EventId)
        {
            List<UserDTO> Users = bookingFacade.GetAllUsersOfAEvent(EventId);
            return View(Users);
        }

        public ActionResult AttendEvent(int EventId)
        {
            BookingEnrollmentDTO bookingEnrollmentDTO = new BookingEnrollmentDTO();
            EventDTO eventDTO = eventFacade.GetEventById(EventId);
            bookingEnrollmentDTO.Username = User.Identity.GetUserName();
            bookingEnrollmentDTO.EventsId = EventId;
            bookingEnrollmentDTO.Event = eventDTO;
            return View(bookingEnrollmentDTO);
        }

        [HttpPost]
        public ActionResult AttendEvent(BookingEnrollmentDTO bookingEnrollmentDTO)
        {
            bookingEnrollmentDTO.Username = User.Identity.GetUserName();
            BookingEnrollmentDTO bookingResult = bookingFacade.CreateBooking(bookingEnrollmentDTO);

            return RedirectToAction("MyEvents");

        }


    }
}