using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller.Tests {
    [TestClass()]
    public class ExerciseControllerTests {
        [TestMethod()]
        public void AddTest() {
            // Arrange
            Random rnd = new Random();
            string userName = Guid.NewGuid().ToString();
            string activityName = Guid.NewGuid().ToString();
            UserController userController = new UserController(userName);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            Activity activity = new Activity(activityName, rnd.Next(10, 50));
            // Act
            exerciseController.Add(activity,
                DateTime.Now.AddMinutes(-rnd.Next(10, 60)),
                DateTime.Now);
            // Assert
            //Assert.AreEqual(activityName, exerciseController.Exercises.First().Activity.Name);
            Assert.AreEqual(activityName, exerciseController.Exercises.Last().Activity.Name);
            //Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}