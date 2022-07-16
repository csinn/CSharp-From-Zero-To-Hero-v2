using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLessonHomework
{
    internal class DuplicateUserCredentialsException : Exception
    {
        public DuplicateUserCredentialsException(string reason) : base(reason)
        {

        }
    }
}
