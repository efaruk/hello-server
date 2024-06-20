#nullable disable



namespace ServerInfo.Models
{
    public class ServerInformationModel
    {
        public string ConnectionId { get; set; }
        public string TraceIdentifier { get; set; }
        public string Url { get; set; }
        public string RequestProtocol { get; set; }
        public string RequestScheme { get; set; }
        public string RequestHost { get; set; }
        public string RequestPort { get; set; }
        public string RequestMethod { get; set; }
        public string RequestPathBase { get; set; }
        public string RequestPath { get; set; }
        public string RequestQueryString { get; set; }
        public string RemoteIpAddress { get; set; }
        public string RemotePort { get; set; }
        public string LocalIpAddress { get; set; }
        public string LocalPort { get; set; }
        public string ContentType { get; set; }
        public string ContentLength { get; set; }

        public Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> RequestCookies { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> QueryParameters { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> FormParameters { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> EnvironmentVariables { get; set; } = new Dictionary<string, string>();
        
    }
}
