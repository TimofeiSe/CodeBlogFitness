using CodeBlogFitness.BL.Controller;
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
            var userController = new UserController(name);
            if (userController.IsNewUser) {
                Console.Write("Enter user gender: ");
                string gender = Console.ReadLine();
                DateTime birthDate = EnterDateTimePlease("user birth date (YYYY-mm-dd)");
                double height = EnterNumberPlease("user height");
                double weight = EnterNumberPlease("user weight");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
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
