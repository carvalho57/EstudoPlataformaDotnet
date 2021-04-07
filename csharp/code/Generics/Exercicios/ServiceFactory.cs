using System;

namespace code.Generics.Exercicios {
    public class ServiceFactory<T> where T : IService, new() {
        public T NewInstance() {            
            return new T();
        }
    }
}