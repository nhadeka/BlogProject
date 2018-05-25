using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Blog.UIL.Web.App_Class
{
    public class MySettings
    {
        public static Size SmallPicSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return result;
            }
        }
        public static Size MediumPicSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);
                return result;
            }
        }
        public static Size LargePicSize
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
                return result;
            }
        }
    }
}