namespace ControleFuncionario.Models
{
    public class Lotacao
    {
        public int LotacaoId { get; set; }
        public string LotacaoRegiao { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
