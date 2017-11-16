﻿using System;
using FluentNHibernate.Infrastructure;
using Machine.Specifications;
using NUnit.Framework;

namespace FluentNHibernate.Testing.Infrastructure
{
    [TestFixture]
    public class ContainerTester
    {
        private Container container;

        [SetUp]
        public void CreateContainer()
        {
            container = new Container();
        }

        [Test]
        public void ShouldResolveRegisteredType()
        {
            container.Register<IExample>(c => new Example());

            container.Resolve<IExample>()
                .ShouldNotBeNull()
                .ShouldBeOfExactType<Example>();
        }

        [Test]
        public void ShouldThrowExceptionWhenResolvingUnregisteredType()
        {
            var ex = Catch.Exception(() => container.Resolve<IExample>());

            ex
                .ShouldNotBeNull()
                .ShouldBeOfExactType<ResolveException>();

            ex.Message
                .ShouldEqual("Unable to resolve dependency: '" + typeof(IExample).FullName + "'");
        }

        private interface IExample
        {}

        private class Example : IExample
        {}
    }
}
