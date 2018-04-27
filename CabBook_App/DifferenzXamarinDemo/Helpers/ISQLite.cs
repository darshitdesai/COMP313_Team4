/*Author: Heli Thakkar
Date: March 16, 2018
Purpose: SQlite Operations Declaration*/

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

