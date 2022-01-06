using System;
using com.ctn_originals.unity_drawif_attributes;

namespace Exceptions
{

    /// <summary>
    /// An exception that is thrown whenever a field was not found inside of an object when using Reflection.
    /// </summary>
    [Serializable]
    public class FieldNotFoundException : Exception
    {
        public FieldNotFoundException() { }

        public FieldNotFoundException(string message) : base(message) { }

        public FieldNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected FieldNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}