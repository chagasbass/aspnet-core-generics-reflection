using GenericsAndReflections.App.Classes;
using GenericsAndReflections.App.Fabricas;
using System;
using System.Collections.Generic;

namespace GenericsAndReflections.App
{
    class Program
    {
        static void Main(string[] args)
        {
            #region invocando um tipo T passando o tipo de objeto
            var colecao = typeof(List<>);
            var tipo = typeof(Produto);
            var objeto = FabricaDeObjetos.RetornarObjeto(colecao,tipo);
            Console.WriteLine(objeto.GetType().FullName);
            #endregion

            #region recuperando um metodo generico e passando o tipo para ser invocado
            var cliente = new Cliente();
            var clienteTipo = typeof(Cliente);
            var metodoInfo = clienteTipo.GetMethod("MostrarDados");
            metodoInfo = metodoInfo.MakeGenericMethod(typeof(string));
            metodoInfo.Invoke(cliente, null);
            #endregion

            var teste = "Cliente";
            var _cliente = teste.ChangeType<Cliente>();

            Console.ReadKey();
        }
    }
}
