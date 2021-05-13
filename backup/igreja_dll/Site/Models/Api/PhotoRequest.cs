using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class PhotoRequest
    {
        public int Id { get; set; }
        public byte[] Array { get; set; }
    }
}