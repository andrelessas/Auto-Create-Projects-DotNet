using System;
using System.IO;
using Auto_Create_Projects_DotNet.src;
using Auto_Create_Projects_DotNet.src.Enums;

namespace Auto_Create_Projects_DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Autor:  André Lessas");
            Console.WriteLine("-------------------Criador de projetos.-------------------");

            System.Console.Write("Informe o nome do projeto: ");
            string nomeProjeto = Console.ReadLine();

            Console.Write("Informe o diretório do projeto: ");
            string diretorio = Console.ReadLine();
            
            string versaoDotNet = "net6.0"; 
            string diretorioProjeto = diretorio+"\\"+nomeProjeto;

            string diretorioProjetoAtual = Directory.GetCurrentDirectory();

            // diretorioProjetoAtual = diretorioProjetoAtual+"\\src";  //testes
            
            if(!Directory.Exists(diretorioProjeto))
                Directory.CreateDirectory(diretorioProjeto);
            
            Directory.SetCurrentDirectory(diretorioProjeto);
            
            System.Console.WriteLine(Camadas.CriarCamadas(EnumCamadas.API,nomeProjeto,versaoDotNet));
            System.Console.WriteLine(Camadas.CriarCamadas(EnumCamadas.Business,nomeProjeto,versaoDotNet));
            System.Console.WriteLine(Camadas.CriarCamadas(EnumCamadas.Data,nomeProjeto,versaoDotNet));
            System.Console.WriteLine(Camadas.CriarCamadas(EnumCamadas.Tests,nomeProjeto,versaoDotNet));

            var diretorioAPI = @$"{diretorioProjeto}\{nomeProjeto}.API";
            var diretorioBusiness = @$"{diretorioProjeto}\{nomeProjeto}.Business";
            var diretorioDATA = @$"{diretorioProjeto}\{nomeProjeto}.Data";
            var diretorioTests = @$"{diretorioProjeto}\{nomeProjeto}.Tests";

            Camadas.ConfigurarCamadas(EnumCamadas.API,diretorioAPI);
            Camadas.ConfigurarCamadas(EnumCamadas.Business,diretorioBusiness);
            Camadas.ConfigurarCamadas(EnumCamadas.Data,diretorioDATA);

            System.Console.WriteLine("\n-------------------Instalação dos pacotes.-------------------\n");
            InstalarPacotes(versaoDotNet,"API",diretorioAPI,diretorioProjetoAtual);
            InstalarPacotes(versaoDotNet,"Bussiness",diretorioBusiness);
            InstalarPacotes(versaoDotNet,"Data",diretorioDATA);
            InstalarPacotes(versaoDotNet,"Tests",diretorioTests);

            Directory.SetCurrentDirectory(diretorioProjeto);
            Util.ExecutaComandoCMD("code .");
        }
        private static void InstalarPacotes(string versaoDotNet,string camada,string diretorio,string diretorioProjetoAtual = "")
        {   
            
            Directory.SetCurrentDirectory(diretorio);
            while (true)
            {
                System.Console.WriteLine($"\nSelecione os pacotes que serão instalados na camada: {camada}");
                System.Console.WriteLine("1 - AutoMapper");
                System.Console.WriteLine("2 - AutoMapper.Extensions.Microsoft.DependencyInjection");
                System.Console.WriteLine("3 - FluentValidation ");
                System.Console.WriteLine("4 - FluentValidation.AspNetCore");
                System.Console.WriteLine("5 - Microsoft.EntityFrameworkCore");
                System.Console.WriteLine("6 - Microsoft.EntityFrameworkCore.Design");
                System.Console.WriteLine("7 - Microsoft.EntityFrameworkCore.SqlServer");
                System.Console.WriteLine("8 - Microsoft.EntityFrameworkCore.Relational");
                System.Console.WriteLine("9 - Microsoft.EntityFrameworkCore.Tools");
                System.Console.WriteLine("10 - NLog");
                System.Console.WriteLine("11 - NLog.Web.AspNetCore");
                System.Console.WriteLine("12 - Dapper");
                System.Console.WriteLine("13 - Newtonsoft.Json");
                System.Console.WriteLine("14 - Bogus");
                System.Console.WriteLine("15 - FluentAssertions");
                System.Console.WriteLine("16 - XUnit");
                System.Console.WriteLine("17 - Mock");
                System.Console.WriteLine("18 - Auto Mock");
                System.Console.WriteLine("0 - Sair");
                
                System.Console.Write("\nInforme o pacote selecionado: ");
                var opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"AutoMapper"));                        
                        break;
                    case 2: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"AutoMapper.Extensions.Microsoft.DependencyInjection"));
                        break;
                    case 3: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"FluentValidation"));
                        break;
                    case 4: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"FluentValidation.AspNetCore"));
                        break;
                    case 5: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore"));
                        break;
                    case 6: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.Design"));
                        break;
                    case 7: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.SqlServer"));
                        break;
                    case 8: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.Relational"));
                        break;
                    case 9: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.Tools"));
                        break;
                    case 10: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"NLog"));
                        break;
                    case 11: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"NLog.Web.AspNetCore"));
                        if(!string.IsNullOrEmpty(diretorioProjetoAtual))
                            Camadas.ConfigurarNLog(diretorioProjetoAtual,Directory.GetCurrentDirectory());
                        break;
                    case 12: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Dapper"));
                        break;
                    case 13: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Newtonsoft.Json"));
                        break;
                    case 14: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Bogus"));
                        break;
                    case 15: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"FluentAssertions"));
                        break;
                    case 16: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"XUnit"));
                        break;
                    case 17: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"moq"));
                        break;
                    case 18: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Moq.AutoMock"));
                        break;
                    case 0: return;                    
                    default: throw new Exception("Opção inválida.");            
                }
            }
        }
    }
}
