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
            Console.Write("Enter user gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter user birth date: ");
            DateTime birthDate;
            DateTime.TryParse(Console.ReadLine(), out birthDate);
            Console.Write("Enter user height: ");
            double height = Double.Parse(Console.ReadLine());
            Console.Write("Enter user weight: ");
            double weight = Double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();


        }
    }
}
