using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {
    public class DatabaseDataSaver : IDataSaver {
        public T Load<T>(string fileName) where T : class {
            using (FitnessContext db = new FitnessContext()) {
                return db.Set<T>().FirstOrDefault();
            }
        }

        public void Save(string fileName, object obj) {
            using (FitnessContext db = new FitnessContext()) {
                Type type = obj.GetType();
                if (type == typeof(User)) {
                    db.Users.Add(obj as User);
                }
                else if (type == typeof(Gender)) {
                    db.Genders.Add(obj as Gender);
                }
                else if (type == typeof(Food)) {
                    db.Food.Add(obj as Food);
                }
                else if (type == typeof(Eating)) {
                    db.Eatings.Add(obj as Eating);
                }
                else if (type == typeof(Activity)) {
                    db.Activities.Add(obj as Activity);
                }
                else if (type == typeof(Exercise)) {
                    db.Exercises.Add(obj as Exercise);
                }
                db.SaveChanges();
            }
        }
    }
}
