﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ecommerce.Classes
{
    public class FileHelpers
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            string path = string.Empty;
           // string pic = string.Empty;

            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }


            try
            {
              if(file != null) {

                    path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                    file.SaveAs(path);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        
                    }
                   
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


            
        }

        public static bool UploadPhoto(MemoryStream stream, string folder, string name)
        {
            try
            {
                stream.Position = 0;
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                File.WriteAllBytes(path, stream.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}