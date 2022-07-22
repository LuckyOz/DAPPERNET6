using Dapper;
using DAPPERNET6.Context;
using DAPPERNET6.Models;

namespace DAPPERNET6.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> getCompanies()
        {
            var query = "SELECT * FROM Company";

            using (var connection = _context.CreateConnection())
            {
                var Companies = await connection.QueryAsync<Company>(query);

                return Companies.ToList();
            }
        }

        public async Task<Company> GetCompany(int id, string addr)
        {
            var query = "SELECT * FROM Company WHERE Id = @Id AND Address = @Addr";

            using (var connection = _context.CreateConnection())
            {
                var Company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id , addr });

                return Company;
            }
        }
    }
}
