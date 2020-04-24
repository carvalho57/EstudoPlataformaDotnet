using System;
using Arrays.Exercicicios;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
          //OrdenandoProva();    
        }

        static void InicializandoArray() {
            var array = new int[2] {1,2};
            int[] array2 = {1,2};
            int[] array3 = new int[] {1,2,3};
            //Linha,Coluna
            int[,] arra = new int[2,3];
        }

        static void ClasseArray() {
            Array array = Array.CreateInstance(typeof(int),2,3);

            Console.WriteLine("Quantidade de Linhas  ",array.GetLength(0));
            Console.WriteLine("Quantidade de Colunas  ",array.GetLength(1));
            Console.WriteLine("Numeros de Dimensões",array.Rank);
        }
        /*A ordenação só pode ser feita se o criterio de ordenação for especificado
        Ou seja, se quiser ordenar tem que utilizar a interface IComparable para 
        indicar ao c# como deve ser feito*/
        static void OrdenandoElementos() {
            int[] array = {6,5,3,12,2,4};
            Array.Sort(array);            
            VarrereElementos(array);
            Array.Sort(array, new ComparadorDecrescente());
            VarrereElementos(array);
        }

        static void VarrereElementos(int[] array) {
            foreach(var item in array) {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
        }
        static void VarrereElementos(Prova[] array) {
            foreach(var item in array) {
                Console.WriteLine("{0,-12} -> {1,-1}",item.NomeAluno,item.Nota);
            }
            Console.WriteLine("\n");
        }

        static void OrdenandoProva() {
            var provasAluno = new Prova[] {
                new Prova("Diego",7.8),
                new Prova("Pedro",7.2),
                new Prova("Gabriel",5.8),
                new Prova("Guilherme",8.8),
                new Prova("Carlos",8.7)
            };

            //Array.Sort(provasAluno); utiliza o IComparable da classe Prova
             ComparerProva compare = new ComparerProva(); //utiliza o IComparer
             Array.Sort(provasAluno,compare);
            VarrereElementos(provasAluno);
        }

        
    }
}


