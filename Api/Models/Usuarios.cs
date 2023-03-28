using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }
        public string token { get; set; }
    }
}