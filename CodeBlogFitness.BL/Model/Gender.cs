using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model {

    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender {
        /// <summary>
        /// Gender name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Gender name</param>
        public Gender(string name) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException("Gender anme cannot be null or empty");
            }
            Name = name;
        }

        public override string ToString() {
            return Name;
        }

    }
}
