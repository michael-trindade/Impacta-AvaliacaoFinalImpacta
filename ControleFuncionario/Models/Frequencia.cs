using System.ComponentModel.DataAnnotations;

namespace ControleFuncionario.Models
{
    public class Frequencia
    {
        public int FrequenciaId { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int SituacaoId { get; set; }
        public Situacao Situacao { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }                
    }
}
