using Employee.Core.Application.Interfaces.Repositories;
using Employee.Core.Domain.Entities;
using Employee.Infrastructure.Persistance.Contexts;

namespace Employee.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository : GenericRepository<Employees>, IEmployeeRepository
    {
        private readonly AppDbContext _db;
        public EmployeeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
