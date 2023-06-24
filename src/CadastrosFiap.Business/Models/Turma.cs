
namespace CadastrosFiap.Business.Models
{
    public class Turma : Entity
    {
        public int IdCurso { get; set; }  //= CursosEnum.ArquiteturaDeSistemasDotNetComAzure.GetHashCode();
        public string NomeTurma { get; set; }
        public int Ano { get; set; }
    }
}
