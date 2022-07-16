using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLessonHomework
{
    internal class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(string reason) : base(reason) 
        { 
        
        }
    }
}
