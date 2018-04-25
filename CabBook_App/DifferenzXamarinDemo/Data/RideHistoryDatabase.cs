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

        

        /// <summary>
        /// Gets all user address data.
        /// </summary>
        /// <returns>all user address data.</returns>
		public List<RideInformation> GetAll () 
		{
			lock (locker) {
				return database.Table<RideInformation>().ToList();
			}
		}

        /// <summary>
        /// Saves the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="item">Item.</param>
		//public int SaveItem (RideInformation item) 
		//{
		//	//lock (locker) {
		//	//	if (item.ID != 0) {
		//	//		database.Update(item);
		//	//		return item.ID;
		//	//	} else {
		//	//		return database.Insert(item);
		//	//	}
		//	//}
		//}

        /// <summary>
        /// Saves the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="item">Item.</param>
		//public int SaveRide(RideInformation item)
  //      {
  //          lock (locker)
  //          {
  //              if (item.ID != 0)
  //              {
  //                  database.Update(item);
  //                  return item.ID;
  //              }
  //              else
  //              {
  //                  return database.Insert(item);
  //              }
  //          }
  //      }

        /// <summary>
        /// Deletes the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="id">Identifier.</param>
		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<RideInformation>(id);
			}
		}
	}
}

