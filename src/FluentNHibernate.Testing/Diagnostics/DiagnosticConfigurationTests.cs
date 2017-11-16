using FakeItEasy;
using FluentNHibernate.Diagnostics;
using NUnit.Framework;

namespace FluentNHibernate.Testing.Diagnostics
{
    [TestFixture]
    public class DiagnosticConfigurationTests
    {
        [Test]
        public void enabling_should_set_logger_to_default_impl()
        {
            var config = new DiagnosticsConfiguration(null)
                .Enable();

            config.Logger.ShouldBeOfType<DefaultDiagnosticLogger>();
        }

        [Test]
        public void disabling_should_set_logger_to_null_impl()
        {
            var config = new DiagnosticsConfiguration(null)
                .Disable();

            config.Logger.ShouldBeOfType<NullDiagnosticsLogger>();
        }

        [Test]
        public void adding_listener_should_add_listener_to_underlying_dispatcher()
        {
            var dispatcher = A.Fake<IDiagnosticMessageDispatcher>();
            var listener = A.Fake<IDiagnosticListener>();

            new DiagnosticsConfiguration(dispatcher)
                .RegisterListener(listener);

            A.CallTo(() => dispatcher.RegisterListener(listener))
                .MustHaveHappened();
        }

        [Test]
        public void output_to_console_should_register_console_listener()
        {
            var dispatcher = A.Fake<IDiagnosticMessageDispatcher>();

            new DiagnosticsConfiguration(dispatcher)
                .OutputToConsole();

            A.CallTo(() => dispatcher.RegisterListener(A<ConsoleOutputListener>._))
                .MustHaveHappened();
        }

        [Test]
        public void output_to_file_should_register_console_listener()
        {
            var dispatcher = A.Fake<IDiagnosticMessageDispatcher>();

            new DiagnosticsConfiguration(dispatcher)
                .OutputToFile("path");

            A.CallTo(() => dispatcher.RegisterListener(A<FileOutputListener>._))
                .MustHaveHappened();
        }
    }
}
