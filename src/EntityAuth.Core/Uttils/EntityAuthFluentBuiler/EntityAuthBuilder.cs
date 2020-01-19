using EntityAuth.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EntityAuth.Core.Uttils
{
    /// <summary>
    /// Fluent interface builder for injecting entiyAuth
    /// </summary>
    public class EntityAuthBuilder : IIdentifierSetter,
        IFilterImplementation, IAuthorizationImplementation,
        IAuthorizationScope, IAuthFilterScope, IInject
    {
        private IServiceCollection _services;
        private ServiceLifetime _authFilterTypeScope;

        private Type _identifierType;
        private Type _authFilterType;
        private Type _authorizationType;
        private Type _authFilterImplementation;
        private Type _authorizationImplementation;
        private ServiceLifetime _authorizationScope;

        public EntityAuthBuilder(IServiceCollection services)
        {
            _services = services;
        }
        public IAuthFilterScope SetIdentifierType<TIdentifier>()
        {
            _identifierType = typeof(TIdentifier);

            _authFilterType = typeof(IAuthFilterService<TIdentifier>);
            _authorizationType = typeof(IAuthorizationService);

            _authFilterImplementation = typeof(AuthFilterService<TIdentifier>);

            return this;
        }

        public IFilterImplementation SetAuthFilterScope(ServiceLifetime scope)
        {
            _authFilterTypeScope = scope;
            return this;
        }

        public IAuthorizationImplementation SetAuthorizationScope(ServiceLifetime scope)
        {
            _authorizationScope = scope;
            return this;
        }

        public IAuthorizationScope SetAuthFilterImplementationType<TImplementation>()
        {
            return SetAuthFilterImplementationType(typeof(TImplementation));
        }

        public IAuthorizationScope SetAuthFilterImplementationType(Type implementationType)
        {
            if (!_authFilterType.IsAssignableFrom(implementationType))
                throw new EntityAuthBuilderWrongIdentifierException($"AuthFilter implementation must implements {_authFilterType}");

            _authFilterImplementation = implementationType;
            return this;
        }

        public IInject SetAuthorizationImplementationType<TImplementation>()
        {
            return SetAuthorizationImplementationType(typeof(TImplementation));
        }

        public IInject SetAuthorizationImplementationType(Type implementationType)
        {
            if (!_authorizationType.IsAssignableFrom(implementationType))
                throw new EntityAuthBuilderWrongIdentifierException($"Authorization implementation must implements {_authorizationType}");


            _authorizationImplementation = implementationType;
            return this;
        }

        public void Add()
        {
            // Inejcting AuthFiler Service
            _services.Add(new ServiceDescriptor(
                serviceType: _authFilterType,
                implementationType: _authFilterImplementation,
                lifetime: _authFilterTypeScope
                ));

            // Injecting Authorization Service
            _services.Add(new ServiceDescriptor(
                serviceType: _authorizationType,
                implementationType: _authorizationImplementation,
                lifetime: _authorizationScope
                ));

            // Injecting EntityAuthConfiguration 
            _services.AddSingleton<IEntityAuthConfiguration>(
                new EntityAuthConfiguration() { IdentifierType = _identifierType });

            _services.AddTransient<IRoleRepository, RoleRepository>();
            _services.AddTransient<IEntityFilter, EntityFilter>();

            //_services.Add(new ServiceDescriptor(
            //    serviceType: typeof(DbContext),
            //    implementationType: dbContextType,
            //    lifetime: ServiceLifetime.Scoped
                
            //    ));

            _services.AddSingleton<IMemorizeService,MemorizeService>();
        }
    }
}
