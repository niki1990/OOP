using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversioAndDependency
{
    class Program
    {
        public enum logenum { FileLogger, DBLogger};
    
        static void Main(string[] args)
        {
            logenum value = logenum.FileLogger ;
            ILogger log=null;

            switch (value)
            {
                case logenum.DBLogger:
                    log = new DataBaseLogger();
                    break;
                case logenum.FileLogger:
                    log = new FileLogger();
                    break;              
             }

            ProductServices prod = new ProductServices(log);
            prod.Log("Inversion Control");
        }
    }

    class ProductServices : ILogger
    {
        private readonly  ILogger loggerObject;

        public ProductServices(ILogger logger)
        {
            this.loggerObject = logger;
        }
        public void Log(string message)
        {
            loggerObject.Log(message);
        }
    }

    class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("This is File Logger :"+ message);
        }
    }
    class DataBaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("This is Database Logger :"+ message);
        }
    }

    interface ILogger
    {
        void Log(string messae);
    }
}
