using System;

namespace KJBTech.Livestorm
{
    public class LivestormException : Exception
    {
        /// <summary>
        /// <see cref="Exception"/>
        /// </summary>
        public LivestormException() : base()
        {
        }

        /// <summary>
        /// <see cref="Exception"/>
        /// </summary>
        public LivestormException(string message) : base(message)
        {
        }

        /// <summary>
        /// <see cref="Exception"/>
        /// </summary>
        public LivestormException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
