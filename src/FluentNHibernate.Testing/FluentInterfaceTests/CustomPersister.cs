using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cache.Entry;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Metadata;
using NHibernate.Persister.Entity;
using NHibernate.Tuple.Entity;
using NHibernate.Type;

namespace FluentNHibernate.Testing.FluentInterfaceTests
{
    internal class SecondCustomPersister : CustomPersister
    { }

    internal class CustomPersister : IEntityPersister
    {
        private bool _isVersioned;

        public Task<int[]> FindDirtyAsync(object[] currentState, object[] previousState, object entity, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(FindDirty(currentState, previousState, entity, session));
        }

        public Task<int[]> FindModifiedAsync(object[] old, object[] current, object entity, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(FindModified(old, current, entity, session));
        }

        public Task<object[]> GetNaturalIdentifierSnapshotAsync(object id, ISessionImplementor session, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetNaturalIdentifierSnapshot(id, session));
        }

        public Task<object> LoadAsync(object id, object optionalObject, LockMode lockMode, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(Load(id, optionalObject, lockMode, session));
        }

        public Task LockAsync(object id, object version, object obj, LockMode lockMode, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task InsertAsync(object id, object[] fields, object obj, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<object> InsertAsync(object[] fields, object obj, ISessionImplementor session, CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(object id, object version, object obj, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task UpdateAsync(object id, object[] fields, int[] dirtyFields, bool hasDirtyCollection, object[] oldFields,
            object oldVersion, object obj, object rowId, ISessionImplementor session, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<object[]> GetDatabaseSnapshotAsync(object id, ISessionImplementor session, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetDatabaseSnapshot(id, session));
        }

        public Task<object> GetCurrentVersionAsync(object id, ISessionImplementor session, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetCurrentVersion(id, session));
        }

        public Task<object> ForceVersionIncrementAsync(object id, object currentVersion, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(ForceVersionIncrement(id, currentVersion, session));
        }

        public Task<bool?> IsTransientAsync(object obj, ISessionImplementor session, CancellationToken cancellationToken)
        {
            return Task.FromResult(IsTransient(obj, session));
        }

        public Task ProcessInsertGeneratedPropertiesAsync(object id, object entity, object[] state, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task ProcessUpdateGeneratedPropertiesAsync(object id, object entity, object[] state, ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void PostInstantiate()
        {
        }

        public bool IsSubclassEntityName(string entityName)
        {
            return true;
        }

        public IType GetPropertyType(string propertyName)
        {
            return null;
        }

        public int[] FindDirty(object[] currentState, object[] previousState, object entity, ISessionImplementor session)
        {
            return new int[0];
        }

        public int[] FindModified(object[] old, object[] current, object entity, ISessionImplementor session)
        {
            return new int[0];
        }

        public object[] GetNaturalIdentifierSnapshot(object id, ISessionImplementor session)
        {
            return new object[0];
        }

        public object Load(object id, object optionalObject, LockMode lockMode, ISessionImplementor session)
        {
            return null;
        }

        public void Lock(object id, object version, object obj, LockMode lockMode, ISessionImplementor session)
        {
        }

        public void Insert(object id, object[] fields, object obj, ISessionImplementor session)
        {
        }

        public object Insert(object[] fields, object obj, ISessionImplementor session)
        {
            return null;
        }

        public void Delete(object id, object version, object obj, ISessionImplementor session)
        {

        }

        public void Update(object id, object[] fields, int[] dirtyFields, bool hasDirtyCollection, object[] oldFields,
            object oldVersion, object obj, object rowId, ISessionImplementor session)
        {

        }

        public object[] GetDatabaseSnapshot(object id, ISessionImplementor session)
        {
            return new object[0];
        }

        public object GetCurrentVersion(object id, ISessionImplementor session)
        {
            return null;
        }

        public object ForceVersionIncrement(object id, object currentVersion, ISessionImplementor session)
        {
            return null;
        }

        public void AfterInitialize(object entity, bool lazyPropertiesAreUnfetched, ISessionImplementor session)
        {
        }

        public void AfterReassociate(object entity, ISessionImplementor session)
        {
        }

        public object CreateProxy(object id, ISessionImplementor session)
        {
            return null;
        }

        public bool? IsTransient(object obj, ISessionImplementor session)
        {
            return null;
        }

        public object[] GetPropertyValuesToInsert(object obj, IDictionary mergeMap, ISessionImplementor session)
        {
            return new object[0];
        }

        public void ProcessInsertGeneratedProperties(object id, object entity, object[] state, ISessionImplementor session)
        {

        }

        public void ProcessUpdateGeneratedProperties(object id, object entity, object[] state, ISessionImplementor session)
        {
        }

        public void SetPropertyValues(object obj, object[] values)
        {
        }

        public void SetPropertyValue(object obj, int i, object value)
        {
        }

        public object[] GetPropertyValues(object obj)
        {
            return new object[0];
        }

        public object GetPropertyValue(object obj, int i)
        {
            return null;
        }

        public object GetPropertyValue(object obj, string name)
        {
            return null;
        }

        public object GetIdentifier(object obj)
        {
            return null;
        }

        public void SetIdentifier(object obj, object id)
        {
        }

        public object GetVersion(object obj)
        {
            return null;
        }

        public object Instantiate(object id)
        {
            return null;
        }

        public bool IsInstance(object entity)
        {
            return true;
        }

        public bool HasUninitializedLazyProperties(object obj)
        {
            return true;
        }

        public void ResetIdentifier(object entity, object currentId, object currentVersion)
        {
        }

        public IEntityPersister GetSubclassEntityPersister(object instance, ISessionFactoryImplementor factory)
        {
            return this;
        }

        public bool? IsUnsavedVersion(object version)
        {
            return true;
        }

        public ISessionFactoryImplementor Factory { get; }
        public string RootEntityName { get; }
        public string EntityName { get; }
        public EntityMetamodel EntityMetamodel { get; }
        public string[] PropertySpaces { get; }
        public string[] QuerySpaces { get; }
        public bool IsMutable { get; }
        public bool IsInherited { get; }
        public bool IsIdentifierAssignedByInsert { get; }

        bool IEntityPersister.IsVersioned
        {
            get { return _isVersioned; }
        }

        public IVersionType VersionType { get; }
        public int VersionProperty { get; }
        public int[] NaturalIdentifierProperties { get; }
        public IIdentifierGenerator IdentifierGenerator { get; }
        public IType[] PropertyTypes { get; }
        public string[] PropertyNames { get; }
        public bool[] PropertyInsertability { get; }
        public ValueInclusion[] PropertyInsertGenerationInclusions { get; }
        public ValueInclusion[] PropertyUpdateGenerationInclusions { get; }
        public bool[] PropertyCheckability { get; }
        public bool[] PropertyNullability { get; }
        public bool[] PropertyVersionability { get; }
        public bool[] PropertyLaziness { get; }
        public CascadeStyle[] PropertyCascadeStyles { get; }
        public IType IdentifierType { get; }
        public string IdentifierPropertyName { get; }
        public bool IsCacheInvalidationRequired { get; }
        public bool IsLazyPropertiesCacheable { get; }
        public ICacheConcurrencyStrategy Cache { get; }
        public ICacheEntryStructure CacheEntryStructure { get; }
        public IClassMetadata ClassMetadata { get; }
        public bool IsBatchLoadable { get; }
        public bool IsSelectBeforeUpdateRequired { get; }
        public bool IsVersionPropertyGenerated { get; }
        public bool HasProxy { get; }
        public bool HasCollections { get; }
        public bool HasMutableProperties { get; }
        public bool HasSubselectLoadableCollections { get; }
        public bool HasCascades { get; }
        public bool HasIdentifierProperty { get; }
        public bool CanExtractIdOutOfEntity { get; }
        public bool HasNaturalIdentifier { get; }
        public bool HasLazyProperties { get; }
        public bool[] PropertyUpdateability { get; }
        public bool HasCache { get; }
        public bool IsInstrumented { get; }
        public bool HasInsertGeneratedProperties { get; }
        public bool HasUpdateGeneratedProperties { get; }
        public Type MappedClass { get; }
        public bool ImplementsLifecycle { get; }
        public bool ImplementsValidatable { get; }
        public Type ConcreteProxyClass { get; }
        public EntityMode EntityMode { get; }
        public IEntityTuplizer EntityTuplizer { get; }

        bool IOptimisticCacheSource.IsVersioned
        {
            get { return _isVersioned; }
        }

        public IComparer VersionComparator { get; }
    }
}