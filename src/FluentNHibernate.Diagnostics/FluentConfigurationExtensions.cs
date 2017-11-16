using System;
using FluentNHibernate.Cfg;

namespace FluentNHibernate.Diagnostics
{
    public static class FluentConfigurationExtensions
    {
        public static FluentConfiguration Diagnostics(this FluentConfiguration configuration, Action<DiagnosticsConfiguration> diagnosticsSetup)
        {
            var diagnosticsCfg = new DiagnosticsConfiguration();
            diagnosticsSetup(diagnosticsCfg);
            configuration.Logger = diagnosticsCfg.Logger;
            return configuration;
        }
    }
}
