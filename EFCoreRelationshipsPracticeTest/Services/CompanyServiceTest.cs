using System;
using System.Collections.Generic;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EFCoreRelationshipsPracticeTest
{
    public class CompanyServiceTest
    {
        private readonly CompanyDbContext context;

        public CompanyServiceTest()
        {
            var dbContextOptionsBuilder =
                new DbContextOptionsBuilder<CompanyDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            context = new CompanyDbContext(dbContextOptionsBuilder.Options);
        }

        [Fact]
        public async void Should_get_company_by_Id_successfully_after_save_the_company()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                }
            };
            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            var companyService = new CompanyService(context);

            var addedCompanyId = await companyService.AddCompany(companyDto);
            var gotCompanyDto = await companyService.GetById(addedCompanyId);
            Assert.Equal("IBM", gotCompanyDto.Name);
        }
    }
}