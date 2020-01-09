using EntityAuth.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityAuth.Core.Test.Services
{
    public class HierarchyRepositoryTestFixture<T> : BaseTestFixture<T>
    {
        public HierarchyRepositoryTestFixture() : base()
        {
        }

        public void ClearRoles()
        {
            var roles = Context.Set<Role>().ToList();
            Context.Set<Role>().RemoveRange(roles);
        }

        public void SeedRoles()
        {
            var role = NewRole("Role1", 1).WithChildren(
                       NewRole("Role11", 2),
                       NewRole("Role12", 3).WithChildren(
                           NewRole("Role121", 4),
                           NewRole("Role122", 5),
                           NewRole("Role123", 6).WithChildren(
                               NewRole("Role1231", 7).WithChildren(
                                   NewRole("Role12311", 8))))
               );

            var role2 = NewRole("Role2", 21).WithChildren(
                            NewRole("Role21", 22),
                            NewRole("Role22", 23).WithChildren(
                                NewRole("Role221", 24).WithChildren(
                                    NewRole("Role2211", 27).WithChildren(
                                        NewRole("Role22111", 28))),
                                NewRole("Role222", 25),
                                NewRole("Role223", 26).WithChildren(
                                    NewRole("Role2231", 29).WithChildren(
                                        NewRole("Role22311", 30))))
               );

            Context.Set<Role>().AddRange(role, role2);
            Context.SaveChanges();
        }
        private Role NewRole(string name, int id)
        {
            return new Role() { Name = name, Id = id };
        }
    }
}
