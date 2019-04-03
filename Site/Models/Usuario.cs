using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Site.Models
{
    public static class SessionContext
    {
        //Aqui não da para usar o TempData o que não é legal
        /// <summary>
        /// Usuário logado na aplicação.
        /// </summary>
        public static string Login
        {
            get
            {
                return (string)HttpContext.Current.Session["Usuario"];
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = (string)value;
            }
        }

        public static string IsAutenticado
        {
            get
            {
                return (string)HttpContext.Current.Session["isAutenticado"];
            }
            set
            {
                HttpContext.Current.Session["isAutenticado"] = (string)value;
            }
        }
    }

    
}