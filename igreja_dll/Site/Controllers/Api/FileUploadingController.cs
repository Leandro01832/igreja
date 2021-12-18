using Ecommerce.Classes;
using RepositorioEF;
using Site.Models.Api;
using System.Data.Entity;
using System.IO;
using System.Web.Http;

namespace Site.Controllers.Api
{
    public class FileUploadingController : ApiController
    {
        private DB db = new DB();

        [HttpPost]
        [Route("SetFoto")]
        public IHttpActionResult SetFoto(PhotoRequest people)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var pessoa = db.pessoas.Find(people.Id);

            if (pessoa == null)
                return BadRequest("A pessoa não existe");

            var stream = new MemoryStream(people.Array);

            var folder = "~/Content/Imagens";
            var file = string.Format("{0}.jpg", people.Id);
            var fullPath = string.Format("{0}/{1}", folder, file);
            var response = FileHelpers.UploadPhoto(stream, folder, file);

            if(!response)
                return BadRequest("Foto não enviada");

            pessoa.Img = fullPath.Replace("~", "");
            db.Entry(pessoa).State = EntityState.Modified;
            db.Entry(pessoa.Chamada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("foto enviada");
        }

    }
}
