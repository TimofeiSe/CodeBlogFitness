using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller {
    public interface IDataSaver {
        void Save(string fileName, object obj);
        T Load<T>(string fileName) where T : class;

    }
    }
