﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller.Tests {
    [TestClass()]
    public class EatingControllerTests {
        [TestMethod()]
        public void AddTest() {
            // Arrange
            var rnd = new Random();
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            UserController userController = new UserController(userName);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            Food food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            // Act
            eatingController.Add(food, rnd.Next(50, 500));
            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);

        }
    }
}