using InformeIR.ULF.Services.Context;
using InformeIR.ULF.Services.Repository.Interface;

namespace InformeIR.ULF.Services.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly InformeIRSContexto _context;

        public BaseRepository(InformeIRSContexto context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
