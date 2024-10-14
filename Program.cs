using HtmlAgilityPack;
using System;
using System.Data;
using System.Linq;
using ConsultaDeCNPJ;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {

        try
        {

            //OBTEM LISTA DE CNPJ DO ENDEREÇO SELECIONADO 

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.fazenda.sp.gov.br/pac/ConsultaEmpresasHabilitadas/PADConsultaEmpresasHabilitadas.aspx");

            var table = doc.DocumentNode.SelectSingleNode("//table[@id='ctl00_ConteudoAplicacao_gdvPatrocinadores']");

            List<Empresa> _empresas = new List<Empresa>();


            if (table != null)
            {
                foreach (var row in table.SelectNodes(".//tr"))
                {
                    var cells = row.SelectNodes(".//td");
                    if (cells != null)
                    {
                        var empresa = new Empresa
                        {
                            //nome = cells[0].InnerText.Trim(), // Pega o texto da primeira coluna
                            cnpj = cells[1].InnerText.Trim() // Pega o texto da segunda coluna
                        };
                        _empresas.Add(empresa);                  
                    }
                }

                foreach(var item in _empresas)
                {
                    //Console.WriteLine($"{item.nome} ; {item.cnpj}");

                    var resultadoConsulta = ConsultaCNPJ.ObterCnpj(item.cnpj);

                    string status = resultadoConsulta.Status;
                    string nome = resultadoConsulta.nome;
                    string fantasia = resultadoConsulta.fantasia;
                    string cnpj = resultadoConsulta.cnpj;
                    string logradouro = resultadoConsulta.logradouro;
                    string numero = resultadoConsulta.numero;
                    string complemento = resultadoConsulta.complemento;
                    string bairro = resultadoConsulta.bairro;
                    string municipio = resultadoConsulta.municipio;
                    string uf = resultadoConsulta.uf;
                    string email = resultadoConsulta.email;
                    string telefone = resultadoConsulta.telefone;
                    string optante = resultadoConsulta.optante;

                    //Necessário fazer um looping novamente

                    Console.WriteLine($"\n Razão Social: {nome} \n Nome Fantasia: {fantasia} \n CNPJ: {cnpj} \n Logradouro: {logradouro} \n Numero: {numero} \n Complemento: {complemento} \n Bairro: {bairro} \n Municipio: {municipio} \n UF: {uf} \n E-mail: {email} \n Telefone: {telefone}");

                }

            }
            else
            {
                Console.WriteLine("Tabela não encontrada.");
            }

            Console.ReadLine();


            //CODIGO PARA RODAR A REQUISIÇÃO NA PESQUIISA DA RECEITA FED. 57339566000160
            //Necessario fazer um looping para rodar a cada CPNJ pesquisado, a partir de uma lsita 
            //Pensar em um jeito de conseguir fazer a transformação do cnpj pesquisado e atribuir os valores a uma lista de EMPRESAS

          
        }
        catch (Exception)
        {

            throw;
        }
        


        
    }
}
