using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario_de_Funcionarios
{
    class Funcionario
    {
        public string nome, idade, sexo, tipoSanguineo, estadoCivil, pais, estado, cidade, bairro, rua, complemento, cargo, email, filhos, telefone, salario;

        public string toTxt() {
            return nome + "#" + idade + "#" + sexo + "#" + tipoSanguineo + "#" + estadoCivil + "#" + pais + "#" + estado + "#" + cidade + "#" + bairro + "#" + rua + "#" + complemento + "#" + cargo + "#" + email + "#" + filhos + "#" + telefone + "#" + salario;
        }
    }
}
