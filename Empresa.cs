using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDeCNPJ
{
    public class Empresa
    {
        public string Status { get; set; }

        //razao social
        public string nome { get; set; }

        //nome fantasia
        public string fantasia { get; set; }

        public string cnpj { get; set; }

        public string logradouro { get; set; }

        public string numero { get; set; }

        public string complemento { get; set; }

        public string bairro { get; set; }

        public string municipio { get; set; }

        public string uf { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string optante { get; set; }
        public List<AtividadePrincipal> atividade_principal {get; set;}

    }

    public class AtividadePrincipal
    {
        public string code { get; set; }

        //descrição atividade principal
        public string text { get; set; }
    }
}
