using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Models;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var companies = companyDbContext.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees).ToList();
            return companies.Select(company => new CompanyDto(company)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            var entityEntry = companyDbContext.Companies.Add(new Company(companyDto));
            await companyDbContext.SaveChangesAsync();
            return entityEntry.Entity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var company = companyDbContext.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees)
                .FirstOrDefault(company => company.Id.Equals(id));

            if (company != null)
            {
                companyDbContext.Companies.Remove(company);
                await companyDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAllCompanies()
        {
            var allCompanies = companyDbContext.Companies.Include(company => company.Profile)
                .Include(company => company.Employees);
            companyDbContext.Companies.RemoveRange(allCompanies);
            await companyDbContext.SaveChangesAsync();
        }
    }
}