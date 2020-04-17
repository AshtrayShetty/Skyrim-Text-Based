using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.EventArgs
{
    public class GameMessageEventArgs : System.EventArgs
    {
        public string message { get; set; }
        public GameMessageEventArgs(string message) { this.message = message; }
    }
}
