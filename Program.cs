using System;
using System.IO;
using Template_Projetos_Padrao3Camadas.src;

namespace Template_Projetos_Padrao3Camadas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplicação para criação de templates de projeto.");

            System.Console.WriteLine("Informe o nome do projeto:");
            string nomeProjeto = Console.ReadLine();

            Console.WriteLine("Informe o diretório do projeto.");
            string diretorio = Console.ReadLine();

            System.Console.WriteLine("Informe a versão do DotNet:");
            System.Console.WriteLine("5 - DotNet 5");
            System.Console.WriteLine("6 - DotNet 6");
            string versaoDotNet = Util.ObterVersaoDotNet(Convert.ToInt32(Console.ReadLine()));

            if(string.IsNullOrEmpty(versaoDotNet))
                return;

            string diretorioProjeto = diretorio+"\\"+nomeProjeto;

            if(!Directory.Exists(diretorioProjeto))
                Directory.CreateDirectory(diretorioProjeto);

            var retorno = Camadas.CriarCamadaWebAPI(nomeProjeto,versaoDotNet);
            System.Console.WriteLine(retorno);
            
            retorno = Camadas.CriarCamadaDomain(nomeProjeto,versaoDotNet);
            System.Console.WriteLine(retorno);
            
            retorno = Camadas.CriarCamadaData(nomeProjeto,versaoDotNet);
            System.Console.WriteLine(retorno);

            System.Console.WriteLine("Vamos seguir para instalação dos pacotes.");            
            InstalarPacotes(versaoDotNet,"Camada WebAPI");
            InstalarPacotes(versaoDotNet,"Camada Domain");
            InstalarPacotes(versaoDotNet,"Camada Data");
        }
        private static void InstalarPacotes(string versaoDotNet,string camada)
        {
            while (true)
            {
                System.Console.WriteLine(camada+"\n");
                System.Console.WriteLine("1 - AutoMapper");
                System.Console.WriteLine("2 - AutoMapper.Extensions.Microsoft.DependencyInjection");
                System.Console.WriteLine("3 - FluentValidation ");
                System.Console.WriteLine("4 - Microsoft.EntityFrameworkCore ");
                System.Console.WriteLine("5 - Microsoft.EntityFrameworkCore.Design ");
                System.Console.WriteLine("6 - Microsoft.EntityFrameworkCore.SqlServer ");
                System.Console.WriteLine("7 - NLog  ");
                System.Console.WriteLine("8 - NLog.Web.AspNetCore ");
                System.Console.WriteLine("9 - Dapper  ");
                System.Console.WriteLine("0 - Sair");
                
                var opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1: 
                        Camadas.InstalarPacotes(versaoDotNet,"AutoMapper");
                        break;
                    case 2: 
                        Camadas.InstalarPacotes(versaoDotNet,"AutoMapper.Extensions.Microsoft.DependencyInjection");
                        break;
                    case 3: 
                        Camadas.InstalarPacotes(versaoDotNet,"FluentValidation");
                        break;
                    case 4: 
                        Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore");
                        break;
                    case 5: 
                        Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.Design");
                        break;
                    case 6: 
                        Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.SqlServer");
                        break;
                    case 7: 
                        Camadas.InstalarPacotes(versaoDotNet,"NLog");
                        break;
                    case 8: 
                        Camadas.InstalarPacotes(versaoDotNet,"NLog.Web.AspNetCore");
                        break;
                    case 9: 
                        Camadas.InstalarPacotes(versaoDotNet,"Dapper");
                        break;
                    case 0: return;                    
                    default: 
                    {
                        System.Console.WriteLine("Opção inválida.");
                        return;
                    }

                }
            }
        }
    }
}
