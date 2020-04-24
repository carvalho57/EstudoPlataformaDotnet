using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace review.Collections {
    /*
        Caso deseje utilizar HashSet, Dictionary voce deve sobreescrever ou implementar 
        métodos de comparação por exeplo, se deseja usar o hashset<t> você tera de definir
        o metodo Equal de IEquatable<T> sobreescrever o método Equal e também o gethashcode()
        Porque para dois objetos serem considerados iguais eles devem resultar no mesmo hashcode

        O método GetHashCode deve refletir a lógica do Equal
        O que faz um objeto igual
        Se no caso for o Id pode utilizar a implementação do gethashcode do int

        Id.getHashCode() ou apenas retorne o id

        Caso seja a combinação de varias propriedades, gere o hash assim
        int hash = 13;
        hash = (hash * 7) + field1.GetHashCode();
        hash = (hash * 7) + field2.GetHashCode();
        ...
        return hash;

        Há vários tipos de coleções, deve se avaliar a necessidade de utilizar cada uma delas. Por 
        exemplo se eu preciso apenas iterar posso utilizar o IEnumerable<T>, caso precise de mais funcionalidade
        com Count, ou Add ou Remove posso utilizar o ICollection<T>, caso precise de mais funcionalidades
        como Insert, RemoveAT utilize IList<T> e assim por diante, se não pode ter repetição ISet<T> e todas as 
        classes que implementam como HashSet<T> e SortedSet<T>.


        The ISet<T> interface offers methods to create a union of multiple sets, an intersection of sets, or give information if one set is a super or subset of another.

    */
    public class Colecao {

        private class Car : IComparable<Car> {            
            public string Name { get; private set; }
            public double Value { get; private set; }
            public Car(string name, double value)
            {   
                Name = name;
                Value = value;
            }

            public int CompareTo([AllowNull] Car other)
            {
                if(this.Value > other.Value) {
                    return 1;
                } else if(this.Value == other.Value) {
                    return 0;
                }
                return -1;
            }
            public override string ToString() {
                return $"Name: {Name} Value: {Value}";
            }
        }
        public void Run() {
            OrderList();
        }
        private void UsingSimpleCollection() {
            var times = new List<string>();
            times.Add("Coritiba");
            times.Add("Atletico");
            times.Add("Paraná");
            Console.WriteLine("Times");
            foreach(var time in times) {
                Console.WriteLine(time);
            }
        }

        private void OrderList() {
            IList<Car> cars = new List<Car>() {
                new Car("Fiat Uno",30000),
                new Car("Ferrari",1000000),                
                new Car("Corsa",45000),
                new Car("Camaro",300000),
                
            };
            
            
            foreach(var car in cars) {
                Console.WriteLine(car);
            }
        }
    }
    
}