using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {

    public abstract class ControllerBase {

        //protected IDataSaver saver = new SerializeDataSaver();
        protected IDataSaver saver = new DatabaseDataSaver();

        protected void Save(string fileName, object obj) {
            saver.Save(fileName, obj);
        }

        protected T Load<T>(string fileName) where T : class{
            return saver.Load<T>(fileName);
        }
    }
}
