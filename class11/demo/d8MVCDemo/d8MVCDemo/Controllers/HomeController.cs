﻿using d8MVCDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d8MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // example action w/o View attached
        //public string Index(int age, string name = "Josie")
        //{
        //    return $"Hello {name}, You are {age} years old. Welcome to Seattle";
        //}

        public IActionResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student{FirstName = "Meggan", LastName="Triplett", Age=50, FavoriteColor="Blue"},
            new Student { FirstName = "Richard", LastName = "Rosado", Age = 46, FavoriteColor = "Red" },
            new Student{FirstName = "Jon", LastName="Rice", Age=63, FavoriteColor="Orange"},
              new Student{FirstName = "Evan", LastName="Pettie", Age=23, FavoriteColor="Yellow"},
              new Student{FirstName = "Amanda", LastName="Iverson", Age=35, FavoriteColor="Purple"},
        };

                       
            return View(students);
        }

        [HttpGet]
        public ViewResult Greeting()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Greeting(string firstName, string lastName, int age, string favoriteColor)
        {
            Student student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                FavoriteColor = favoriteColor
            };

            return RedirectToAction("Results", student );
            // return RedirectToAction("Results", new {startYear, endYear});
            // MethodSig = public IActionResult Results(int startYear, int endYear)

        }

        [HttpGet]
        public IActionResult Results(Student student)
        {
            return View(student);
        }
    }
}
