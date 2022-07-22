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
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT * FROM Company";
                var Companies = await connection.QueryAsync<Company>(query);

                return Companies.ToList();
            }
        }
    }
}
