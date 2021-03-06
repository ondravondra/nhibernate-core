﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH2288
{
	using System.Threading.Tasks;
	using System.Threading;
	[TestFixture]
	public class FixtureAsync
	{
		private static void CheckDialect(Configuration configuration)
		{
			var dialect = Dialect.Dialect.GetDialect(configuration.Properties);
			if (!(dialect is MsSql2000Dialect))
				Assert.Ignore("Specific test for MsSQL dialects");
		}

		private static async Task AssertThatCheckOnTableExistenceIsCorrectAsync(Configuration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			var su = new SchemaExport(configuration);
			var sb = new StringBuilder(500);
			await (su.ExecuteAsync(x => sb.AppendLine(x), false, false, cancellationToken));
			string script = sb.ToString();
			Assert.That(script, Does.Contain("if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'dbo.[Aclasses_Id_FK]') AND parent_object_id = OBJECT_ID('dbo.Aclass'))"));
		}

		[Test]
		public Task TestForClassWithDefaultSchemaAsync()
		{
			try
			{
				Configuration cfg = TestConfigurationHelper.GetDefaultConfiguration();
				CheckDialect(cfg);
				cfg.SetProperty(Environment.DefaultCatalog, "nhibernate");
				cfg.SetProperty(Environment.DefaultSchema, "dbo");
				cfg.AddResource("NHibernate.Test.NHSpecificTest.NH2288.AclassWithNothing.hbm.xml", GetType().Assembly);
				return AssertThatCheckOnTableExistenceIsCorrectAsync(cfg);
			}
			catch (System.Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		[Test]
		public Task WithDefaultValuesInMappingAsync()
		{
			try
			{
				Configuration cfg = TestConfigurationHelper.GetDefaultConfiguration();
				CheckDialect(cfg);
				cfg.SetProperty(Environment.DefaultCatalog, "nhibernate");
				cfg.SetProperty(Environment.DefaultSchema, "somethingDifferent");
				cfg.AddResource("NHibernate.Test.NHSpecificTest.NH2288.AclassWithDefault.hbm.xml", GetType().Assembly);
				return AssertThatCheckOnTableExistenceIsCorrectAsync(cfg);
			}
			catch (System.Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		[Test]
		public Task WithSpecificValuesInMappingAsync()
		{
			try
			{
				Configuration cfg = TestConfigurationHelper.GetDefaultConfiguration();
				CheckDialect(cfg);
				cfg.SetProperty(Environment.DefaultCatalog, "nhibernate");
				cfg.SetProperty(Environment.DefaultSchema, "somethingDifferent");
				cfg.AddResource("NHibernate.Test.NHSpecificTest.NH2288.AclassWithSpecific.hbm.xml", GetType().Assembly);
				return AssertThatCheckOnTableExistenceIsCorrectAsync(cfg);
			}
			catch (System.Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		[Test]
		public Task WithDefaultValuesInConfigurationPriorityToMappingAsync()
		{
			try
			{
				Configuration cfg = TestConfigurationHelper.GetDefaultConfiguration();
				CheckDialect(cfg);
				cfg.SetProperty(Environment.DefaultCatalog, "nhibernate");
				cfg.SetProperty(Environment.DefaultSchema, "somethingDifferent");
				cfg.AddResource("NHibernate.Test.NHSpecificTest.NH2288.AclassWithDefault.hbm.xml", GetType().Assembly);
				return AssertThatCheckOnTableExistenceIsCorrectAsync(cfg);
			}
			catch (System.Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}
	}
}
