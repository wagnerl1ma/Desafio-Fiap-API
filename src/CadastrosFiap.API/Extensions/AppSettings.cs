﻿namespace CadastrosFiap.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }    // chave de criptografia
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }   // Aplicação 
        public string ValidoEm { get; set; }  // em qual url o Token é válido
    }
}
