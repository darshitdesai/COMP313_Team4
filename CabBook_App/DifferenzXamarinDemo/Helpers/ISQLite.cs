using System;
using SQLite;

namespace CabBook
{
    /// <summary>
    /// ISQLite - Contains declarations for SQLite Operations
    /// </summary>
	public interface ISQLite {
		SQLiteConnection GetConnection();
	}
}

