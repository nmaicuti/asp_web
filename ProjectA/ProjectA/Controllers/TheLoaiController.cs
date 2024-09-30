﻿using ProjectA.Data;
using ProjectA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectA.Controllers
{
    [Area("Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

		[HttpPost]
		public IActionResult Create(TheLoai theLoai)
		{
            if (ModelState.IsValid)
            {
                //them thong tin
                _db.TheLoai.Add(theLoai);
                //luu lai thong tin
                _db.SaveChanges();
                //chuyen ve trang index
                return RedirectToAction("Index");
            }
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
			return View();
		}

        [HttpPost]
        public IActionResult Edit(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                //them thong tin
                _db.TheLoai.Update(theLoai);
                //luu lai thong tin
                _db.SaveChanges();
                //chuyen ve trang index
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TheLoai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if(!string.IsNullOrEmpty(searchString))
            {
                //use linq
                var theloai = _db.TheLoai
                    .Where(tl =>tl.Name.Contains(searchString))
                    .ToList();
                ViewBag.SearchString = searchString;
                ViewBag.TheLoai = theloai;
            }
            else
            {
                var theloai = _db.TheLoai.ToList();
                ViewBag.TheLoai = theloai;
            }
            return View("Index");
        }
    }
}
