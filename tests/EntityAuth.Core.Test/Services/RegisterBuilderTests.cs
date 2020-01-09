using EntityAuth.Core.Services;
using EntityAuth.Core.Uttils;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EntityAuth.Core.Test.Services
{
    public class RegisterBulderTest 
    {
        [Fact]
        public void RegisterLibrary_WithFluentBuilder()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddEntityFilter()
                .SetIdentifierType<long>()
                .SetAuthFilterScope(ServiceLifetime.Transient)
                .SetAuthorizationScope(ServiceLifetime.Transient)
                .SetAuthorizationImplementationType<AuthorizationService<long>>()
                .Add();

            Assert.Contains(services, x => 
                        x.ServiceType == typeof(IAuthFilterService<long>) &&
                        x.ImplementationType == typeof(AuthLongFilterService) &&
                        x.Lifetime == ServiceLifetime.Transient);

            Assert.Contains(services, x =>
                        x.ServiceType == typeof(IAuthorizationService<long>) &&
                        x.ImplementationType == typeof(AuthorizationService<long>) &&
                        x.Lifetime == ServiceLifetime.Transient);

            Assert.Contains(services, x =>
                        x.ServiceType == typeof(IEntityAuthConfiguration) &&
                        x.ImplementationInstance.GetType() == typeof(EntityAuthConfiguration) &&
                        x.Lifetime == ServiceLifetime.Singleton);
        }

        [Fact]
        public void RegisterLibrary_DifferentIdentifierTypeInAuthorizationService_ThrowsException()
        {
            IServiceCollection services = new ServiceCollection();

            Assert.Throws<EntityAuthBuilderWrongIdentifierException>(() =>
                services.AddEntityFilter()
                    .SetIdentifierType<int>()
                    .SetAuthFilterScope(ServiceLifetime.Transient)
                    .SetAuthorizationScope(ServiceLifetime.Transient)
                    .SetAuthorizationImplementationType<AuthorizationService<long>>()
                    .Add()
                    );
        }
    }
}
