using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using enesatac_site.Models;

namespace enesatac_site
{
    public static class SeoFriendlyUrl
    {
        public static string MakaleSeoLink(this UrlHelper urlHelper, Articles entity)
        {
            string title = entity.Article_Title;
            int id = entity.Article_Id;
            title = FriendlyURLTitle(title);
            return string.Format("/makale/detay/{0}/{1}",id, title);
        }

        public static string KategoriSeoLink(this UrlHelper urlHelper, Categorys entity)
        {
            string title = entity.Category_Name;
            int id = entity.Category_Id;
            title = FriendlyURLTitle(title);
            return string.Format("/kategori/liste/{0}/{1}", id, title);
        }

        public static string YazarSeoLink(this UrlHelper urlHelper, Authors entity)
        {
            string title = entity.Author_Name;
            int id = entity.Auther_Id;
            title = FriendlyURLTitle(title);
            return string.Format("/yazar/detay/{0}/{1}", id, title);
        }

        public static string FriendlyURLTitle(string pTitle)
        {
            pTitle = pTitle.Replace(" ", "-");
            pTitle = pTitle.Replace(".", "-");
            pTitle = pTitle.Replace("ı", "i");
            pTitle = pTitle.Replace("İ", "I");

            pTitle = String.Join("", pTitle.Normalize(NormalizationForm.FormD)
                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));

            pTitle = HttpUtility.UrlEncode(pTitle);
            pTitle = pTitle.ToLower();
            return System.Text.RegularExpressions.Regex.Replace(pTitle, @"\%[0-9A-Fa-f]{2}", "");
        }
    }
}