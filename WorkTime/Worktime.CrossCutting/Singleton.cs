using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worktime.CrossCutting
{
    /// <summary>
    /// Represents a singleton instance
    /// </summary>
    /// <typeparam name="T">The type that should be instanced as singleton</typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        private static volatile T _instance;

        private static object syncRoot = new object();

        /// <summary>
        /// Gets the instance of the singleton <typeparamref name="T"/>
        /// </summary>
        public static T Instance
        {
            get
            {
                // Default implementation -> double check
                // first check
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        // second check after lock
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }

                return _instance;
            }
        }
    }


}
