using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsAndReflections.App.Classes
{
    public class MeuContainer
    {
        public Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public MeuContainerBuilder For<TSource>()
        {
            return For(typeof(TSource));
        }

        public MeuContainerBuilder For(Type source)
        {
            return new MeuContainerBuilder(this, source);
        }

        public object Resolve<TSource>()
        {
            return (TSource)Resolve(typeof(TSource));
        }

        public object Resolve(Type type)
        {
            if (_map.ContainsKey(type))
            {
                var destinationType = _map[type];
                return CreateInstance(destinationType);
            }
            else if(type.IsGenericType && _map.ContainsKey(type.GetGenericTypeDefinition()))
            {
                var destination = _map[type.GetGenericTypeDefinition()];
                var closedType = destination.MakeGenericType(type.GetGenericArguments());
                return CreateInstance(closedType);
            }
            else if(!type.IsAbstract)
            {
                return CreateInstance(type);
            }
            else
            {
                throw new InvalidCastException("Erro");
            }
        }

        /// <summary>
        /// Recuperar os  construtores de um tipo informado
        /// e pega o 1 e seus parametros
        /// </summary>
        /// <param name="destinationType"></param>
        /// <returns>retorna a criacao de uma instancia passando seu tipo e seu parametros do construtor</returns>
        private object CreateInstance(Type destinationType)
        {

            var paramters = destinationType.GetConstructors()
                                   .OrderByDescending(c => c.GetParameters().Count())
                                   .First()
                                   .GetParameters()
                                   .Select(p => Resolve(p.ParameterType))
                                   .ToArray();

            return Activator.CreateInstance(destinationType, paramters);
        }
    }
}
