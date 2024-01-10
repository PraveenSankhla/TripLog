using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using TripsLog.Models;

namespace TripsLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<TripLog> tripLog = new List<TripLog>();
            tripLog.Add(
                new TripLog
                {
                    Accommodations = "",
                    Destination = "Boise",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    todo = "Visit Tammy",
                }
            );
            tripLog.Add(
                new TripLog
                {
                    Accommodations = "The Bensol Hotel",
                    Destination = "Portland",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    todo = "Go to Voodoo Doughnuts, Walk in rain, Go to powell's",
                }
            );
            return View(tripLog);
        }

        [HttpGet]
        [Route("trips/Add")]
        public IActionResult AddTrip()
        {
            TripLog log = new TripLog();
            ViewData["SubHeading"] = "Add Trip Designation and Date";
            return View(log);
        }

        public IActionResult AddTripTwo(TripLog log)
        {
            TempData["Destination"] = log.Destination;
            TempData["Accommodations"] = log.Accommodations;
            TempData["StartDate"] = log.StartDate.ToString("yyyy-MM-dd");
            TempData["EndDate"] = log.EndDate.ToString("yyyy-MM-dd");
            ViewData["SubHeading"] = "Add Info For The Ritz";
            return View(log);
        }

        public IActionResult AddTripThree(TripLog log)
        {
            log.Destination = TempData["Destination"].ToString();
            log.Accommodations = TempData["Accommodations"].ToString();
            log.StartDate = Convert.ToDateTime(TempData["StartDate"]);
            log.EndDate = Convert.ToDateTime(TempData["EndDate"]);
            TempData["PhoneNumber"] = log.PhoneNumber;
            TempData["Email"] = log.Email;
            ViewData["City"] = "New York";
            ViewData["SubHeading"] = "Add Things To Do in " + ViewData["City"];
            TempData.Keep();
            return View(log);
        }

        public IActionResult SaveData(TripLog log)
        {
            log.Destination = TempData["Destination"].ToString();
            log.Accommodations = TempData["Accommodations"].ToString();
            log.StartDate = Convert.ToDateTime(TempData["StartDate"]);
            log.EndDate = Convert.ToDateTime(TempData["EndDate"]);
            log.PhoneNumber = Convert.ToInt32(TempData["PhoneNumber"]);
            log.Email = Convert.ToString(TempData["Email"]);
            return View();
        }
    }
}