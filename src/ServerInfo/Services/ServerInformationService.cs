using System.Collections;
using Microsoft.AspNetCore.Http.Extensions;
using ServerInfo.Models;

namespace ServerInfo.Services
{
    public class ServerInformationService : IServerInformationService
    {
        private const string NotAvailable = "";
        public ServerInformationModel GetServerInformation(HttpContext httpContext)
        {
            var model = new ServerInformationModel()
            {
                ConnectionId = httpContext.Connection.Id,
                TraceIdentifier = httpContext.TraceIdentifier,
                Url = httpContext.Request.GetDisplayUrl(),
                RequestProtocol = httpContext.Request.Protocol,
                RequestScheme = httpContext.Request.Scheme,
                RequestHost = httpContext.Request.Host.Host,
                RequestPort = httpContext.Request.Host.Port.HasValue ? httpContext.Request.Host.Port.Value.ToString() : NotAvailable,
                RequestMethod = httpContext.Request.Method,
                RequestPathBase = httpContext.Request.PathBase,
                RequestPath = httpContext.Request.Path,
                RequestQueryString = httpContext.Request.QueryString.ToString(),
                RemoteIpAddress = httpContext.Connection.RemoteIpAddress != null ? httpContext.Connection.RemoteIpAddress.ToString() : NotAvailable,
                RemotePort = httpContext.Connection.RemotePort.ToString(),
                LocalIpAddress = httpContext.Connection.LocalIpAddress != null ? httpContext.Connection.LocalIpAddress.ToString() : NotAvailable,
                LocalPort = httpContext.Connection.LocalPort.ToString(),
                ContentType = httpContext.Request.ContentType ?? NotAvailable,
                ContentLength = httpContext.Request.ContentLength.HasValue ? httpContext.Request.ContentLength.ToString() : NotAvailable,
            };

            foreach (var header in httpContext.Request.Headers)
            {
                model.RequestHeaders.Add(header.Key, header.Value);
            }

            foreach (var cookie in httpContext.Request.Cookies)
            {
                model.RequestCookies.Add(cookie.Key, cookie.Value);
            }

            foreach (var query in httpContext.Request.Query)
            {
                model.QueryParameters.Add(query.Key, query.Value.ToString());
            }

            if (httpContext.Request.HasFormContentType && httpContext.Request.Form != null)
            {
                foreach (var form in httpContext.Request.Form)
                {
                    model.FormParameters.Add(form.Key, form.Value);
                }
            }

            var envVars = Environment.GetEnvironmentVariables();
            foreach(DictionaryEntry de in envVars) 
            {
                var key = de.Key.ToString();
                if (!string.IsNullOrWhiteSpace(key)) {
                    model.EnvironmentVariables.Add(key, de.Value?.ToString() ?? "");
                }
            }

            return model;
        }
    }
}
