using VeliErdemCoskun_Hafta3.Context;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Automapping;
using VeliErdemCoskun_Hafta3.Models;


namespace VeliErdemCoskun_Hafta3.StartUpExtension
{
    public static class NHibernateExtensions
    {

        public static IServiceCollection AddNHibernatePosgreSql(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();

            // config for entity mapping by auto implement
            mapper.AddMappings(typeof(NHibernateExtensions).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<PostgreSQLDialect>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Validate;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;

            });
            configuration.AddMapping(domainMapping);

            // for creating tables if not exists and use the existing data if exists
            new SchemaExport(configuration).Execute(true, false, false);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());


            // inject
            services.AddScoped<IMapperSession, MapperSession>();

            return services;
        }



    }
}