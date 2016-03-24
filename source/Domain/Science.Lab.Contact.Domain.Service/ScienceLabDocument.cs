using Lime.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science.Lab.Contact.Domain.Service
{
    public class ScienceLabDocument
    {
        public string Title { get; set; }
        public Document Document { get; set; }

        public bool Primary { get; set; }

    }
}
