using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Utilities.Static
{
	public static class UrlHelper
	{

        public static string GetPath(HttpRequest request)
        {
            string Url = string.Format("{0}://{1}", request.Scheme, request.Host);
            if (!string.IsNullOrEmpty(request.PathBase))
            {
                Url += request.PathBase + "/";
            }
            else
            {
                Url = string.Format("{0}://{1}/", request.Scheme, request.Host);
            }
            return Url;
        }
    }
}

