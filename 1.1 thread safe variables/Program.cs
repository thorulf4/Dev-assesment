using System;

namespace _1._1_thread_safe_variables
{
    class Program
    {
        public static void Main(string[] args)
        {

        }

        private readonly static object instanceVariableMutexKey = new Object();

        private volatile static int instanceVariable;
        private volatile int classVariable;

        public void ConcurrentOperation()
        {
            lock (instanceVariableMutexKey)
            {
                instanceVariable += classVariable;
            }
        }
    }
}
