using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; } //todo: salvar como char no banco

        [JsonIgnore]
        public bool? SenhaIsValid { get; set; } = null;

        //todo: criar método para gerar senha forte para usar na AlunoValidation

        // var password = PasswordGenerator.Generate(25, true, false); //gerando senha forte
        // user.PasswordHash = PasswordHasher.Hash(password); // criptografando a senha para salvar no banco em Hash


        public bool ValidarSenha()
        {
            string senha = Senha;

            if (senha.Length != 8)
                return false;
                
            if(Regex.IsMatch(senha, "[^a-zA-Z0-9]"))
            {
                SenhaIsValid = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
