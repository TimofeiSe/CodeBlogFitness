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
    public class UserControllerTests {
        //[TestMethod()]
        //public void UserControllerTest() {
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void SetNewUserDataTest() {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            var gender = "Male";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);
            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);

        }

        [TestMethod()]
        public void SaveTest() {
            // Arrange
            string userName = Guid.NewGuid().ToString();
            // Act
            UserController controller = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}