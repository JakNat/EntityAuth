using EntityAuth.Core.Services;
using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EntityAuth.Core.Test.Services
{
    /// <summary>
    /// Testing hierarchical repository for role management 
    /// </summary>
    public class HierarchyRepositoryTests : IClassFixture<HierarchyRepositoryTestFixture<int>>
    {
        private readonly DbContext _db;
        private readonly IRoleRepository _recursiveRepo;
      
        public HierarchyRepositoryTests(HierarchyRepositoryTestFixture<int> fixture)
        {
            _db = fixture.Context;

            fixture.ClearRoles();
            fixture.SeedRoles();
            // to-do 
            _recursiveRepo = new RoleRepository(_db ,new MemorizeService());
        }


        [Theory]
        [InlineData("Role1", 7)]
        [InlineData("Role12", 5)]
        [InlineData("Role123", 2)]
        [InlineData("Role2", 9)]
        [InlineData("Role22", 7)]
        [InlineData("Role223", 2)]
        public void Memorization_GetRoleByName_Should_ReturnRoleAndItsOffspring(string roleName, int resultCount)
        {
            var result = _recursiveRepo.GetOffspring(x => x.Name == roleName);

            Assert.Equal(resultCount, result.Count());
        }

        [Fact]
        public void Add_ChildToRole1()
        {
            var newRole = new Role() { Name = "NewRole" };

            _recursiveRepo.Add("Role1", newRole);
            var result = _recursiveRepo.GetOffspring(x => x.Name == "Role1");

            Assert.Equal(8, result.Count());
        }

        [Fact]
        public void Add_ChildWithChildrenToRole1()
        {
            var newRole = new Role() { Name = "NewRole1" };
            newRole.Children = new List<Role>()
            {
                new Role(){ Name = "NewRole2"},
                new Role(){ Name = "NewRole3"}
            };

            _recursiveRepo.Add("Role1", newRole);
            var result = _recursiveRepo.GetOffspring(x => x.Name == "Role1");

            Assert.Equal(10, result.Count());

            var result2 = _recursiveRepo.GetOffspring(x => x.Name == "NewRole1");

            Assert.Equal(2, result2.Count());
        }

        [Theory]
        [InlineData("Role1", "Role11", 6, 17)]
        [InlineData("Role1", "Role123", 4, 15)]
        [InlineData("Role12", "Role1231", 3, 16)]
        [InlineData("Role2", "Role22111", 8, 17)]
        public void Remove_RoleByName_Should_RemoveRoleAndItsOffspring(string roleName, string roleNameToDelete,  int potomsNumber, int totalNumber)
        {
            _recursiveRepo.Delete(roleNameToDelete);

            var result = _recursiveRepo.GetOffspring(x => x.Name == roleName);
            var allRoles = _db.Set<Role>().ToList();

            Assert.Equal(potomsNumber, result.Count());
            Assert.Equal(totalNumber, allRoles.Count());
        }

    }
}
