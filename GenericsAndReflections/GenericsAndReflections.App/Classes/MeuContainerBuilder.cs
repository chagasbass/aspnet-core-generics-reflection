using System;
using System.Collections.Generic;

namespace GenericsAndReflections.App.Classes
{
    public class MeuContainerBuilder
    {
        private readonly MeuContainer _meuContainer;
        private readonly Type _meuTipo;

        public MeuContainerBuilder(MeuContainer meuContainer, Type type)
        {
            _meuContainer = meuContainer;
            _meuTipo = type;
        }

        public MeuContainerBuilder Use<TDestination>()
        {
            return Use(typeof(TDestination));
        }

        public MeuContainerBuilder Use(Type destination)
        {
            _meuContainer._map.Add(_meuTipo,destination);
            return this;
        }

    }
}
