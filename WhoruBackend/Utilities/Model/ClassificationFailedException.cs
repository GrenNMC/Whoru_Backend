using System;
using System.Collections.Generic;
using System.Text;

namespace WhoruBackend.Utilities.Model
{
    public class ClassificationFailedException : Exception
    {
        public ClassificationFailedException(string message)
            : base(message)
        {
        }
    }
}
