using System;
using System.Runtime.Serialization;

namespace TestProject1
{
    [Serializable]
    internal class CustomMoodAnalyserException : Exception
    {
        public CustomMoodAnalyserException()
        {
        }

        public CustomMoodAnalyserException(string message) : base(message)
        {
        }

        public CustomMoodAnalyserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomMoodAnalyserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}