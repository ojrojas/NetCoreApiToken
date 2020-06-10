namespace RappiApi.Querys
{
    public static class UtilQueryPaginacion
    {
        public static int ObtenerPasoPaginacion(int pagina, int tamanoResultado)
        {
            return (pagina -1) * tamanoResultado;
        }
    }
}