using Microsoft.AspNetCore.Mvc;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    /// <summary>
    /// IGeneradorToken, interface que expone los metodos de  GeneradorToekn
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public interface IGeneradorToken
    {
        /// <summary>
        /// GenerarToken, metodo que loguea al usuario
        /// </summary>
        /// <param name="login">Vista modelo para el logueo en la aplicacion</param>
        /// <returns>Json con el valor del token y claims</returns>
        /// /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        JsonResult GenerarToken(LoginViewModel login);
    }
}