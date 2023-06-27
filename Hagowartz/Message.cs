using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Message
    {
        public int Id { get; set; }

        public string MessageText { get; set; }

        public string studentUsername { get; set; }
        public string studentName { get; set; }

        public DateTime sendTime { get; set; }
    }
}
