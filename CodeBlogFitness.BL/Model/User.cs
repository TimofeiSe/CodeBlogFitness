using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model {
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User {
        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User gender
        /// </summary>
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        /// <summary>
        /// User birth date
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// User weigth (kilograms)
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// User height (centimeters)
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Age, calculated
        /// </summary>
        public int Age {
            get {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age))
                    age--;
                return age;
            }
        }
        #endregion

        public User(string name) {
            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentNullException("User name cannot be null or empty.", nameof(name));
            }
            Name = name;
        }

        public User(    string name, 
                        Gender gender, 
                        DateTime birthDate, 
                        double weight, 
                        double height) {
            #region Check arguments
            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentNullException("User name cannot be null or empty.", nameof(name));
            }
            if (gender is null) {
                throw new ArgumentNullException("User gender cannot be null.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("1900-01-01")) {
                throw new ArgumentException("User birth date cannot be earlier than 1900-01-01.", nameof(birthDate));
            }
            if (birthDate > DateTime.Now) {
                throw new ArgumentException("User birth date cannot be in the future.", nameof(birthDate));
            }
            if (weight <= 0) {
                throw new ArgumentException("User weight cannot be zero or below.", nameof(weight));
            }
            if (height <= 0) {
                throw new ArgumentException("User height cannot be zero or below.", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString() {
            return $"{Name} (age {Age})";
        }
    }
}
