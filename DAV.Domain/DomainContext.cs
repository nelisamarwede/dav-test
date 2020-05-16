
using EasyTraders.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace EasyTraders.Domain
{
    public sealed class DomainContext
    {
        #region Locals

        private readonly IRepositoryFactory _repositoryFactory;

        private readonly IDomainContextFactory _domainContextFactory;

        private readonly IDictionary<string, object> _internalReposCache = new Dictionary<string, object>();

        #endregion


        #region Constructors

        public DomainContext(
            IDomainQueryProvider queryProvider,
            IRepositoryFactory repositoryFactory,
            IDomainContextFactory domainContextFactory)
        {

            Id = Guid.NewGuid();

            QueryProvider = queryProvider;
            _repositoryFactory = repositoryFactory;
            _domainContextFactory = domainContextFactory;
        }


        #endregion

        #region Public Entry Points

        /// <summary>
        /// Provides access to the underlying domain query provider.
        /// </summary>
        public IDomainQueryProvider QueryProvider { get; private set; }
                

        #endregion

        public Guid Id { get; private set; }

        #region Methods

        internal IRepository<T> CreateInternalRepository<T>() where T : class, IEntity, new()
        {
            var key = $"repo_{typeof(T).FullName}";

            var hasKey = _internalReposCache.ContainsKey(key);

            if (hasKey)
            {
                if (_internalReposCache[key] is IRepository<T> repo)
                {
                    return repo;
                }
            }

            lock (_internalReposCache)
            {
                var hasKey2 = _internalReposCache.ContainsKey(key);

                if (!hasKey2)
                {
                    var repo = _repositoryFactory.CreateRepository<T>();

                    _internalReposCache.Add(key, repo);
                }

                return _internalReposCache[key] as IRepository<T>;
            }
        }

        public IRepository<T> Repository<T>() where T : class, IEntity, new()
        {
            return CreateInternalRepository<T>();
        }

        public DomainContext CreateScopedContext()
        {
            return _domainContextFactory.CreateScoped();
        }

        #endregion

    }

    public sealed class DomainContextFactory : IDomainContextFactory
    {
        private readonly IServiceProvider _services;

        public DomainContextFactory(IServiceProvider services)
        {
            _services = services;
        }

        public DomainContext CreateScoped()
        {
            return _services.GetService(typeof(DomainContext)) as DomainContext;
        }
    }

    public interface IDomainContextFactory
    {
        DomainContext CreateScoped();
    }
}
