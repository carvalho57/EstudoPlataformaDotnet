using System;

namespace Polimorfismo.Concepts {

    public interface ICollecionavel
    {   
        string GetNomeColecao();
    }

    public class Selo : ICollecionavel
    {
        public string GetNomeColecao()
        {
            return "Selos";
        }
        
        public void Info(){
            
        }
    }

    public class Quadrinho : ICollecionavel
    {
        public string GetNomeColecao()
        {
            return "Quadrinhos";
        }
    }
}