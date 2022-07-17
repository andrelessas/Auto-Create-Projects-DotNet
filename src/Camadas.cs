using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Auto_Create_Projects_DotNet.src.Enums;

namespace Auto_Create_Projects_DotNet.src
{
    public static class Camadas
    {
        public static string CriarCamadas(EnumCamadas camadas,string nomeProjeto, string versaoDotNet)
        {
            switch (camadas)
            {
                case EnumCamadas.API: return CriarCamada(@$"dotnet new webapi -n {nomeProjeto}.API -f {versaoDotNet}");
                case EnumCamadas.Business: return CriarCamada(@$"dotnet new classlib -n {nomeProjeto}.Business -f {versaoDotNet}");
                case EnumCamadas.Data: return CriarCamada(@$"dotnet new classlib -n {nomeProjeto}.Data -f {versaoDotNet}");
                case EnumCamadas.Tests: return CriarCamada(@$"dotnet new classlib -n {nomeProjeto}.Tests -f {versaoDotNet}");
                default: throw new Exception("Opção inválida");
            }
        }
        public static void ConfigurarCamadas(EnumCamadas camadas,string diretorio)
        {
            switch (camadas)
            {
                case EnumCamadas.API: ConfigurarCamadaAPI(diretorio);
                break;
                case EnumCamadas.Business: ConfigurarCamadaBusiness(diretorio);
                break;                
                case EnumCamadas.Data: ConfigurarCamadaData(diretorio);
                break;            
                default: throw new Exception("Opção inválida");
            }
        }
        public static string InstalarPacotes(string versaoDotNet, string nomePacote)    
        {
            return Util.ExecutaComandoCMD(@$"dotnet add package {nomePacote}");
        }
        public static void ConfigurarNLog(string origem,string destino)
        {
            if(!File.Exists(origem+"\\ArquivosUteis\\Nlog.config"))
                {        
                    System.Console.WriteLine(origem+"\\ArquivosUteis");            
                    System.Console.WriteLine("\nArquivo NLog.config não encontrado.\nDeseja continuar?(s - Sim / n - Não)");
                    if(Console.ReadLine() == "n") 
                        throw new Exception("Aplicação finalizada.");
                }
            else
                origem = origem+"\\ArquivosUteis";
                
            var localOrigem = Path.Combine(origem,"Nlog.config");
            var localDestino = Path.Combine(destino,"Nlog.config");
            File.Copy(localOrigem,localDestino,true);
        }
        private static void ConfigurarCamadaAPI(string diretorio)
        {
            Directory.CreateDirectory(@$"{diretorio}\Configurations");
            LogCriacaoCamada(@$"{diretorio}\Configurations");

            Directory.CreateDirectory(@$"{diretorio}\Middleware");
            LogCriacaoCamada(@$"{diretorio}\Middleware");
        }
        private static void ConfigurarCamadaBusiness(string diretorio)
        {
            Directory.CreateDirectory(@$"{diretorio}\Interfaces");
            LogCriacaoCamada(@$"{diretorio}\Interfaces");
            Directory.CreateDirectory(@$"{diretorio}\Services");
            LogCriacaoCamada(@$"{diretorio}\Services");
            Directory.CreateDirectory(@$"{diretorio}\Models");
            LogCriacaoCamada(@$"{diretorio}\Models");
            Directory.CreateDirectory(@$"{diretorio}\Models\Validations");
            LogCriacaoCamada(@$"{diretorio}\Models\Validations");
            Directory.CreateDirectory(@$"{diretorio}\Pagination");
            LogCriacaoCamada(@$"{diretorio}\Pagination");
            Directory.CreateDirectory(@$"{diretorio}\Notificacoes");
            LogCriacaoCamada(@$"{diretorio}\Notificacoes");
            Directory.CreateDirectory(@$"{diretorio}\DTOs");
            LogCriacaoCamada(@$"{diretorio}\DTOs");
            Directory.CreateDirectory(@$"{diretorio}\Manager");
            LogCriacaoCamada(@$"{diretorio}\Manager");
            Directory.CreateDirectory(@$"{diretorio}\Token");
            LogCriacaoCamada(@$"{diretorio}\Token");
        }        
        private static void ConfigurarCamadaData(string diretorio)
        {
            Directory.CreateDirectory(@$"{diretorio}\Repository");
            LogCriacaoCamada(@$"{diretorio}\Repository");
            Directory.CreateDirectory(@$"{diretorio}\Context");
            LogCriacaoCamada(@$"{diretorio}\Context");
            Directory.CreateDirectory(@$"{diretorio}\Mappings");
            LogCriacaoCamada(@$"{diretorio}\Mappings");
            Directory.CreateDirectory(@$"{diretorio}\Migrations");
            LogCriacaoCamada(@$"{diretorio}\Migrations");
        }
        private static void LogCriacaoCamada(string diretorio)
        {
            if (Directory.Exists(@$"{diretorio}"))
                System.Console.WriteLine(@$"{diretorio} criado");
        }
        private static string CriarCamada(string comando)
        {
            return Util.ExecutaComandoCMD(comando);
        }          
        private static void Log(string mensagem)
        {
            System.Console.WriteLine(mensagem);
        }
    }
}