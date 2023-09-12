<%@ WebHandler Language="C#" Class="proxy" %>


using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;

/// <summary>
/// adapted from: http://code.google.com/p/iisproxy
/// </summary>
public class proxy : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        var request = context.Request;
        var remoteUrl = request.QueryString["url"];
            
        var req = (HttpWebRequest)WebRequest.Create(remoteUrl);
        req.AllowAutoRedirect = false;
        req.Method = request.HttpMethod;
        req.ContentType = request.ContentType;
        req.UserAgent = request.UserAgent;
        //var basicPwd = ConfigurationSettings.AppSettings.Get("basicPwd");
        //req.Credentials = basicPwd == null ?
        //    CredentialCache.DefaultCredentials :
        //    new NetworkCredential(HttpContext.Current.User.Identity.Name, basicPwd);
        req.PreAuthenticate = true;
        req.Headers["Remote-User"] = HttpContext.Current.User.Identity.Name;
        foreach (string each in request.Headers)
            if (!WebHeaderCollection.IsRestricted(each) && each != "Remote-User")
                req.Headers.Add(each, request.Headers.Get(each));
        if (request.HttpMethod == "POST")
        {
            var outputStream = req.GetRequestStream();
            CopyStream(request.InputStream, outputStream);
            outputStream.Close();
        }

        HttpWebResponse response;
        try
        {
            response = (HttpWebResponse)req.GetResponse();
        }
        catch (WebException we)
        {
            response = (HttpWebResponse)we.Response;
            if (response == null)
            {
                context.Response.StatusCode = 404;
                context.Response.Write("Could not contact back-end site");
                context.Response.End();
                return;
            }
        }

        context.Response.StatusCode = (int)response.StatusCode;
        context.Response.StatusDescription = response.StatusDescription;
        context.Response.ContentType = response.ContentType;
        //if (response.Headers.Get("Location") != null)
        //{
        //    var urlSuffix = response.Headers.Get("Location");
        //    if (urlSuffix.ToLower().StartsWith(ConfigurationSettings.AppSettings["ProxyUrl"].ToLower()))
        //        urlSuffix = urlSuffix.Substring(ConfigurationSettings.AppSettings["ProxyUrl"].Length);
        //    context.Response.AddHeader("Location", request.Url.GetLeftPart(UriPartial.Authority) + urlSuffix);
        //}
        foreach (string each in response.Headers)
            if (each != "Location" && !WebHeaderCollection.IsRestricted(each))
                context.Response.AddHeader(each, response.Headers.Get(each));

        CopyStream(response.GetResponseStream(), context.Response.OutputStream);
        response.Close();
        context.Response.End();
    }

    static public void CopyStream(Stream input, Stream output)
    {
        //updated to read gzip compressed streams correctly
        byte[] buffer = new byte[32768];
        while (true)
        {
            int read = input.Read(buffer, 0, buffer.Length);
            if (read <= 0)
                return;
            output.Write(buffer, 0, read);
        }
    }
    public bool IsReusable
    {
        get { return false; }
    }
}
