using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model {
    [Serializable]
    public class Activity {
        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }
        public Activity(string name, double caloriesPerMinute) {
            // TODO: Checking
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString() {
            return $"{Name} ({CaloriesPerMinute} Cal/min)";
        }
    }
}
