using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace code.Collection.Content {
    /*
        Armazena dados em sequência
    */
    public class Lista {
        public void Run() {
            //ComparandoObjetosNumaLista();
            OrdenandoListas();
        }

        private void ListOperation() {
            var list = new List<string>();
            list.Add("Gabriel");
            list.Add("Guilherme");
            list.AddRange(new string[]{"Jóse","Maria"});
            list.Insert(1,"Julio");

            foreach(var item in list) {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("Informe um nome: ");
            var nome = Console.ReadLine();
            
            var exist = list.Contains(nome);

            Console.WriteLine($"O nome {nome} existe: {exist}");

        }

        private void LinkedListOperation() {
            LinkedList<string> meses = new LinkedList<string>();
            meses.AddLast("Janeiro");
            meses.AddLast("Fevereiro");
            meses.AddLast("Março");

            foreach(var mes in meses) {
                Console.WriteLine(mes);
            }

            LinkedListNode<string> node = meses.First;
            
            while(node.Next != null) {                
                node = node.Next;
                Console.WriteLine(node.Value);
            }


        }
        
        private void ComparandoObjetosNumaLista() {
            int value1 = 1;
            int value2 = 1;
            Console.WriteLine(value1.Equals(value2));

            var aluno1 = new Aluno("Pedro");
            var aluno2 = new Aluno("Pedro");
            Console.WriteLine(aluno1.Equals(aluno2));
        }

        private void OrdenandoListas() {
            var tarefas = new List<Tarefa> {
                new Tarefa("Lavar louça",Tarefa.Nivel.BAIXA),
                new Tarefa("Limpar chão",Tarefa.Nivel.MEDIA),
                new Tarefa("Fazer compras",Tarefa.Nivel.MEDIA),
                new Tarefa("Lavar roupa",Tarefa.Nivel.ALTA),
                new Tarefa("Varrer calçada",Tarefa.Nivel.BAIXA)
            };

            tarefas.Sort();

            foreach(var tarefa in tarefas) {
                Console.WriteLine(tarefa);
            }
        }
    }
    public class Tarefa : IComparable<Tarefa>{
        public enum Nivel {
            ALTA = 10,
            MEDIA = 5,
            BAIXA = 0
        }
        public Tarefa(string descricao, Nivel prioridade) {
            Descricao = descricao;
            Prioridade = prioridade;
        }
        public string Descricao {get;set;}
        public Nivel Prioridade {get;set;}

        public override string ToString() {
            return string.Format("{0} ({1})", Descricao,Prioridade);
        }

        public int CompareTo(Tarefa other)
        {
            //Enum implementa a interface icomparable
            int c = this.Prioridade.CompareTo(other.Prioridade);

            if(c == 0) {
                return this.Descricao.CompareTo(other.Descricao);
            }
            return -c;
        }
    }

    public class Aluno : IEquatable<Aluno> {
        public string Nome { get; set; }
        public Aluno(string nome) {
            Nome = nome;
        }

        public override bool Equals(object obj) {
            return Equals(obj as Aluno);
        }

        public bool Equals(Aluno other)
        {   if(other == null) {
                return false;
            }
            return this.Nome.Equals(other.Nome);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nome);
        }
    }
}
