
namespace Api
{
    public class Usuario
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set;}
        public string token { get; set;}

        public int tipo_usuario { get; set; }
    }
}