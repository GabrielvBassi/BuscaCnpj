using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;


namespace ConsultaDeCNPJ
{
    public class ConsultaCNPJ
    {
        public static Empresa ObterCnpj(string cnpj)
        {
            string url = "https://receitaws.com.br/v1/cnpj/" + cnpj;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);

            var empresa = JsonConvert.DeserializeObject<Empresa>(json);

            return empresa;
        }
    }
}
