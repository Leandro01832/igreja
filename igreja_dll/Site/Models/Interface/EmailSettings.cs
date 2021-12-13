using System.Web.Configuration;

namespace Site.Models.Interface
{
    public class EmailSettings
    {
         public string PrimaryDomaim {get; set;}
         public int PrimaryPort {get; set;}
         public string UsernameEmail {get; set;}
         public string UserNamePassword {get; set;}
         public string FromEmail {get; set;}
         public string ToEmail {get; set;}
         public string CcEmail { get; set; }


        public EmailSettings()
        {
            this.PrimaryDomaim = WebConfigurationManager.AppSettings["SMTPName"];
            this.PrimaryPort = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
            this.UsernameEmail = WebConfigurationManager.AppSettings["UsernameEmail"];
            this.UserNamePassword = WebConfigurationManager.AppSettings["UserNamePassword"];
            this.FromEmail = "FromEmail";
            this.ToEmail = WebConfigurationManager.AppSettings["UsernameEmail"];
            this.CcEmail = WebConfigurationManager.AppSettings["UsernameEmail"];
        }


    }
}
