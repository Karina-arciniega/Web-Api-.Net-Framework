using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Api.Controllers
{
    public class AccessController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUsuarios() 
        {

            List<Usuario> list = new List<Usuario>();
            using (Models.ApiEntities db = new Models.ApiEntities())
            {
                list = (from d in db.usuarios
                        select new Usuario
                        {
                            Id = d.id,
                            usuario = d.usuario1,
                            contrasena = d.contrasena,
                            estado = d.estado,
                            token = d.token,
                        }).ToList();
            }

            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult ComprobarUsuarios([FromBody]Usuario user)
        {
            int respuesta = 0;
            
            using (Models.ApiEntities db = new Models.ApiEntities())
            {
               var list = db.usuarios.Where(x => x.usuario1 == user.usuario && x.contrasena == user.contrasena);

                if (list.Count()>0)
                {
                    respuesta = 1;
                }
                else
                {
                    respuesta = 0;
                }
            }

            return Ok(respuesta);
        }

      
    }
}
