using System;

namespace GenericsAndReflections.App.Fabricas
{
    public static class FabricaDeObjetos
    {
        public static object RetornarObjeto(Type tipoColecao,Type tipoObjeto)
        {
            var tipoFechado = tipoColecao.MakeGenericType(tipoObjeto);

            return Activator.CreateInstance(tipoFechado);
        }
    }
}
