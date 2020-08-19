using System;
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class

namespace Datadog.Trace.ClrProfiler.CallTarget.DuckTyping
{
    /// <summary>
    /// DuckType property can't be read
    /// </summary>
    public class DuckTypePropertyCantBeReadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuckTypePropertyCantBeReadException"/> class.
        /// </summary>
        public DuckTypePropertyCantBeReadException()
            : base("The property can't be read, you should remove the getter from the base type class or interface.")
        {
        }
    }

    /// <summary>
    /// DuckType property can't be written
    /// </summary>
    public class DuckTypePropertyCantBeWrittenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuckTypePropertyCantBeWrittenException"/> class.
        /// </summary>
        public DuckTypePropertyCantBeWrittenException()
            : base("The property can't be written, you should remove the setter from the base type class or interface.")
        {
        }
    }

    /// <summary>
    /// DuckType field is readonly
    /// </summary>
    public class DuckTypeFieldIsReadonlyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuckTypeFieldIsReadonlyException"/> class.
        /// </summary>
        public DuckTypeFieldIsReadonlyException()
            : base("The field is marked as readonly, you should remove the setter from the base type class or interface.")
        {
        }
    }

    /// <summary>
    /// DuckType property or field not found
    /// </summary>
    public class DuckTypePropertyOrFieldNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuckTypePropertyOrFieldNotFoundException"/> class.
        /// </summary>
        public DuckTypePropertyOrFieldNotFoundException()
            : base("The property or field was not found in the instance.")
        {
        }
    }

    /// <summary>
    /// DuckType type is not an interface exception
    /// </summary>
    public class DuckTypeTypeIsNotValidException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuckTypeTypeIsNotValidException"/> class.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="argumentName">Name of the argument</param>
        public DuckTypeTypeIsNotValidException(Type type, string argumentName)
            : base($"The type '{type.FullName}' is not a valid type, argument: '{argumentName}'")
        {
        }
    }

    /// <summary>
    /// DuckType type is not public exception
    /// </summary>
    public class DuckTypeTypeIsNotPublicException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuckTypeTypeIsNotPublicException"/> class.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="argumentName">Name of the argument</param>
        public DuckTypeTypeIsNotPublicException(Type type, string argumentName)
            : base($"The type '{type.FullName}' must be public, argument: '{argumentName}'")
        {
        }
    }
}