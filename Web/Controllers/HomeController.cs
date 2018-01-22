using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly IFlightRepository _flightRepository;

        public HomeController(
            IAircraftRepository aircraftRepository, 
            IAirportRepository airportRepository, 
            IFlightRepository flightRepository)
        {
            _aircraftRepository = aircraftRepository;
            _airportRepository = airportRepository;
            _flightRepository = flightRepository;
        }
        public IActionResult Index()
        {
            var aircrafts = _aircraftRepository.GetAll();
            var airports = _airportRepository.GetAll();
            var flights = _flightRepository.GetAll();

            var viewModel = new AllViewModel
            {
                Aircrafts = aircrafts,
                Airports = airports,
                Flights = flights
            };
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
