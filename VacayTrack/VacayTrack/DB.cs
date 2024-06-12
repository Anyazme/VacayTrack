using System;
using System.Collections.Generic;
using SQLite;
namespace VacayTrack
{
	public class DB
	{
		private readonly SQLiteConnection connection;

		public DB(string path)
		{
			connection = new SQLiteConnection(path);
			connection.CreateTable<VacationRequest>();
		}

		public List<VacationRequest> GetVacationRequests()
		{
			return connection.Table<VacationRequest>().ToList();
		}

		public int SaveVacationRequest(VacationRequest vacationRequest)
		{
			return connection.Insert(vacationRequest);
		}


	}
}

