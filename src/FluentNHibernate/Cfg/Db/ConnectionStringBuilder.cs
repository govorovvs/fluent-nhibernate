namespace FluentNHibernate.Cfg.Db
{
    public class ConnectionStringBuilder
    {
        private string connectionString;

#if NET461
        public ConnectionStringBuilder FromAppSetting(string appSettingKey)
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings[appSettingKey];
            IsDirty = true;
            return this;
        }

        public ConnectionStringBuilder FromConnectionStringWithKey(string connectionStringKey)
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
            IsDirty = true;
            return this;
        }
#else
        public ConnectionStringBuilder FromAppSetting(Microsoft.Extensions.Configuration.IConfiguration configuration, string appSettingKey)
        {
            connectionString = configuration.GetSection(appSettingKey)[appSettingKey];
            IsDirty = true;
            return this;
        }

        public ConnectionStringBuilder FromConnectionStringWithKey(Microsoft.Extensions.Configuration.IConfiguration configuration, string connectionStringKey)
        {
            connectionString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(configuration, connectionStringKey);
            IsDirty = true;
            return this;
        }
#endif

        public ConnectionStringBuilder Is(string rawConnectionString)
        {
            connectionString = rawConnectionString;
            IsDirty = true;
            return this;
        }

        protected internal bool IsDirty { get; set; }

        protected internal virtual string Create()
        {
            return connectionString;
        }
    }
}