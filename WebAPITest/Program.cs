using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAPITest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //var baseURL = "http://192.168.10.81:8080";
            var baseURL = "http://192.168.20.3:8080";
            #region 课程分类与专业
            {
                var url = $"{baseURL}/courseManager/courseTypeAndCourseMajorCategory.do";

                DebugHelper debugHelper = new DebugHelper();
                debugHelper.StartService();
                debugHelper.Print($"课程分类与专业::{WebAPIHelper.GetResultByPost(url)}");
            }
            #endregion

            #region 同步课程/直播课程时间表
            {
                var url = $"{baseURL}/courseManager/syncLiveCourseTimeTable.do";

                DebugHelper debugHelper = new DebugHelper();
                debugHelper.StartService();
                debugHelper.Print($"同步课程/直播课程时间表::{WebAPIHelper.GetResultByPost(url)}");
            }
            #endregion

            #region 获取学习兴趣
            {
                var url = $"{baseURL}/personalInterest/getPersonalInterestList.do";

                DebugHelper debugHelper = new DebugHelper();
                debugHelper.StartService();
                debugHelper.Print($"获取学习兴趣::{WebAPIHelper.GetResultByPost(url)}");
            }
            #endregion

            Console.ReadLine();
        }
    }
}
