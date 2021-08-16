using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Servicios_WCF.Security
{
    public class Auth : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("El usuario no puede ser nulo o vacio");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("El usuario no puede ser nulo o vacio");
            }
            //usuario: root password:gianfranco
            if (!(userName.ToLower().Equals("root") && password.ToLower().Equals("gianfranco")))
            {
                throw new FaultException("Usuario y Contraseña incorrecto");
            }
        }
    }
}