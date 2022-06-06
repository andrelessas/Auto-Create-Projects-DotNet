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

            System.Console.WriteLine("Informe a versão do DotNet:");
            System.Console.WriteLine("5 - DotNet 5");
            System.Console.WriteLine("6 - DotNet 6");
            string versaoDotNet = Util.ObterVersaoDotNet(Convert.ToInt32(Console.ReadLine()));

            string diretorioProjeto = diretorio+"\\"+nomeProjeto;

            if(!Directory.Exists(diretorioProjeto))
                Directory.CreateDirectory(diretorioProjeto);
            
            Directory.SetCurrentDirectory(diretorioProjeto);
            
            Camadas.CriarCamadas(EnumCamadas.API,nomeProjeto,versaoDotNet);
            Camadas.CriarCamadas(EnumCamadas.CORE,nomeProjeto,versaoDotNet);                        
            Camadas.CriarCamadas(EnumCamadas.DOMAIN,nomeProjeto,versaoDotNet);
            Camadas.CriarCamadas(EnumCamadas.DATA,nomeProjeto,versaoDotNet);

            var diretorioAPI = @$"{diretorioProjeto}\{nomeProjeto}.API";
            var diretorioDOMAIN = @$"{diretorioProjeto}\{nomeProjeto}.DOMAIN";
            var diretorioDATA = @$"{diretorioProjeto}\{nomeProjeto}.DATA";
            var diretorioCORE = @$"{diretorioProjeto}\{nomeProjeto}.CORE";

            Camadas.ConfigurarCamadas(EnumCamadas.API,diretorioAPI);
            Camadas.ConfigurarCamadas(EnumCamadas.DOMAIN,diretorioDOMAIN);
            Camadas.ConfigurarCamadas(EnumCamadas.CORE,diretorioCORE);
            Camadas.ConfigurarCamadas(EnumCamadas.DATA,diretorioDATA);

            System.Console.WriteLine("\n-------------------Instalação dos pacotes.-------------------\n");
            InstalarPacotes(versaoDotNet,"API",diretorioAPI);
            InstalarPacotes(versaoDotNet,"DOMAIN",diretorioDOMAIN);
            InstalarPacotes(versaoDotNet,"CORE",diretorioCORE);
            InstalarPacotes(versaoDotNet,"DATA",diretorioDATA);

            Directory.SetCurrentDirectory(diretorioProjeto);
            Util.ExecutaComandoCMD("code .");
            // System.Console.WriteLine("Projeto criado com sucesso. \nPressione qualquer tecla para fechar a aplicação.");
            // Console.ReadKey();
        }
        private static void InstalarPacotes(string versaoDotNet,string camada,string diretorio)
        {
            Directory.SetCurrentDirectory(diretorio);
            while (true)
            {
                System.Console.WriteLine($"\nSelecione os pacotes que serão instalados na camada: {camada}");
                System.Console.WriteLine("1 - AutoMapper");
                System.Console.WriteLine("2 - AutoMapper.Extensions.Microsoft.DependencyInjection");
                System.Console.WriteLine("3 - FluentValidation ");
                System.Console.WriteLine("4 - Microsoft.EntityFrameworkCore ");
                System.Console.WriteLine("5 - Microsoft.EntityFrameworkCore.Design ");
                System.Console.WriteLine("6 - Microsoft.EntityFrameworkCore.SqlServer ");
                System.Console.WriteLine("7 - NLog");
                System.Console.WriteLine("8 - NLog.Web.AspNetCore");
                System.Console.WriteLine("9 - Dapper");
                System.Console.WriteLine("10 - FluentValidation.AspNetCore");
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
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore"));
                        break;
                    case 5: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.Design"));
                        break;
                    case 6: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Microsoft.EntityFrameworkCore.SqlServer"));
                        break;
                    case 7: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"NLog"));
                        break;
                    case 8: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"NLog.Web.AspNetCore"));
                        break;
                    case 9: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"Dapper"));
                        break;
                    case 10: 
                        System.Console.WriteLine(Camadas.InstalarPacotes(versaoDotNet,"FluentValidation.AspNetCore"));
                        break;
                    case 0: return;                    
                    default: throw new Exception("Opção inválida.");            
                }
            }
        }
    }
}
