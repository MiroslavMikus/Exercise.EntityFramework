using System;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public class ValidationViolation
        {
            public string PropertyName { get; }
            public string ErrorMessage { get; set; }

            public ValidationViolation(string propertyName, string errorMessage)
            {
                PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
                ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
            }
        }
}
