using EntityAuth.Shared.Models;
using System.Collections.Generic;

namespace EntityAuth.Core.Test.Services
{
    public class BaseAuthFilterTestsFixture<T> : BaseTestFixture<T>
    {
        public BaseAuthFilterTestsFixture() : base()
        {
            var permissions = new List<Permission<T>>()
            {
                new Permission<T>(){ RoleId = 1, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 2, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 3, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 4, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 5, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 6, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 7, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 8, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 9, ResourceTypeId = 1},
                new Permission<T>(){ RoleId = 10, ResourceTypeId = 1},
                                     
                new Permission<T>(){ RoleId = 11, ResourceTypeId = 2},
                new Permission<T>(){ RoleId = 12, ResourceTypeId = 2},
                new Permission<T>(){ RoleId = 13, ResourceTypeId = 3},

            };

            var resources = new List<ResourceType>()
            {
                new ResourceType(){ Id = 1, Name = TestResources.Resource1},
                new ResourceType(){ Id = 2, Name = TestResources.Resource2},
                new ResourceType(){ Id = 3, Name = TestResources.Resource3}
            };

            Context.Set<ResourceType>().AddRange(resources);
            Context.Set<Permission<T>>().AddRange(permissions);

            Context.SaveChanges();
        }
    }
}
