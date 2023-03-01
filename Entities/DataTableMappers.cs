using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPoco.RowMappers;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace IES_ADMIN_ACADEM_API.Entities
{
    static class DataTableMappers
    {
        
        public static List<portalLaboral> mapPortalLaboral(DataTable tempDt)
        {
            return (from reg in tempDt.AsEnumerable()
                    select new portalLaboral()
                    {
                        Username = Convert.ToString(reg["nickname_usuario"]),
                        Password = Convert.ToString(reg["pkeyusuario"]),
                        Recovery_quest = Convert.ToString(reg["recuperar_pregunta"]),
                        Recovery_ans = Convert.ToString(reg["recuperar_respuesta"]),
                        Deskapp_access = Convert.ToInt32(reg["deskapp"])
                    })
                    .ToList();
        }

        public static List<sisInfoUser> mapSisInfoUser(DataTable tempDt)
        {
            return (from reg in tempDt.AsEnumerable()
                    select new sisInfoUser()
                    {
                        User = Convert.ToString(reg["NICKNAME"]),
                        Appcode = Convert.ToString(reg["APPCODE"]),
                        Permission = Convert.ToBoolean(reg["PERMISSION"]),
                        Appname = Convert.ToString(reg["APPNAME"]),
                        Appdescr = Convert.ToString(reg["APPDESCRIPTION"]),
                        Treelevel = Convert.ToInt32(reg["TREELEVEL"])
                    }
                ).ToList();
        }

        public static List<userProfile> mapUserProfile(DataTable tempDt)
        {
            return (from reg in tempDt.AsEnumerable()
                    select new userProfile()
                    {
                        FechaRegistro = Convert.ToString(reg["FECHAREGISTRO"]),
                        IdPersona = Convert.ToString(reg["IDPERSONA"]),
                        Nombres = Convert.ToString(reg["NOMBRES"]),
                        Apellidos = Convert.ToString(reg["APELLIDOS"]),
                        Username = Convert.ToString(reg["USERNAME"]),
                        Genero = Convert.ToString(reg["GENERO"]),
                        EmailLaboral = Convert.ToString(reg["EMAIL_LABORAL"]),
                        OrigenPais = Convert.ToString(reg["ORIGEN_PAIS"]),
                        OrigenCiudad = Convert.ToString(reg["ORIGEN_CIUDAD"]),
                        ResidePais = Convert.ToString(reg["RESIDE_PAIS"]),
                        ResideCiudad = Convert.ToString(reg["RESIDE_CIUDAD"]),
                        Escolaridad = Convert.ToString(reg["ESCOLARIDAD"]),
                        PkeyUsuario = Convert.ToString(reg["PKEYUSUARIO"]),
                        RecuperarPregunta = Convert.ToString(reg["RECUPERAR_PREGUNTA"]),
                        RecuperarRespuesta = Convert.ToString(reg["RECUPERAR_RESPUESTA"]),
                        NivelCargo = Convert.ToString(reg["NIVELCARGO"]),
                        NombreCargo = Convert.ToString(reg["NOMBREDELCARGO"]),
                        NombreUnidad = Convert.ToString(reg["NOMBREUNIDAD"]),
                        UltimoAcceso = Convert.ToString(reg["ULTIMOINGRESO"])
                    }).ToList();
        }


    }
}
