using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD {
    class Program {
        /// <summary>
        /// Entrypoint
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            Program program = new Program(args);
        }

        public Program(string[] args) {
            //var culture = CultureInfo.CurrentCulture;
            var culture = CultureInfo.InvariantCulture;
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.Write(resourceManager.GetString("Enter user name:", culture));
            string name = Console.ReadLine();
            //TODO: Check user name

            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser) {
                Console.Write(resourceManager.GetString("Enter user gender:", culture));
                string gender = Console.ReadLine();
                DateTime birthDate = EnterDateTimePlease("user birth date (YYYY-mm-dd)");
                double height = EnterNumberPlease("user height");
                double weight = EnterNumberPlease("user weight");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            while (true) {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("► A - enter exercise.");
                Console.WriteLine("► E - enter eating.");
                Console.WriteLine("► Q - exit.");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key) {
                    case ConsoleKey.E:
                        var (food, weight) = EnterEating();
                        eatingController.Add(food, weight);
                        foreach (var item in eatingController.Eating.Foods) {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        //var (activity, duration) = EnterExercise();
                        var exer = EnterExercise();
                        exerciseController.Add(exer.Activity, DateTime.Now.AddMinutes(-exer.Duration), DateTime.Now);
                        foreach (var item in exerciseController.Exercises) {
                            Console.WriteLine($"\t{item.Activity.Name} - {item.Start} .. {item.Finish}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                } 
            }
        }

        private (Activity Activity, double Duration) EnterExercise() {
            Console.WriteLine("Enter activity name: ");
            string activityName = Console.ReadLine();
            double caloriesPerMinute = EnterNumberPlease("calories per minute");
            double duration = EnterNumberPlease("duration");
            return (Activity: new Activity(activityName, caloriesPerMinute), 
                Duration: duration);
        }

        private (Food, double) EnterEating() {
            Console.Write("Enter food name: ");
            var foodName = Console.ReadLine();
            double calories = EnterNumberPlease("calories");
            double proteins = EnterNumberPlease("proteins");
            double fats = EnterNumberPlease("fats");
            double carbohydrates = EnterNumberPlease("carbohydrates");
            double foodWeight = EnterNumberPlease("dish weight");
            return (new Food(foodName, proteins, fats, carbohydrates, calories), foodWeight);
        }




        private static DateTime EnterDateTimePlease(string name) {
            while (true) {
                Console.Write($"Enter {name}: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
                    return result;
                else
                    Console.WriteLine("   incorrect date format !");
            }
        }

        private static double EnterNumberPlease(string name) {
            while (true) {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double result))
                    return result;
                else
                    Console.WriteLine("   incorrect number format !");
            }
        }


    }
}
