using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model {

    [Serializable]
    public class Eating {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Eating(User user) {
            User = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));
            Moment = DateTime.Now;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight) {
            Food key = Foods.Keys.FirstOrDefault(x => x.Name == food.Name);
            if (key == null) {
                Foods.Add(food, weight);
            }
            else {
                Foods[key] += weight;
            }
        }
    }
}
