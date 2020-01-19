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
        private ModelBuilder _modelBuilder;
        private Type _identifierType;

        public EntityAuthTablesBuilder SetModelBuilder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
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

        public EntityAuthTablesBuilder SetResourceIdentifierType(Type identifierType)
        {
            _identifierType = identifierType;
            return this;
        }

        public void Build()
        {
            _modelBuilder.Entity<ResourceType>().HasData(_resources);
            //_modelBuilder.Entity<Role>()
            //    .HasMany<Role>()
            //    .WithOne()
            //    .HasForeignKey(x => x.ParentId);

            if (_identifierType.Equals(typeof(int)))
            {
                _modelBuilder.Entity<Permission<int>>();
            }
            else if (_identifierType.Equals(typeof(long)))
            {
                _modelBuilder.Entity<Permission<long>>();
            }
            else if (_identifierType.Equals(typeof(Guid)))
            {
                _modelBuilder.Entity<Permission<Guid>>();
            }
            else
            {
                throw new Exception("Identifier type not supported");
            }
        }
    }
}
