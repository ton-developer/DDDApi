namespace ProjectBC.Domain
{
    public interface IUnitOfWork
    {
        System.Threading.Tasks.Task CommitAsync();
    }
}