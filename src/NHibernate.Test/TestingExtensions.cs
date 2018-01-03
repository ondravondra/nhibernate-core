﻿using NHibernate.Driver;

namespace NHibernate.Test
{
	public static class TestingExtensions
	{
		public static bool IsOdbcDriver(this IDriver driver)
		{
#if !NETCOREAPP2_0
			if (driver is OdbcDriver) return true;
#endif
			return false;
		}

		public static bool IsOdbcDriver(this System.Type driverClass)
		{
#if !NETCOREAPP2_0
			if (typeof(OdbcDriver).IsAssignableFrom(driverClass)) return true;
#endif
			return false;
		}

		public static bool IsOleDbDriver(this IDriver driver)
		{
#if !NETCOREAPP2_0
			if (driver is OleDbDriver) return true;
#endif
			return false;
		}

		public static bool IsOleDbDriver(this System.Type driverClass)
		{
#if !NETCOREAPP2_0
			if (typeof(OleDbDriver).IsAssignableFrom(driverClass)) return true;
#endif
			return false;
		}

		/// <summary>
		/// Matches both SQL Server 2000 and 2008 drivers
		/// </summary>
		public static bool IsSqlServerDriver(this IDriver driver)
		{
#if !NETCOREAPP2_0
#pragma warning disable 618
			if (driver is SqlClientDriver) return true;
#pragma warning restore 618
#endif
			if (driver is SqlServer2000Driver) return true;
			return false;
		}

		/// <summary>
		/// Matches both SQL Server 2000 and 2008 drivers
		/// </summary>
		public static bool IsSqlServerDriver(this System.Type driverClass)
		{
#if !NETCOREAPP2_0
#pragma warning disable 618
			if (typeof(SqlClientDriver).IsAssignableFrom(driverClass)) return true;
#pragma warning restore 618
#endif
			if (typeof(SqlServer2000Driver).IsAssignableFrom(driverClass)) return true;
			return false;
		}

		public static bool IsSqlServer2008Driver(this IDriver driver)
		{
#if !NETCOREAPP2_0
#pragma warning disable 618
			if (driver is Sql2008ClientDriver) return true;
#pragma warning restore 618
#endif
			if (driver is SqlServer2008Driver) return true;
			return false;
		}

		public static bool IsMySqlDriver(this System.Type driverClass)
		{
#if !NETCOREAPP2_0
#pragma warning disable 618
			if (typeof(MySqlDataDriver).IsAssignableFrom(driverClass)) return true;
#pragma warning restore 618
#endif
			if (typeof(MySqlDriver).IsAssignableFrom(driverClass)) return true;
			return false;
		}


		public static bool IsFirebirdDriver(this IDriver driver)
		{
#if !NETCOREAPP2_0
#pragma warning disable 618
			if (driver is FirebirdClientDriver) return true;
#pragma warning restore 618
#endif
			if (driver is FirebirdDriver) return true;
			return false;
		}

		/// <summary>
		/// If driver is Firebird, clear the pool.
		/// Firebird will pool each connection created during the test and will marked as used any table
		/// referenced by queries. It will at best delays those tables drop until connections are actually
		/// closed, or immediately fail dropping them.
		/// This results in other tests failing when they try to create tables with same name.
		/// By clearing the connection pool the tables will get dropped. This is done by the following code.
		/// Moved from NH1908 test case, contributed by Amro El-Fakharany.
		/// </summary>
		public static void ClearPoolForFirebirdDriver(this IDriver driver)
		{
			switch (driver)
			{
#if !NETCOREAPP2_0
#pragma warning disable 618
				case FirebirdClientDriver fbDriver:
					fbDriver.ClearPool(null);
					break;
#pragma warning restore 618
#endif
				case FirebirdDriver fbDriver2:
					fbDriver2.ClearPool(null);
					break;
			}
		}

		public static bool IsOracleDataClientDriver(this IDriver driver)
		{
#if !NETCOREAPP2_0
			if (driver is OracleDataClientDriver) return true;
#endif
			return false;
		}

		public static bool IsOracleDataClientDriver(this System.Type driverClass)
		{
#if !NETCOREAPP2_0
			if (typeof(OracleDataClientDriver).IsAssignableFrom(driverClass)) return true;
#endif
			return false;
		}

		public static bool IsOracleLiteDataClientDriver(this IDriver driver)
		{
#if !NETCOREAPP2_0
			if (driver is OracleLiteDataClientDriver) return true;
#endif
			return false;
		}

		public static bool IsOracleManagedDriver(this IDriver driver)
		{
#if !NETCOREAPP2_0
#pragma warning disable 618
			if (driver is OracleManagedDataClientDriver) return true;
#pragma warning restore 618
			if (driver is OracleManagedDriver) return true;
#endif
			return false;
		}
	}
}