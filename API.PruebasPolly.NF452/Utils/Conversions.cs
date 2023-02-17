using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.PruebasPolly.NF452.Utils
{
    public class Conversions
    {
        public static DateTime StringToDate(string dateString)
        {
            try
            {
                if (dateString.Length > 8)
                    return new DateTime(Convert.ToInt32(dateString.Substring(0, 4)), Convert.ToInt32(dateString.Substring(4, 2)), Convert.ToInt32(dateString.Substring(6, 2)),
                                        Convert.ToInt32(dateString.Substring(9, 2)), Convert.ToInt32(dateString.Substring(12, 2)), Convert.ToInt32(dateString.Substring(15, 2)));
                else
                    return new DateTime(Convert.ToInt32(dateString.Substring(0, 4)), Convert.ToInt32(dateString.Substring(4, 2)), Convert.ToInt32(dateString.Substring(6, 2)));

            }
            catch (Exception ex)
            {
                return new DateTime(1900, 1, 1);
            }
        }
    }
}