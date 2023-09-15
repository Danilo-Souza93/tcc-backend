namespace tcc.Models
{
    public class DadosPessoaisModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Cpf { get; set; }

        public DadosPessoaisModel() 
        { 
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Cpf = 0;
        }
    }
}
