 using System.Diagnostics;

namespace IES_ADMIN_ACADEM_API.Config
{
    /// <summary>
    /// Error codes objects only for read and used to throw business exceptions when its required
    /// </summary>
    public static class BusinessErrorCodes
    {
        public static readonly ErrorResponse USER_VALIDATION_USER_NOEXISTS           = new ErrorResponse(4370001, "El usuario que busca no existe.");
        public static readonly ErrorResponse USER_VALIDATION_USER_PASSWORDNOTMATCH   = new ErrorResponse(4370002, "La contraseña no coincide.");
        public static readonly ErrorResponse USER_VALIDATION_USER_MISSMATCH          = new ErrorResponse(4370003, "Los datos de acceso no son coincidentes o son inválidos.");
        public static readonly ErrorResponse USER_VALIDATION_DESKAPP                 = new ErrorResponse(4370005, "El usuario no pertenece al grupo permitido para usar esta aplicación.");
        public static readonly ErrorResponse USER_GETAPPPERMISSIONS_NORECORDS        = new ErrorResponse(4370006, "El usuario no presenta registros de permisos de aplicativos del sistema de información.");
        public static readonly ErrorResponse USER_GETPROFILE_DATA_EMPTY              = new ErrorResponse(4370007, "El usuario figura en el sistema de información pero no presenta datos asociados.");
        public static readonly ErrorResponse USER_ATTRIBUTEUPDATE_FAILS              = new ErrorResponse(4370008, "No se pudo realizar cambio/s en los atributos del usuario.");
        public static readonly ErrorResponse USER_SIGNUP_ATTRB_MISSMATCH             = new ErrorResponse(4370009, "El registro de usuario no se puede aplicar porque los datos a registrar están erróneos o incompletos.");
        public static readonly ErrorResponse USER_SIGNUP_DUPLICATED                  = new ErrorResponse(4370010, "El registro de usuario no se puede aplicar porque ya existe.(Comprobación por nombre de usuario).");
        public static readonly ErrorResponse USER_SIGNUP_QUERY_ERROR                 = new ErrorResponse(4370011, "El registro de usuario no se puede aplicar debido a un error en el repositorio/base de datos.");
        public static readonly ErrorResponse USER_GETSTUDENT_PROFILEDATA_EMPTY       = new ErrorResponse(4370012, "El usuario figura en el sistema de información pero no pertenece al grupo de estudiantes.");
        public static readonly ErrorResponse USER_STD_ACCESS                         = new ErrorResponse(4370013, "El estudiante no tiene permitido el acceso al portal estudiantil.");
        public static readonly ErrorResponse USER_ATTRIBUTEUPDATE_ILEGAL             = new ErrorResponse(4370014, "El atributo que intenta actualizar/modificar no puede ser actualizado debido a restricciones de negocio.");
        public static readonly ErrorResponse USER_REMOTION_FAILS                     = new ErrorResponse(4370015, "El borrado de usuario no se puede realizar debido a un error en el repositorio/base de datos.");
        public static readonly ErrorResponse USER_PROFILE_UPDATE_FAILS               = new ErrorResponse(4370016, "La actualización del perfil de usuario no se puede realizar debido a un error en el repositorio/base de datos.");
        public static readonly ErrorResponse USER_REMOTION_PREVALIDATION_CANT_EMPTY  = new ErrorResponse(4370017, "El usuario es válido pero no cuenta con más registros en la base de datos.");
        public static readonly ErrorResponse GENERAL_CONVENTION_CODE_NOEXISTS        = new ErrorResponse(4370018, "El código de convención que busca no existe.");
        public static readonly ErrorResponse GENERAL_CONVENTION_SRCTABLE_NOTEXISTS   = new ErrorResponse(4370019, "El nombre de tabla origen no existe.");
        public static readonly ErrorResponse GENERAL_CONVENTION_SRCTABLE_NOTGIVEN    = new ErrorResponse(4370020, "El nombre de tabla origen no fue ingresado.");
        public static readonly ErrorResponse GENERAL_CONVENTION_CODE_NOTGIVEN        = new ErrorResponse(4370021, "El código de conveción no fue ingresado.");
        public static readonly ErrorResponse GENERAL_APPCODE_NOTGIVEN                = new ErrorResponse(4370022, "El código de aplicación no fue ingresado.");
        public static readonly ErrorResponse GENERAL_APPCODE_NOEXISTS                = new ErrorResponse(4370023, "La aplicación no existe.");
        public static readonly ErrorResponse USER_EVENTLOG_WORK_FAILS                = new ErrorResponse(4370024, "No se pudo registrar el evento del ámbito laboral debido a un error en el repositorio/base de datos.");
        public static readonly ErrorResponse USER_EVENTLOG_STDNT_FAILS               = new ErrorResponse(4370025, "No se pudo registrar el evento del ámbito de usuarios estudiantes debido a un error en el repositorio/base de datos.");
        public static readonly ErrorResponse USER_EVENTLOG_ADD_OBJFAIL               = new ErrorResponse(4370026, "La petición no recibió los parámetros esperados.");
    }

    /// <summary>
    /// Object to handle business exception code and message predefined on class ErrorCodes
    /// </summary>
    public class ErrorResponse
    {
        private readonly int code;       //Code of business error logic/rule/description
        private readonly string message; //Message/description about the associated error

        //Constructor
        public ErrorResponse(int code, string message)
        {
            this.code    = code;
            this.message = message;
        }

        //Getters
        public int Code       { get => code;    }
        public string Message { get => message; }
    }
}
