using IES_ADMIN_ACADEM_API.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Org.BouncyCastle.Crypto.Tls;
using System.Data;

namespace IES_ADMIN_ACADEM_API.Repository
{
    /// <summary>
    /// Collection of methods that gather data from the DDBB
    /// </summary>
    public class accessRepository
    {
        //Object to handle DDBB connections and querys
        readonly daoManager daoMgr = new daoManager();



        public List<portalLaboral> validateUsername(string username)
        {
            //            DataTable resultSet = daoMgr.retrieveData("SELECT * FROM uf_portallaboral WHERE NICKNAME_USUARIO = '" + username + "'");
            DataTable resultSet = daoMgr.retrieveData(string.Format("SELECT * FROM uf_portallaboral WHERE NICKNAME_USUARIO = '{0}';",username));
            if (resultSet.Rows.Count == 1)
            {
                //Map the data table to object
                return DataTableMappers.mapPortalLaboral(resultSet);
            }
            else
            {
                //There is no data related to the query
                return null;
            }
        }
        public List<portalLaboral> validateAccess(string username, string pwd)
        {
            DataTable resultSet = daoMgr.retrieveData(string.Format("SELECT * FROM uf_portallaboral WHERE nickname_usuario = '{0}' AND pkeyusuario = '{1}';",username,pwd));
            if (resultSet.Rows.Count == 1)
            {
                //Map the data table to object
                return DataTableMappers.mapPortalLaboral(resultSet);
            }
            else
            {
                //There is no data related to the query
                return null;
            }
        }

        public List<sisInfoUser> getApps(string username) {

            DataTable resultSet = daoMgr.retrieveData(string.Format("SELECT null AS NICKNAME, " +
                                                        "sia.APPCODE, " +
                                                        "1 AS PERMISSION, " +
                                                        "sia.APPNAME, " +
                                                        "sia.APPDESCRIPTION, " +
                                                        "sia.TREELEVEL " +
                                                        "FROM " +
                                                        "uf_sisinfo_apps sia " +
                                                        "WHERE " +
                                                        "sia.APPDESCRIPTION IN('') " +
                                                        "UNION " +
                                                        "SELECT " +
                                                        "sip.*, " +
                                                        "sia2.APPNAME, " +
                                                        "sia2.APPDESCRIPTION, " +
                                                        "sia2.TREELEVEL " +
                                                        "FROM " +
                                                        "uf_sisinfo_permisibilidad sip, " +
                                                        "uf_sisinfo_apps sia2 " +
                                                        "WHERE " +
                                                        "sip.NICKNAME = '{0}' " +
                                                        "AND sip.PERMISSION = 1 " +
                                                        "AND sia2.APPCODE = sip.APPCODE;",username));
            if (resultSet.Rows.Count > 1)
            {
                //Map the data table to object
                return DataTableMappers.mapSisInfoUser(resultSet);
            }
            else
            {
                //There is no data related to the query
                return null;
            }
        }

        public List<userProfile> getProfileData(string username, string pwd) {

            DataTable resultSet = daoMgr.retrieveData(string.Format("SELECT  " +
                                                        "ufp.*, " +
                                                        "ufpl.PKEYUSUARIO, " +
                                                        "ufpl.RECUPERAR_PREGUNTA, " +
                                                        "ufpl.RECUPERAR_RESPUESTA, " +
                                                        "ufcc.NIVEL AS NIVELCARGO, " +
                                                        "ufcc.NOMBRE AS NOMBREDELCARGO, " +
                                                        "ufui1.NOMBREUNIDAD, " +
                                                        "ufpl.LAST_ACCESS AS ULTIMOINGRESO " +
                                                        "FROM  uf_personas AS ufp " +
                                                        "LEFT JOIN uf_portallaboral AS ufpl ON ufp.USERNAME = ufpl.NICKNAME_USUARIO " +
                                                        "LEFT JOIN uf_personalinstitucional AS ufpi ON ufp.USERNAME = ufpi.NICKNAME " +
                                                        "LEFT JOIN uf_codigoscargos AS ufcc ON ufpi.CARGO = ufcc.CODIGO " +
                                                        "LEFT JOIN uf_unidades_institucionales ufui1 ON ufpi.DEPARTAMENTO = ufui1.CODIGOUNIDAD  " +
                                                        "WHERE  " +
                                                        "ufpl.NICKNAME_USUARIO = '{0}'  " +
                                                        "AND ufpl.PKEYUSUARIO = '{1}'  " +
                                                        "ORDER BY ufpi.TIPOPERSONAL ASC LIMIT 1;",username,pwd));
            if(resultSet.Rows.Count >= 1)
            {
                //Map the data table to object
                return DataTableMappers.mapUserProfile(resultSet);
            }
            else
            {
                //There is no data related to the query
                return null;
            }
        }

        public bool setLastAccessRecord(string usr, string pwd, string newdate)
        {
            if (
                daoMgr
                .updateData(
                    string
                    .Format("UPDATE " +
                    "uf_portallaboral " +
                    "SET LAST_ACCESS = '{0}' " +
                    "WHERE " +
                    "NICKNAME_USUARIO = '{1}' " +
                    "AND PKEYUSUARIO = '{2}';", 
                    newdate, usr, pwd))
                > 
                0
                ) {
                //Update statement successful
                return true;
            }
            else
            {
                //Update statement failure
                return false;
            }
        }

    }
}
