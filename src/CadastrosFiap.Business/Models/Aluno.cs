using SecureIdentity.Password;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CadastrosFiap.Business.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; } //todo: salvar como char no banco

        [NotMapped]
        [JsonIgnore]
        public bool? SenhaIsValid { get; set; }

        //todo: criar método para gerar senha forte para usar na AlunoValidation

        // var password = PasswordGenerator.Generate(25, true, false); //gerando senha forte
        // user.PasswordHash = PasswordHasher.Hash(password); // criptografando a senha para salvar no banco em Hash


        public bool? ValidarSenha()
        {
            string senha = Senha;

            if (senha.Length < 8 || senha.Length > 60)
            {
                SenhaIsValid = null;
                return null;
            }
                
             //valida se tem pelo menos 1 caractere especial   
            if(Regex.IsMatch(senha, "[^a-zA-Z0-9]"))
            {
                SenhaIsValid = true;
                return true;
            }
            else
            {
                SenhaIsValid = null;
                return null;
            }
        }
    }
}
