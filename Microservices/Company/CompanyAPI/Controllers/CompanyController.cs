using System;
using System.Collections.Generic;
using System.Linq;
using CompanyAPI.Data;
using CompanyAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyContext _context;
        public CompanyController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Companies>> GetCompanies()
        {
            var company = _context.Companies.ToList();

            return Ok(company);
        }

        [HttpGet("{id}")]
        public ActionResult<Companies> GetCompanyById(int id)
        {
            return _context.Companies.Find(id);
        }

        [HttpPost]
        public ActionResult<Companies> PostCompany(Companies company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();   // the postcommand chonges get into the persistent db from the inmemory changes

            return CreatedAtAction("GetCompanyById", new Companies { Id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public ActionResult<Companies> PutCompany(int id, Companies company)
        {
            if (id != company.Id)
                return BadRequest();

            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult<Companies> DeleteCompany(int id)
        {
            var company = _context.Companies.Find(id);

            if (company == null)
                return NotFound();

            _context.Companies.Remove(company);
            _context.SaveChanges();

            return company;

        }

        [HttpGet("stock/{CompanyId}")]
        public ActionResult<long> GetStockPrice(int CompanyId)
        {
            var IPO = _context.IPOs.FirstOrDefault(i => i.CompanyId == CompanyId);
            long price = IPO.PricePerShare;
            return price;
        }

        [HttpGet("IPO/{coampanyId}")]
        public ActionResult<IPOs> GetCompaniesIPO(int CompanyId)
        {

            return _context.IPOs.FirstOrDefault(i => i.CompanyId == CompanyId);
        }

        
    }
}