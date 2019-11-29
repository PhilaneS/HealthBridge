using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthbridgeApi.Dto
{
    public class CustomDateAttribute : ValidationAttribute
    {
        /// <summary>
        /// This custom atribute validate future date.
        /// </summary>
        /// <param name="value"> datetime </param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}
