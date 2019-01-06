using FluentValidation;
using FluentValidation.Results;
using System.Data.Entity;
using System.Linq;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public abstract class ValidateRepository<T> : Repository<T> where T : class
    {
        private readonly AbstractValidator<T> _validator;

        public ValidateRepository(DbContext context, AbstractValidator<T> validator)
            : base(context)
        {
            _validator = validator;
        }

        public override T Insert(T entity)
        {
            Validate(entity);

            return _dbSet.Add(entity);
        }

        public override void Update(T entity)
        {
            Validate(entity);

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        private void Validate(T entity)
        {
            var validationResult = _validator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw CastException(validationResult);
            }
        }

        private RepositoryValidationException CastException(ValidationResult validationResult)
        {
            var errors = validationResult.Errors.Select(a => new ValidationViolation(a.PropertyName, a.ErrorMessage));

            return new RepositoryValidationException(nameof(ValidateRepository<T>), errors.ToList());
        }
    }
}
