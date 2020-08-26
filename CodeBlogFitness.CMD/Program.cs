using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Hello, I'm CodeBlogFitness the Application.");
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();
            //TODO: Check user name

            //var userController = new UserController(name, gender, birthDate, weight, height);
            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser) {
                Console.Write("Enter user gender: ");
                string gender = Console.ReadLine();
                DateTime birthDate = EnterDateTimePlease("user birth date (YYYY-mm-dd)");
                double height = EnterNumberPlease("user height");
                double weight = EnterNumberPlease("user weight");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E - enter eating.");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E) {
                var (food, weight) = EnterEating();
                eatingController.Add(food, weight);

                foreach (var item in eatingController.Eating.Foods) {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
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
