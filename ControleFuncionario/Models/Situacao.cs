namespace ControleFuncionario.Models
{
    public class Situacao
    {
        public int SituacaoId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Frequencia> Frequencia { get; set; }
    }
}
