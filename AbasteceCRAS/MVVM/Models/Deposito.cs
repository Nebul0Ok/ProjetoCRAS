namespace AbasteceCRAS.MVVM.Models
{
    public class Deposito
    {
        public int ID { get; set; }
        public int IdSala { get; set; }

        public string Nome { get; set; }
        public string Localizacao { get; set; }

        public Deposito(string Nome, string Localizacao)
        {
            this.Nome = Nome;
            this.Localizacao = Localizacao;
        }
    }
}