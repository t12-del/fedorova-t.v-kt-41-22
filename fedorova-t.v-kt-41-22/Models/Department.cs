﻿using System.Text.RegularExpressions;

namespace fedorova_t.v_kt_41_22.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public int? HeadId { get; set; }
        public virtual Teacher? Head { get; set; }
        //public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();


        public bool IsValidDepartmentName()
        {
            return !string.IsNullOrEmpty(Name) &&
                   Regex.IsMatch(Name, @"^[a-zA-Zа-яА-ЯёЁ]+$");
        }

        // Проверка числовых идентификаторов
        public bool IsValidDepartmentDate()
        {
            // Дата основания должна быть не раньше 1 сентября 1967 года
            var cutoffDate = new DateTime(1967, 9, 1);
            return FoundedDate >= cutoffDate;
        }

        public bool IsValidDepartmentHead()
        {
            return HeadId > 0;
        }

        // Проверка строки, можно ли её преобразовать в число
        public static bool IsValidNumberInput(string input)
        {
            return int.TryParse(input, out int result);
        }
    }
}
