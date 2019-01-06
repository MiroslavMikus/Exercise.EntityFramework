using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public class RepositoryValidationException : Exception
        {
            public IEnumerable<ValidationViolation> Errors { get; }

            public RepositoryValidationException(IEnumerable<ValidationViolation> errors)
            {
                Errors = errors;
            }

            public RepositoryValidationException(string message, IEnumerable<ValidationViolation> errors) 
                : base(message)
            {
                Errors = errors;
            }

            public RepositoryValidationException(string message, Exception innerException, IEnumerable<ValidationViolation> errors) 
                : base(message, innerException)
            {
                Errors = errors;
            }

            protected RepositoryValidationException(SerializationInfo info, StreamingContext context, IEnumerable<ValidationViolation> errors) 
                : base(info, context)
            {
                Errors = errors;
            }
        }
}
