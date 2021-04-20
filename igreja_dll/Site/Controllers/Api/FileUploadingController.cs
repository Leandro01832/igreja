using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Site.Controllers.Api
{
    public class FileUploadingController : ApiController
    {
        [Route("api/FileUploading/UploadFile")]
        public async Task<string> UploadFileAsync()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/Content/Imagens");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
               await Request.Content.ReadAsMultipartAsync(provider);

                foreach(var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;
                    name = name.Trim('"');

                    var localFileName = file.LocalFileName;
                    var filepath = Path.Combine(root, name);

                    File.Move(localFileName, filepath);
                }
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }

            return "Arquivo enviado!!!";
        }

    }
}
