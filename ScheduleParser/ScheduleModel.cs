using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleParser
{
    public class StudyDay
    {
        /// <summary>
        /// Массив пар дня. Размер фиксирован на 7, чтобы сохранить всем рассужлк. Последние два дня надо инициализировать пустыми и 
        /// </summary>
        Lesson?[] Lessons = new Lesson?[7];

        /// <summary>
        /// Представляет день недели. Индексация с 1 до 7 
        /// </summary>
        public DayOfWeek? dayofweek { get; init; }
        /// <summary>
        /// Сама дата дня
        /// </summary>
        public DateOnly? date { get; init; }
        
        /// <summary>
        /// Если день выходной, то эта перменная должна быть true
        /// </summary>
        public bool? IsShabash = false;
    }
    /// <summary>
    /// Класс недели.
    /// </summary>
    public class WeekSchedule
    {
        public StudyDay[] studyDays;
        public WeekSchedule(StudyDay[] days)
        {
            if (days.Length != 6)
            {
                throw new ArgumentException($"Массив дней должен содержать в себе семь элементов, а содержал {days.Length}");
            }
            else
            {
            studyDays = days;

            }
        }

    }

    /// <summary>
    /// Класс пары
    /// </summary>
    public record Lesson
    {
        /// <summary>
        /// Имя преподавателя
        /// </summary>
        public string? TeacherName;
        /// <summary>
        /// Номер кабинета
        /// </summary>
        public int? ClassroomNumber;
        /// <summary>
        /// Название пары
        /// </summary>
        public string? LessonName;
        
    }
    /// <summary>
    /// Дни недели. Индексация с 1 до 7.
    /// </summary>
    public enum DayOfWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday= 3,
        Thursday= 4,
        Friday= 5,
        Saturday= 6,
        Sunday= 7
    }
}
