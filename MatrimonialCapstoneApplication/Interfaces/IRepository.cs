namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IRepository<k,T> where T : class
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Get(k key);
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(k key);
    }
}
