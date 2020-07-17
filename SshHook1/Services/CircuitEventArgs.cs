using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SshHook1.Services
{
    public class CircuitEventArgs : EventArgs
    {
        private readonly string _url;

        public string Url
        {
            get { return _url; }
        }
        public CircuitEventArgs(string URL)
        {
            _url = URL;
        }


    }
}
