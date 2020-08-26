using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {

    public abstract class ControllerBase {

        protected void Save(string fileName, object obj) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                formatter.Serialize(fs, obj);
            }
        }

        protected T Load<T>(string fileName) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T t)
                    return t;
                else
                    return default(T);
            }
        }
    }
}
