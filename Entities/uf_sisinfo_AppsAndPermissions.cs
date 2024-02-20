using System;

namespace IES_ADMIN_ACADEM_API.Entities
{
    public class uf_sisinfo_AppsAndPermissions
    {
        //DB Attributes of uf_sisinfo_apps
        private string APP_CODE;
        private string APP_NAME;
        private string APP_DESCR;
        private int APP_TREE_LEVEL;
        //DB Attributes of uf_sisinfo_permisos
        private string COD_USUARIO;
        private bool APP_PERMISSION;

        public uf_sisinfo_AppsAndPermissions() { }

        public uf_sisinfo_AppsAndPermissions(string app_code, string app_name, string app_descr, int app_tree_level, string cod_usuario, bool app_permission)
        {
            APP_CODE       = app_code;
            APP_NAME       = app_name;
            APP_DESCR      = app_descr;
            APP_TREE_LEVEL = app_tree_level;
            COD_USUARIO    = cod_usuario;
            APP_PERMISSION = app_permission;
        }

        public string app_CODE       { get => APP_CODE;       set => APP_CODE       = value; }
        public string app_NAME       { get => APP_NAME;       set => APP_NAME       = value; }
        public string app_DESCR      { get => APP_DESCR;      set => APP_DESCR      = value; }
        public int    app_TREE_LEVEL { get => APP_TREE_LEVEL; set => APP_TREE_LEVEL = value; }
        public string cod_USUARIO    { get => COD_USUARIO;    set => COD_USUARIO    = value; }
        public bool   app_PERMISSION { get => APP_PERMISSION; set => APP_PERMISSION = value; }
    }
}
