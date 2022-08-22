using Microsoft.EntityFrameworkCore.Storage;


namespace App.Shared.Contracts
{
    /// <summary>
    /// Resides Transaction and Save Changes
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Creates the transaction for the Command for updates or insert of entities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Saves the changes from entities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
