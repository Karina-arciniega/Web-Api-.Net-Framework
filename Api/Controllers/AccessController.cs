using Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class AccessController : ApiController
    {
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetUsuarios() 
        {

            List<Usuarios> list = new List<Usuarios>();
            using (Models.ApiEntities db = new Models.ApiEntities())
            {
                list = (from d in db.usuarios
                        select new Usuarios
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

        [System.Web.Http.HttpGet]
        public async Task< IHttpActionResult> ComprobarUsuariosGET(string usuario, string contrasena)
        {
            List<usuario> query = new List<usuario>();

            using (Models.ApiEntities db = new Models.ApiEntities())
            {
                query = (from pro in db.usuarios
                                        where pro.usuario1 == usuario && pro.contrasena == contrasena
                                        select pro).ToList();

                if (query.Count()>0)
                {
                    return Ok(query);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> ComprobarUsuariosPOST(string usuario, string contrasena)
        {
            List<usuario> query = new List<usuario>();

            using (Models.ApiEntities db = new Models.ApiEntities())
            {
                query = (from pro in db.usuarios
                         where pro.usuario1 == usuario && pro.contrasena == contrasena
                         select pro).ToList();

                if (query.Count() > 0)
                {
                    return Ok(query);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

    }
}
