using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SmartSchool.WEBAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime dateTime){
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTime.Year;

            if(currentDate<dateTime.AddYears(age))
            age--;
            return age;
        }

    }
}