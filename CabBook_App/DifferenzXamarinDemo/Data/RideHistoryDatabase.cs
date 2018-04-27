/*Author: Heli Thakkar
Date: March 16, 2018
Purpose: Sqlite operations with User Database*/

using System;
using Xamarin.Forms;
using SQLite;



using System.Collections.Generic;
using System.Linq;

namespace CabBook
{
    /// <summary>
    /// UserDatabase - Contains definitions for SQLite operations
    /// </summary>
	public class RideInformationDatabase
    {
		static object locker = new object ();

		SQLiteConnection database;

		public RideInformationDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<RideInformation>();
		}

		public List<RideInformation> GetAll () 
		{
			lock (locker) {
				return database.Table<RideInformation>().ToList();
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<RideInformation>(id);
			}
		}
	}
}

