using System;
using Tratamento.Exceptions;

namespace Tratamento
{
    /*

    */
    class Program
    {
        static void Main(string[] args)
        {
            try{
                UsingTryCatch();
            }catch(Exception e){
                Console.WriteLine("O main controla tudo",e.Message);
            }
            finally {
                Console.WriteLine("Inner Exception \n\n");                
            }
            InnerException();
        }

        static void InnerException() {
            Calculator calculator = new Calculator();
            double result = calculator.Dividir(10,0);
            Console.WriteLine(result);
        }

        static void UsingTryCatch() {
            try {
                Endereco endereco = new Endereco("24 de maio","Centro","Curitiba","Paraná");
                Cliente cliente = new Cliente("Gabriel","gabriel@outlook.com",endereco);
                CadastrarCliente(cliente);
            }
            catch(NullReferenceException e) {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
            }
            catch(Exception e) {
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Source: {e.Source}");
                Console.WriteLine($"InnerException: {e.InnerException}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
            }finally {
                Console.WriteLine("Fim do bloco try");
                Console.WriteLine("Sempre sou chamado HE-HEHE");
            }
        }
        static void CadastrarCliente(Cliente cliente) {
            
           
            if(cliente.Endereco.Equals(null)) {
                throw new NullReferenceException("A propriedade Endereço não pode ser nula");
            }
           
            Console.WriteLine("Cliente cadastrado com sucesso");
        }
    }
}
