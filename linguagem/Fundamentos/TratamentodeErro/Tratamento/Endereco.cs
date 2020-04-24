namespace Tratamento {

    public class Endereco {
        public int EnderecoID { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco(string rua, string bairro, string cidade, string estado){
            Rua  = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }    
    }
}