using CadastrosFiap.Business.Models;
using SecureIdentity.Password;

namespace CadastrosFiap.Test
{
    public class AlunoTests
    {
        [Fact]
        public void Aluno_ValidarSenha_RetornarTrueCasoSenhaForValidada()
        {
            //Arrange
            var aluno = new Aluno();
            //aluno.Senha = "1234abcddadasda@"; // Senha maior que 8 caracteres --> False
            //aluno.Senha = "1234@"; // Senha menor que 8 caracteres --> False
            //aluno.Senha = "1234abcd"; // Senha somente com 8 caracteres --> False
            aluno.Senha = "1234567@"; // Senha com 8 caracteres e pelo menos 1 caracter especial --> True

            //Act
            var resultado = aluno.ValidarSenha();

            //Assert
            Assert.True(resultado);

        }

        [Fact]
        public void Aluno_GerarSenhaHash_RetornarTrueCasoSenhaForValidada()
        {
            //Arrange
            var aluno = new Aluno();
            aluno.Senha = "1234567@";

            //Act
            var passwordHash = PasswordHasher.Hash(aluno.Senha, 5, 10);

            //Assert
            Assert.True(passwordHash?.Length >= 8 && passwordHash.Length < 61);
        }
    }
}