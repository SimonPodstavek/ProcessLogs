using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLogs.utilities
{
    
    internal class AggregateFileIncorrectStructure : Exception
    {
        public AggregateFileIncorrectStructure() : base() { }

        public AggregateFileIncorrectStructure(string message) : base(message: message) {}


    }

    internal class XMLElementNotFound : Exception 
    {
        
        public XMLElementNotFound(string message) : base(message: message)  {}
    }


    internal class SizeInvalid : Exception
    {
        public SizeInvalid(string message) : base(message:message) { }
    }

    internal class AbsentXMLSection : Exception
    {
        public AbsentXMLSection() : base() { }
    }
}
