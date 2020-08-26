using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model {

    [Serializable]
    public class Food {
        
        #region Properties
        /// <summary>
        /// Food name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Proteins per 100 g
        /// </summary>
        public double Proteins { get => ProteinsPerGram * 100.0; }
        /// <summary>
        /// Fats per 100 g
        /// </summary>
        public double Fats { get => FatsPerGram * 100.0; }
        /// <summary>
        /// Carbohydrates per 100 g
        /// </summary>
        public double Carbohydrates { get => CarbohydratesPerGram * 100.0; }
        /// <summary>
        /// Calories per 100 g
        /// </summary>
        public double Calories { get => CaloriesPerGram * 100.0; }

        private double ProteinsPerGram { get; }
        private double FatsPerGram { get; }
        private double CarbohydratesPerGram { get;  }
        private double CaloriesPerGram { get; }
        #endregion


        public Food(string name) : this(name, 0, 0, 0, 0) {

        }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories) {
            Name = name;
            ProteinsPerGram = proteins / 100.0;
            FatsPerGram = fats / 100.0;
            CarbohydratesPerGram = carbohydrates / 100.0;
            CaloriesPerGram = calories / 100.0;
        }

        public override string ToString() {
            return $"{Name}";
        }
    }
}
