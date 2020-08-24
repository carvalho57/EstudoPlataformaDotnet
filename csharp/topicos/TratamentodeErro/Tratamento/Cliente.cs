namespace Tratamento {
    public class Cliente {
        public int ClienteId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente(string name, string email, Endereco endereco) {
            Name = name;
            Email = email;
            Endereco = endereco;
        }
    }
}