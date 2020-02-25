using System;
using System.Collections.Generic;
using System.Text;

namespace _1._3_Persistence
{
    class Data
    {
        public int someInteger;
        public string someString;
        public DateTime someDateTime;

        public Data(int someInteger, string someString, DateTime someDateTime)
        {
            this.someInteger = someInteger;
            this.someString = someString;
            this.someDateTime = someDateTime;
        }

        public Data()
        {

        }
    }
}
