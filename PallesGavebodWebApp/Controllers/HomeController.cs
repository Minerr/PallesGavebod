using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PallesGavebodWebApp.Models;

namespace PallesGavebodWebApp.Controllers
{
	public class HomeController : Controller
	{
		private MainDbContext _context;

		public HomeController(MainDbContext mainDbContext)
		{
			_context = mainDbContext;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		
		public IActionResult Overview()
		{
			return View();
		}

		public IActionResult OverviewGirlgifts()
		{
			return View();
		}

		public IActionResult AddGift()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		} 
	}
}
