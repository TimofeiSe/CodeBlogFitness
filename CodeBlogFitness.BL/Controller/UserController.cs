using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {

    /// <summary>
    /// User controller
    /// </summary>
    public class UserController : ControllerBase {

        private const string USERS_FILE_NAME = "users.dat";

        /// <summary>
        /// Users list
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Current user
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        //public UserController(User user) {
        //    Users = user ?? throw new ArgumentNullException("User cannot be null.", nameof(user));
        //}

        public UserController(string userName) {
            if (string.IsNullOrWhiteSpace(userName)) {
                throw new ArgumentNullException("User name cannot be null or empty.", nameof(userName));
            }
            Users = GetUsersData() ?? new List<User>();
            CurrentUser = Users.SingleOrDefault(x => x.Name == userName);
            if (CurrentUser is null) {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 70, double height = 150) {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Height = height;
            CurrentUser.Weight = weight;
            Save();
        }

        /// <summary>
        /// Load users list from file
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData() {
            return base.Load<List<User>>(USERS_FILE_NAME);
        }

        /// <summary>
        /// Save user to file
        /// </summary>
        public void Save() {
            base.Save(USERS_FILE_NAME, Users);
        }

    }
}
