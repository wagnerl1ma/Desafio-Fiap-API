using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public char Senha { get; set; }
    }
}
