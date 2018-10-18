using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoXamarin
{
    public class Gato
    {
        public string id { get; set; }
        public string url { get; set; }
        public List<object> breeds { get; set; }
        public List<object> categories { get; set; }
    }
}
