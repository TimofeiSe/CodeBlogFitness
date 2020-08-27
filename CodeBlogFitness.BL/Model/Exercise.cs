using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model {
    [Serializable]
    public class Exercise {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Activity Activity { get; set; }
        public User User { get; set; }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user) {
            // TODO: checking
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
