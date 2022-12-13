using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models
{
    class Log
    {
    }
    public class LogMetaData
    {
        public string RequestData { get; set; }
        public string RequestContentType { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public string RequestFromMobile { get; set; }
        public string RequestFromImeiNo { get; set; }
        public DateTime? RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }
        public DateTime? ResponseTimestamp { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseData { get; set; }
    }
    public enum LogType
    {
        InformationLog,
        ErrorLog
    }
}
