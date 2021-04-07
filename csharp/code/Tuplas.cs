using System;

namespace code
{
    public class LukeSkywalker : DarthVaider
    {
        public LukeSkywalker(string power)
        {
            Power = power;
            Name = "Luke Skywalker";
        }
        public string Power { get; private set; }
        public string Name { get; private set; }

        public void Deconstruct(out string power, out string name)
        {
            power = Power;
            name = Name;
        }
        public override void Say()
        {
            Console.WriteLine("NOOOOOOOOOOOOOOOOOO");
        }
    }

    public class DarthVaider
    {
        public virtual void Say()
        {
            Console.WriteLine("I AM Your Father");
        }
    }
    public  class Tuplas
    {
        public static void Run()
        {
            var luke = new LukeSkywalker("Forca");
            var (power, name) = luke;
            Console.WriteLine($"Power: {power}, Name: {name}");
            // string nome3;
            // int idade;
            // double valor;
            var (nome3,idade,valor) = QueryData();
            Console.WriteLine($"Nome: {nome3}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Valor: {valor}");

            var data = QueryData("Jose");
            Console.WriteLine($"Nome: {data.name}");
            Console.WriteLine($"Idade: {data.idade}");
        }

        public static (string, int, double) QueryData()
        {
            return ("Name", 10, 33.3);
        }
        public static (string name, int idade) QueryData(string name)
        {
            if(!string.IsNullOrEmpty(name))
                return ("Jose", 18);
            return (name, 0);
        }

        public static (string name, int idade) Methodx()
        {
            return ("Jose", 123);
        }

        public void ReturningAnonymousType()
        {
            var anonimo = new {name = "Jose", idade = 123};

            Console.WriteLine($"Nome: {anonimo.name} Idade: {anonimo.idade}");
        }
    }
}