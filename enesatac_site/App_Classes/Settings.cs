using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Configuration;

namespace enesatac_site.App_Classes
{
    public class Settings
    {
        public static Size KucukBoyutResim
        {
            get
            {
                Size boyut = new Size();
                boyut.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                boyut.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return boyut;
            }
        }
        public static Size OrtaBoyutResim
        {
            get
            {
                Size boyut = new Size();
                boyut.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                boyut.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);
                return boyut;
            }
        }
        public static Size BuyukBoyutResim
        {
            get
            {
                Size boyut = new Size();
                boyut.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                boyut.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
                return boyut;
            }
        }
    }
}