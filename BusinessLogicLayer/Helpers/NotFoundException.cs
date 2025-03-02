using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class NotFoundException : Exception
    {
        private readonly string message;
        private readonly string error;

        public NotFoundException(string message, string error) : base(message)
        {
            this.message = message;
            this.error = error;
        }
    }
}
