﻿using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Controllers
{
    public class ToDoController : Controller
    {
        private readonly AppDbContext _db;

        public ToDoController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ToDoModel> toDoModels = _db.ToDoModels;
            return View(toDoModels);
        }

        public IActionResult IndexAll()
        {
            IEnumerable<ToDoModel> toDoModels = _db.ToDoModels;
            return View(toDoModels);
        }

        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                //Add
                return View(new ToDoModel());
            }
            else
            {
                //Update
                var obj = _db.ToDoModels.Find(id);
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(ToDoModel toDoModel)
        {
            if (ModelState.IsValid)
            {
                if (toDoModel.Id == 0)
                {
                    _db.Add(toDoModel);
                }
                else
                {
                    _db.Update(toDoModel);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoModel);
        }

        public IActionResult Delete(int id)
        {
            var toDoModel = _db.ToDoModels.Find(id);
            if (toDoModel == null || id == 0)
            {
                return NotFound();
            }
            _db.ToDoModels.Remove(toDoModel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Finish (int id)
        {
            //_db.ToDoModels.Find(id).IsItOver = true;
            var toDoModel = _db.ToDoModels.Find(id);
            toDoModel.IsItOver = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
