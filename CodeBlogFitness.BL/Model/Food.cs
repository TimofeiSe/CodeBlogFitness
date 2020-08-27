using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model {

    [Serializable]
    public class Food {

        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Food name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// per 1 gram
        /// </summary>
        private double Proteins { get; set; }
        /// <summary>
        /// per 1 gram
        /// </summary>
        private double Fats { get; set; }
        /// <summary>
        /// per 1 gram
        /// </summary>
        private double Carbohydrates { get; set; }
        /// <summary>
        /// per 1 gram
        /// </summary>
        private double Calories { get; set; }
        #endregion


        public Food(string name) : this(name, 0, 0, 0, 0) {

        }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories) {
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString() {
            return $"{Name}";
        }
    }
}
