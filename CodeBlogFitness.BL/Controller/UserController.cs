using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {

    /// <summary>
    /// User controller
    /// </summary>
    public class UserController {

        /// <summary>
        /// User
        /// </summary>
        public User User { get; }

        public UserController(User user) {
            User = user ?? throw new ArgumentNullException("User cannot be null.", nameof(user));
        }

        /// <summary>
        /// Save user to file
        /// </summary>
        public void Save() {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate)) {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Load user from file
        /// </summary>
        /// <returns></returns>
        public UserController() {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.Open)) {
                if (formatter.Deserialize(fs) is User user) {
                    User = user;
                }
                else {
                    throw new FileLoadException("Cannot load User from this file.", "users.dat");
                }
            }
        }

        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height) {
            Gender gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }
    }
}
