using DAPPERNET6.Models;

namespace DAPPERNET6.Services
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> getCompanies();
        public Task<Company> GetCompany(int id, string addr);
    }
}
