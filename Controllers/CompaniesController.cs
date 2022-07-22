using DAPPERNET6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAPPERNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _compRepo;

        public CompaniesController(ICompanyRepository compRepo)
        {
            _compRepo = compRepo;
        }

        [HttpGet("browse")]
        public async Task<IActionResult> getCompanies()
        {
            try
            {
                var companies = await _compRepo.getCompanies();

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("detail")]
        public async Task<IActionResult> getCompany(int id, string addr)
        {
            try
            {
                var company = await _compRepo.GetCompany(id, addr);

                return Ok(company);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
