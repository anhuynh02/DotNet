using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;

namespace TdtuTube.Libs
{
    public class VideoFormat
    {
        public static string titleShortening(string title, int length)
        {
            if (title.Length > length)
                title = title.Remove(length, title.Length - length).Insert(length, "...");
            return title;
        }
        public static string readableNumber(int view)
        {
            string num = "";
            if (view > 1000000000)
                num = Math.Round((double) view / 1000000000, 1) + " T";
            else if (view > 1000000)
                num = Math.Round((double) view / 1000000, 1) + " Tr";
            else if (view > 1000)
                num = Math.Round((double) view / 1000, 1) + " N";
            else
                num = view.ToString("#,##0");
            return num;
        }
        public static string dateAgo(DateTime date)
        {
            string dateAgo = "";
            var timeSpan = DateTime.Now.Subtract(date);
            if (timeSpan <= TimeSpan.FromSeconds(60))
                dateAgo = string.Format("{0} giây trước", timeSpan.Seconds);
            else if (timeSpan <= TimeSpan.FromMinutes(60))
                dateAgo = string.Format("{0} phút trước", timeSpan.Minutes);
            else if (timeSpan <= TimeSpan.FromHours(24))
                dateAgo = string.Format("{0} giờ trước", timeSpan.Hours);
            else if (timeSpan <= TimeSpan.FromDays(30))
                dateAgo = string.Format("{0} ngày trước", timeSpan.Days);
            else if (timeSpan <= TimeSpan.FromDays(365))
                dateAgo = string.Format("{0} tháng trước", timeSpan.Days / 30);
            else
                dateAgo = string.Format("{0} năm trước", timeSpan.Days / 365);
            return dateAgo;
        }

        public static string normalize(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower();
        }
    }
}