using System;
using SQLite;
namespace VacayTrack
{
	public class VacationRequest
	{
        // ID, PersonName, Year, Month, StartDay, FinishDay, Duration


        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string PersonName { get; set; }

        public int year;

        public int Year //свойство для года
        {
            get => year;
            set
            {
                if (value < 2024)
                    year = 2024;
                else
                    year = value;
            }
        }

        public int month;

        public int Month //свойство для месяца
        {
            get => month;
            set
            {
                if (value < 1)
                    year = 1;
                else if (value > 12)
                    year = 12;
                else
                    year = value;
            }
        }

        public int startDay;

        public int StartDay //свойство для дня начала отпуска
        {
            get => startDay;
            set
            {
                if (value < 1)
                    startDay = 1;
                else if (value > 31)
                    startDay = 31;
                else
                    startDay = value;
            }
        }

        public int finishDay;

        public int FinishDay //свойство для дня конца отпуска
        {
            get => finishDay;
            set
            {
                if (value < 1)
                    finishDay = 1;
                else if (value > 31)
                    finishDay = 31;
                else
                    finishDay = value;
            }
        }

        public int duration;

        public int Duration //свойство для длительности отпуска
        {
            get => duration;
            set
            {
                if (value < 1)
                    duration = 1;
                else if (value > 31)
                    duration = 31;
                else
                    duration = value;
            }
        }
    }
}

