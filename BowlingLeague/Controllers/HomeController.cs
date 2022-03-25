using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        //private IBowlersRespository _repo { get; set; }

        //public HomeController(IBowlersRespository temp)
        //{
        //    _repo = temp;
        //}

        private BowlersDbContext _context { get; set; }
        private TeamsDbContext _context2 { get; set; }
        public HomeController(BowlersDbContext temp, TeamsDbContext temp2)
        {
            _context = temp;
            _context2 = temp2;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var blah = _context.Bowlers
                .ToList();

            ViewBag.Teams = _context2.Teams.ToList();
            ViewBag.Yeet = "All";
            ViewBag.Yeet2 = 0;

            return View(blah);
        }

        [HttpPost]
        public IActionResult Index(int team)
        {
            var number = team;

            if (number == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var blah = _context.Bowlers
                .Where(b => b.TeamID == number)
                .ToList();

                var yeet = _context2.Teams.Single(x => x.TeamID == number);

                ViewBag.Teams = _context2.Teams.ToList();
                ViewBag.Yeet = yeet.TeamName;
                ViewBag.Yeet2 = yeet.TeamID;

                return View(blah);
            }
        }

        [HttpGet]
        public IActionResult Delete(int BowlerId)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == BowlerId);
            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("EditForm", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _context.Update(b);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditForm", b);
            }

        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateForm(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _context.Update(b);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}
