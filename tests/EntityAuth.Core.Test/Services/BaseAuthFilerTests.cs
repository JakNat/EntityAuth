using EntityAuth.Core.Services;
using EntityAuth.Shared;
using EntityAuth.Shared.Models;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace EntityAuth.Core.Test.Services
{
    public class BaseAuthFilerTests : IClassFixture<BaseAuthFilterTestsFixture<int>>
    {
        private readonly DbContext _db;

        public BaseAuthFilerTests(BaseAuthFilterTestsFixture<int> fixture)
        {
            _db = fixture.Context;

        }

        [Fact]
        public void ReturnsResource1IdsByCurrentRole()
        {
            // mocking RecursiveRepository
            // recursiveRepo.Get(...) returns 5 roles
            var recursiveRepo = A.Fake<IRoleRepository>();
            A.CallTo(() => recursiveRepo.Get(A<Expression<Func<Role, bool>>>.Ignored))
                .Returns(new List<Role>() 
                { MakeRole(1), MakeRole(2), MakeRole(3), MakeRole(4), MakeRole(5)});

            // mocking IAuthorizationService
            // authorizationService.GetCurrentRole() returns "Role1"
            var authorizationService = A.Fake<IAuthorizationService<int>>();
            A.CallTo(() => authorizationService.GetCurrentRole()).Returns("Role1");

            // mocking resource type
            // type.Name() returns "Resource1"
            var type = A.Fake<Type>();
            A.CallTo(() => type.Name).Returns(TestResources.Resource1);

            BaseAuthFilterService<int> service = new AuthIntFilterService(authorizationService, _db, recursiveRepo);

            var results = service.GetIds(type, AccessType.GET);

            Assert.Equal(5, results.Count());
        }

        [Fact]
        public void ReturnsResource2IdsByCurrentRole()
        {
            // mocking RecursiveRepository
            // recursiveRepo.Get(...) returns 5 roles
            var recursiveRepo = A.Fake<IRoleRepository>();
            A.CallTo(() => recursiveRepo.Get(A<Expression<Func<Role, bool>>>.Ignored))
                .Returns(new List<Role>()
                { MakeRole(11), MakeRole(2), MakeRole(3), MakeRole(4), MakeRole(5)});

            // mocking IAuthorizationService
            // authorizationService.GetCurrentRole() returns "Role1"
            var authorizationService = A.Fake<IAuthorizationService<int>>();
            A.CallTo(() => authorizationService.GetCurrentRole()).Returns("Role1");

            // mocking resource type
            // type.Name() returns "Resource2"
            var type = A.Fake<Type>();
            A.CallTo(() => type.Name).Returns(TestResources.Resource2);

            BaseAuthFilterService<int> service = new AuthIntFilterService(authorizationService, _db, recursiveRepo);

            var results = service.GetIds(type, AccessType.GET);

            Assert.Equal(1, results.Count());
        }

        private Role MakeRole(int id)
        {
            return new Role() { Id = id };
        }
    }
}