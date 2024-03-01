﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PCCC.Common.Utils
{
    public class Util
    {
        //đổi đầu số +84 = 0
        /// <summary>
        /// Chuyển đổi đầu 84 thành 0
        /// </summary>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        public static string convertPhone(string phonenumber)
        {
            if (phonenumber.Contains("+84"))
            {
                int length = phonenumber.Length - 3;
                phonenumber = "0" + phonenumber.Substring(3, length);
            }
            return phonenumber;
        }
        public static string convertPhone84(string phonenumber)
        {
            int length = phonenumber.Length - 1;
            phonenumber = "84" + phonenumber.Substring(1, length);
            return phonenumber;
        }
        //check định dạng sđt
        public static bool validPhone(string phone)
        {
            return Regex.Match(phone, @"^0[1-9]{1}[0-9]{8}$").Success;
        }

        public static bool ValidateEmail(string Email)
        {
            return Regex.Match(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
        //check định dạng số
        public static bool validNumber(string number)
        {
            // \d bắt buộc là số, dấu + bắt buộc xuất hiện 1 lần
            return Regex.Match(number, @"^[\d]+$").Success;
        }

        //check định dạng IMEI
        public static bool validImei(string number)
        {
            // \d bắt buộc là số, {15} bắt buộc đúng 15 số
            return Regex.Match(number, @"^[\d]{15}$").Success;
        }


        public static string CreateMD5(string input)
        {
            //bam du lieu
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static string ConvertCurrency(long Price)
        {
            return Price.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("is"));
        }
        public static string CheckNullString(string input)
        {
            string output = "";
            try
            {
                output = input.ToString();
            }
            catch
            {

            }
            return output;
        }
        private static readonly string[] VietNamChar = new string[]
{
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
};
        private static readonly string[] VietNamCharFile = new string[]
{

        "aA",
        "ã",
        "Ã",
};
        public static string ConvertsExportFile(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamCharFile.Length; i++)
            {
                for (int j = 0; j < VietNamCharFile[i].Length; j++)
                    str = str.Replace(VietNamCharFile[i][j], VietNamCharFile[0][i - 1]);
            }
            return str;
        }
        public static string Converts(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            else
                return builder.ToString().ToUpper();
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //Convert Datetime 
        public static Nullable<DateTime> ConvertFromDate(string date, string datepaser = PCCCConsts.CONVERT_DATETIME_HAVE_HOUR)
        {
            try
            {
                if (!String.IsNullOrEmpty(date))
                {
                    if (date.Contains("/"))
                    {
                        string[] dt = date.Split("/");
                        if (dt[1].Length < 2) dt[1] = "0" + dt[1];
                        if (dt[0].Length < 2) dt[0] = "0" + dt[0];
                        date = dt[0] + "/" + dt[1] + "/" + dt[2];
                        var dateTime = "00:00 " + date;
                        return DateTime.ParseExact(dateTime, datepaser, null);
                    }
                    else
                    {

                        string[] dt = date.Split("-");
                        if (dt[1].Length < 2) dt[1] = "0" + dt[1];
                        if (dt[0].Length < 2) dt[0] = "0" + dt[0];
                        date = dt[0] + "-" + dt[1] + "-" + dt[2];
                        var dateTime = "00:00 " + date;
                        return DateTime.ParseExact(dateTime, datepaser, null);
                    }
                    //return Convert.ToDateTime(dateTime);
                }


                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //Convert Datetime 
        public static Nullable<DateTime> ConvertToDate(string date, string datepaser = PCCCConsts.CONVERT_DATETIME_HAVE_HOUR)
        {
            try
            {
                if (!String.IsNullOrEmpty(date))
                {
                    if (date.Contains("/"))
                    {

                        string[] dt = date.Split("/");
                        if (dt[1].Length < 2) dt[1] = "0" + dt[1];
                        if (dt[0].Length < 2) dt[0] = "0" + dt[0];
                        date = dt[0] + "/" + dt[1] + "/" + dt[2];
                        var dateTime = "23:59 " + date;
                        return DateTime.ParseExact(dateTime, datepaser, null);

                    }
                    else
                    {

                        string[] dt = date.Split("-");
                        if (dt[1].Length < 2) dt[1] = "0" + dt[1];
                        if (dt[0].Length < 2) dt[0] = "0" + dt[0];
                        date = dt[0] + "-" + dt[1] + "-" + dt[2];
                        var dateTime = "23:59 " + date;
                        return DateTime.ParseExact(dateTime, datepaser, null);
                    }
                    //return Convert.ToDateTime(dateTime);
                }

                return null;
            }
            catch
            {
                return null;
            }

        }

        //Convert Datetime 
        public static Nullable<DateTime> ConvertDate(string date)
        {
            if (date != "")
            {
                try
                {
                    return DateTime.ParseExact(date, PCCCConsts.CONVERT_DATETIME, null);
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }
            }
            else
                return null;
        }

        //public static string GenPass(string pass)
        //{
        //    return BCrypt.Net.BCrypt.HashPassword(pass, 10);
        //}

        //public static bool CheckPass(string pass, string userPass)
        //{
        //    try
        //    {
        //        return BCrypt.Net.BCrypt.Verify(pass, userPass);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public static DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }
        public static string GenerateCode(string Prefix)
        {
            try
            {
                var Code = Prefix;
                const string chars = "0123456789";
                Random random = new Random();
                var randomStr = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
                Code += randomStr;
                return Code;
            }
            catch
            {
                return "";
            }
        }
        public static long? ConvertPriceStringToLong(string price)
        {
            try
            {
                var priceStr = price.Split(",");
                var millionPart = Double.Parse(priceStr[0]);
                return (Int32)(millionPart * PCCCConsts.MILLION);
            }
            catch
            {
                return null;
            }
        }
        public static string ConvertPriceLongToString(long? price)
        {
            try
            {
                var millionPart = price / PCCCConsts.MILLION;
                var priceStr = millionPart.ToString() + ",x";
                return priceStr;
            }
            catch
            {
                return null;
            }
        }
        // Gen Code của khách hàng
        public static string GenerateCodeProject()
        {
            var code = "";
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string nums = "0123456789";
            int length = 16;
            var randomStr = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            code += randomStr;
            return code;
        }
        
        public static int GetNumberOfWeekInMonth(DateTime date)
        {
            try
            {
                int days = DateTime.DaysInMonth(date.Year, date.Month);
                return (int)Math.Ceiling((decimal)days / (decimal)7);
            }
            catch
            {
                return 0;
            }
        }

    }
}
