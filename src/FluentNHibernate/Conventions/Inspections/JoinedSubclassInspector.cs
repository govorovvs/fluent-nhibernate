using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.ClassBased;

namespace FluentNHibernate.Conventions.Inspections
{
    public class JoinedSubclassInspector : IJoinedSubclassInspector
    {
        private readonly InspectorModelMapper<IJoinedSubclassInspector, SubclassMapping> mappedProperties = new InspectorModelMapper<IJoinedSubclassInspector, SubclassMapping>();
        private readonly SubclassMapping mapping;

        public JoinedSubclassInspector(SubclassMapping mapping)
        {
            this.mapping = mapping;
            mappedProperties.Map(x => x.LazyLoad, x => x.Lazy);
        }

        public Type EntityType
        {
            get { return mapping.Type; }
        }

        public string StringIdentifierForModel
        {
            get { return mapping.Name; }
        }

        public bool IsSet(Member property)
        {
            return mapping.IsSpecified(mappedProperties.Get(property));
        }

        public bool Abstract
        {
            get { return mapping.Abstract; }
        }

        public IEnumerable<IAnyInspector> Anys
        {
            get
            {
                return mapping.Anys
                    .Select(x => new AnyInspector(x));
            }
        }

        public IKeyInspector Key
        {
            get
            {
                if (mapping.Key == null)
                    return new KeyInspector(new KeyMapping());

                return new KeyInspector(mapping.Key);
            }
        }

        public string Check
        {
            get { return mapping.Check; }
        }

        public IEnumerable<ICollectionInspector> Collections
        {
            get
            {
                return mapping.Collections
                    .Select(x => new CollectionInspector(x));
            }
        }

        public bool DynamicInsert
        {
            get { return mapping.DynamicInsert; }
        }

        public bool DynamicUpdate
        {
            get { return mapping.DynamicUpdate; }
        }

        public Type Extends
        {
            get { return mapping.Extends; }
        }

        public IEnumerable<IJoinInspector> Joins
        {
            get
            {
                return mapping.Joins
                    .Select(x => new JoinInspector(x));
            }
        }

        public bool LazyLoad
        {
            get { return mapping.Lazy; }
        }

        public string Schema
        {
            get { return mapping.Schema; }
        }

        public string Name
        {
            get { return mapping.Name; }
        }

        public IEnumerable<IOneToOneInspector> OneToOnes
        {
            get
            {
                return mapping.OneToOnes
                    .Select(x => new OneToOneInspector(x));
            }
        }

        public IEnumerable<IPropertyInspector> Properties
        {
            get
            {
                return mapping.Properties
                    .Select(x => new PropertyInspector(x));
            }
        }

        public string Proxy
        {
            get { return mapping.Proxy; }
        }

        public IEnumerable<IManyToOneInspector> References
        {
            get
            {
                return mapping.References
                    .Select(x => new ManyToOneInspector(x));
            }
        }
        public bool SelectBeforeUpdate
        {
            get { return mapping.SelectBeforeUpdate; }
        }

        public IEnumerable<IJoinedSubclassInspector> Subclasses
        {
            get
            {
                return mapping.Subclasses
                    .Select(x => new JoinedSubclassInspector(x));
            }
        }

        IEnumerable<ISubclassInspectorBase> ISubclassInspectorBase.Subclasses
        {
            get { return Subclasses; }
        }

        public string TableName
        {
            get { return mapping.TableName; }
        }

        public Type Type
        {
            get { return mapping.Type; }
        }
    }
}