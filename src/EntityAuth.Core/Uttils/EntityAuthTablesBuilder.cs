using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using EntityAuth.Shared.Models;

namespace EntityAuth.Core
{
    public class EntityAuthTablesBuilder
    {
        private IEnumerable<ResourceType> _resources;
        private IEnumerable<Role> _roles;
        private ModelBuilder _modelBuilder;
        private Type _identifierType;

        public EntityAuthTablesBuilder()
        {

        }

        public EntityAuthTablesBuilder SetModelBuilder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            return this;
        }

        public EntityAuthTablesBuilder SetResouces(IEnumerable<ResourceType> resources)
        {
            _resources = resources;
            return this;
        }

        public EntityAuthTablesBuilder SetResouces(IEnumerable<Type> resourcesType)
        {
            int id = 1;
            
            _resources = resourcesType.Select(x => new ResourceType
            {
                Id = id++,
                Name = x.Name
            });

            return this;
        }

        public EntityAuthTablesBuilder SetRoles(IEnumerable<Role> roles)
        {
            _roles = roles;
            return this;
        }

        public EntityAuthTablesBuilder SetResourceIdentifierType(Type identifierType)
        {
            _identifierType = identifierType;
            return this;
        }

        public void Build<T>()
        {
            _modelBuilder.Entity<ResourceType>().HasData(_resources);
            _modelBuilder.Entity<Role>().HasData(_roles);
            _modelBuilder.Entity<Permission<T>>();
        }

    }
}
