﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Data;
using System.Xml;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NUnit.Framework;

namespace NHibernate.Test.TypesTest
{
	using System.Threading.Tasks;
	[TestFixture]
	public class XmlDocTypeFixtureAsync : TypeFixtureBase
	{
		protected override string TypeName
		{
			get { return "XmlDoc"; }
		}

		protected override bool AppliesTo(Dialect.Dialect dialect)
		{
			return TestDialect.SupportsSqlType(new SqlType(DbType.Xml));
		}

		protected override bool AppliesTo(ISessionFactoryImplementor factory)
		{
			// No Xml support with Odbc (and likely OleDb too).
			return factory.ConnectionProvider.Driver.IsSqlClientDriver();
		}

		[Test]
		public async Task ReadWriteAsync()
		{
			using (var s = OpenSession())
			{
				var docEntity = new XmlDocClass {Id = 1 };
				docEntity.Document = new XmlDocument();
				docEntity.Document.LoadXml("<MyNode>my Text</MyNode>");
				await (s.SaveAsync(docEntity));
				await (s.FlushAsync());
			}

			using (var s = OpenSession())
			{
				var docEntity = await (s.GetAsync<XmlDocClass>(1));
				var document = docEntity.Document;
				Assert.That(document, Is.Not.Null);
				Assert.That(document.OuterXml, Does.Contain("<MyNode>my Text</MyNode>"));
				var xmlElement = document.CreateElement("Pizza");
				xmlElement.SetAttribute("temp", "calda");
				document.FirstChild.AppendChild(xmlElement);
				await (s.SaveAsync(docEntity));
				await (s.FlushAsync());
			}
			using (var s = OpenSession())
			{
				var docEntity = await (s.GetAsync<XmlDocClass>(1));
				Assert.That(docEntity.Document.OuterXml, Does.Contain("Pizza temp=\"calda\""));
				await (s.DeleteAsync(docEntity));
				await (s.FlushAsync());
			}
		}

		[Test]
		public async Task InsertNullValueAsync()
		{
			using (ISession s = OpenSession())
			{
				var docEntity = new XmlDocClass { Id = 1 };
				docEntity.Document = null;
				await (s.SaveAsync(docEntity));
				await (s.FlushAsync());
			}

			using (ISession s = OpenSession())
			{
				var docEntity = await (s.GetAsync<XmlDocClass>(1));
				Assert.That(docEntity.Document, Is.Null);
				await (s.DeleteAsync(docEntity));
				await (s.FlushAsync());
			}
		}
	}
}
