using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Servicios.SerializadorXML
{
    public class FileStreamManager
    {

        private static FileStreamManager _instance;
        private static readonly object _lock = new object();

        public static FileStreamManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileStreamManager();
                    }
                }

                return _instance;
            }
        }

        public FileStream CreateFile(string ext)
        {
            string file;
            file = string.Format("{0}.{1}", Guid.NewGuid().ToString(), ext);
            if (!Directory.Exists("Presupuestos"))
                Directory.CreateDirectory("Presupuestos");
            return new FileStream(@"Presupuestos\" + file, FileMode.Create);
        }

    }
}
