namespace IES_ADMIN_ACADEM_API.Entities
{
    public class userProfile
    {
        private string fechaRegistro;
        private string idPersona;
        private string nombres;
        private string apellidos;
        private string username;
        private string genero;
        private string emailLaboral;
        private string origenPais; private string origenCiudad; private string residePais; private string resideCiudad;
        private string escolaridad;
        private string pkeyUsuario;
        private string recuperarPregunta;
        private string recuperarRespuesta;
        private string nivelCargo;
        private string nombreCargo;
        private string nombreUnidad;
        private string ultimoAcceso;

        public userProfile()
        {
        }

        public userProfile(string fechaRegistro, string idPersona, string nombres, string apellidos, string username, string genero, string emailLaboral, string origenPais, string origenCiudad, string residePais, string resideCiudad, string escolaridad, string pkeyUsuario, string recuperarPregunta, string recuperarRespuesta, string nivelCargo, string nombreCargo, string nombreUnidad, string ultimoAcceso)
        {
            this.fechaRegistro = fechaRegistro;
            this.idPersona = idPersona;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.username = username;
            this.genero = genero;
            this.emailLaboral = emailLaboral;
            this.origenPais = origenPais;
            this.origenCiudad = origenCiudad;
            this.residePais = residePais;
            this.resideCiudad = resideCiudad;
            this.escolaridad = escolaridad;
            this.pkeyUsuario = pkeyUsuario;
            this.recuperarPregunta = recuperarPregunta;
            this.recuperarRespuesta = recuperarRespuesta;
            this.nivelCargo = nivelCargo;
            this.nombreCargo = nombreCargo;
            this.nombreUnidad = nombreUnidad;
            this.ultimoAcceso = ultimoAcceso;
        }

        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string IdPersona { get => idPersona; set => idPersona = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Username { get => username; set => username = value; }
        public string Genero { get => genero; set => genero = value; }
        public string EmailLaboral { get => emailLaboral; set => emailLaboral = value; }
        public string OrigenPais { get => origenPais; set => origenPais = value; }
        public string OrigenCiudad { get => origenCiudad; set => origenCiudad = value; }
        public string ResidePais { get => residePais; set => residePais = value; }
        public string ResideCiudad { get => resideCiudad; set => resideCiudad = value; }
        public string Escolaridad { get => escolaridad; set => escolaridad = value; }
        public string PkeyUsuario { get => pkeyUsuario; set => pkeyUsuario = value; }
        public string RecuperarPregunta { get => recuperarPregunta; set => recuperarPregunta = value; }
        public string RecuperarRespuesta { get => recuperarRespuesta; set => recuperarRespuesta = value; }
        public string NivelCargo { get => nivelCargo; set => nivelCargo = value; }
        public string NombreCargo { get => nombreCargo; set => nombreCargo = value; }
        public string NombreUnidad { get => nombreUnidad; set => nombreUnidad = value; }
        public string UltimoAcceso { get => ultimoAcceso; set => ultimoAcceso = value; }
    }
}
