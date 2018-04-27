/*Author: Heli Thakkar*
Date: March 20, 2018*/


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
	public class UserDatabase
	{
		static object locker = new object ();

		SQLiteConnection database;

		public UserDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<UserData>();
		}

        /// <summary>
        /// Gets the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="EmailAddress">Email address.</param>
		public UserData GetItem (string EmailAddress) 
		{
			lock (locker) {
				return database.Table<UserData>().FirstOrDefault(x => x.EmailAddress == EmailAddress);
			}
		}

        /// <summary>
        /// Gets all user address data.
        /// </summary>
        /// <returns>all user address data.</returns>
		public List<UserData> GetAll () 
		{
			lock (locker) {
				return database.Table<UserData>().ToList();
			}
		}

        /// <summary>
        /// Saves the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="item">Item.</param>
		public int SaveItem (UserData item) 
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				} else {
					return database.Insert(item);
				}
			}
		}

        /// <summary>
        /// Deletes the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="id">Identifier.</param>
		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<UserData>(id);
			}
		}
	}
}

