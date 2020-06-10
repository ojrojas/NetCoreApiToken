using Microsoft.AspNetCore.Mvc;
using RappiApi.Models.ViewModels;

namespace RappiApi.Services.Interfaces
{
    public interface IGeneradorToken
    {
        JsonResult GenerarToken(LoginViewModel login);
    }
}