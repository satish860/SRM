using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRM.Domain.Entity
{
    public static class StudentNumber
    {
        private static int number = Int32.Parse(ConfigurationManager.AppSettings["StudentNumber"]);

        public static int Get()
        {
            return Interlocked.Increment(ref number);
        }
    }
}
