using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {
    public class EatingController : ControllerBase {

        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;

        public List<Food> Foods { get; }
        public Eating Eating { get; }


        public EatingController(User user) {
            this.user = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }


        //public bool Add(string foodName, double weight) {
        //    var food = Foods.SingleOrDefault(x => x.Name == foodName);
        //    if (food != null) {
        //        Eating.Add(food, weight);
        //        Save();
        //        return true;
        //    }
        //    return false;
        //}

        public void Add(Food food, double weight) {
            Food product = Foods.SingleOrDefault(x => x.Name == food.Name);
            if (product == null) {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating() {
            return base.Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods() {
            return base.Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save() {
            base.Save(FOODS_FILE_NAME, Foods);
            base.Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
