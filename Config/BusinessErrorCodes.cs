namespace IES_ADMIN_ACADEM_API.Config
{
    /// <summary>
    /// Error codes objects only for read and used to throw business exceptions when its required
    /// </summary>
    public static class BusinessErrorCodes
    {
        public static readonly ErrorResponse USER_VALIDATION_USER_NO_EXISTS = new ErrorResponse(4370001, "El usuario que busca no existe.");
        public static readonly ErrorResponse USER_VALIDATION_USER_PASSWORDNOTMATCH = new ErrorResponse(4370002, "La contraseña no coincide.");
        public static readonly ErrorResponse USER_VALIDATION_USER_MISSMATCH = new ErrorResponse(4370003, "Los datos de acceso no son coincidentes o son inválidos");
        public static readonly ErrorResponse USER_VALIDATION_DESKAPP = new ErrorResponse(4370005, "El usuario no pertenece al grupo permitido para usar esta aplicación");
        public static readonly ErrorResponse USER_GETAPPPERMISSIONS_NORECORDS = new ErrorResponse(4370006, "El usuario no presenta registros de permisos de aplicativos del sistema de información");
        public static readonly ErrorResponse USER_GETPROFILE_DATA_EMPTY = new ErrorResponse(4370006, "El usuario figura en el sistema de información pero no presenta datos asociados");
        public static readonly ErrorResponse USER_ATTRIBUTEUPDATE_FAILS = new ErrorResponse(4370007, "No se pudo realizar cambio/s en los atributos del usuario");

    }

    /// <summary>
    /// Object to handle business exception code and message predefined on class ErrorCodes
    /// </summary>
    public class ErrorResponse
    {
        private int code;
        private string message;

        public ErrorResponse(int code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public int Code { get => code; }
        public string Message { get => message; }
    }
}
