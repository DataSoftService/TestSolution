using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestSolution.UI.Web.Controllers
{
    public class BaseController :Controller
    {
        public void Notifications(string msj, NotificationTypes tipo, string titulo = "")
        {
            if (msj != "")
            {
                string icono = tipo.ToString().ToLower();
                char com = '"';
                //TempData["notificacion"] = $"Swal.fire('{titulo}','{msj}','{icono}')";

                TempData["notificacion"] = "Swal.fire({ icon: " + com + icono + com + ", title: " + com + titulo + com + ", text: " + com + msj + com + ", confirmButtonText: " + com + "Entendido <i class='las la-thumbs-up'></i>" + com + ", confirmButtonColor: " + com + "#6e7d88" + com + " }) ";
            }

        }

        public enum NotificationTypes
        {
            Success,
            Error,
            Info,
            warning
        }
    }
}
