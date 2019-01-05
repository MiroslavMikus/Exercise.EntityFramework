using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.Patterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Calls <see cref="DbContext.SaveChanges"/>
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        int SaveChanges();

        /// <summary>
        /// Calls <see cref="DbContext.SaveChangesAsync(CancellationToken)"/>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains
        /// the number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
