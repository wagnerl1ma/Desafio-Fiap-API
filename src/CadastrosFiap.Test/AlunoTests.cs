using CadastrosFiap.Business.Models;

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
    }
}