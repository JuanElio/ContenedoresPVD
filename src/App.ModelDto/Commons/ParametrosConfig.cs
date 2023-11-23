using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ModelDto.Commons
{
    public class ParametrosConfig
    {
        public P_PIDE PIDE { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public FTPSettings FTPSettings { get; set; }


    }
    public class P_PIDE
    {
        public string ApiDni { get; set; }
        public string ApiRuc { get; set; }
    }
    public class EmailSettings
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }

        public string URLCorreo { get; set; }

    }
    public class FTPSettings
    {
        public string FTPDirectoryFiles { get; set; }
        public string FtpURL { get; set; }
        public string FtpUser { get; set; }
        public string FtpPassword { get; set; }
        public string UrlVisor { get; set; }
    }

}
