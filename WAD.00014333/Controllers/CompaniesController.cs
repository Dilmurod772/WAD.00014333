using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00014333.DTOs;
using WAD._00014333.Interfaces;
using WAD._00014333.Models;

namespace WAD._00014333.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();
            return Ok(_mapper.Map<IEnumerable<CompanyDto>>(companies));
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return _mapper.Map<CompanyDto>(company);
        }

        // POST: api/Companies
        [HttpPost]
        public async Task<ActionResult<CompanyDto>> PostCompany(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            company = await _companyRepository.AddCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = company.CompanyId }, _mapper.Map<CompanyDto>(company));
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyDto companyDto)
        {
            if (id != companyDto.CompanyId)
            {
                return BadRequest();
            }

            var company = _mapper.Map<Company>(companyDto);
            await _companyRepository.UpdateCompanyAsync(company);

            return NoContent();
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyRepository.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
