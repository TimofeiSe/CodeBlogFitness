using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {
    public class ExerciseController : ControllerBase {

        private readonly User user;
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user) {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime start, DateTime finish) {
            Activity act = Activities.SingleOrDefault(x => x.Name == activity.Name);
            if (act == null) {
                Activities.Add(activity);
            }
            Exercise exercise = new Exercise(start, finish, act ?? activity, user);
            Exercises.Add(exercise);
            Save();
        }
        
        private List<Activity> GetAllActivities() {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises() {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save() {
            base.Save(ACTIVITIES_FILE_NAME, Activities);
            base.Save(EXERCISES_FILE_NAME, Exercises);
        }
    }
}
