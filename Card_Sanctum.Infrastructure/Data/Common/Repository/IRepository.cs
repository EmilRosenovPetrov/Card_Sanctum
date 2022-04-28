namespace Card_Sanctum.Infrastructure.Data.Common.Repository
{
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        IQueryable<T> All<T>() where T : class;

        public Task<T> GetByIdAsync<T>(object id) where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        public IQueryable<T> AllReadonly<T>() where T : class;

        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class;

        public Task AddAsync<T>(T entity) where T : class;
    }
}
