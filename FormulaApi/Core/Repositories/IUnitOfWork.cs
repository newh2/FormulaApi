namespace FormulaApi.Core.Repositories
{
    public interface IUnitOfWork
    {
        IDriverRepository Driver { get; }

        Task CompleteAsync();
    }
}
