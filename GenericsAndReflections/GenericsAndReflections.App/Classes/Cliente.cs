using System;

namespace GenericsAndReflections.App.Classes
{
    public class Cliente
    {
        public string Nome { get; set; }

        public void MostrarDados<T>()
        {
            Console.WriteLine("Dados OK");
            Console.WriteLine(typeof(T).Name);
        }
    }
}
