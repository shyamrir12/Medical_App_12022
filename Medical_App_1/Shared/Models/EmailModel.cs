using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models
{
    class EmailModel
    {
        public string MailServer { get; set; }
        public string SenderEmail_Id { get; set; }
        public string SenderPassword { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string MailServerPort { get; set; }
        public List<Guid> FileUploadList { get; set; }
        public List<string> FilePathList { get; set; }
    }
}
