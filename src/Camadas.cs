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
        public static void CriarCamadas(EnumCamadas camadas,string nomeProjeto, string versaoDotNet)
        {
            switch (camadas)
            {
                case EnumCamadas.API: CriarCamadaWebAPI(nomeProjeto,versaoDotNet);
                break;
                case EnumCamadas.DOMAIN: CriarCamadaDomain(nomeProjeto,versaoDotNet);
                break;
                case EnumCamadas.CORE: CriarCamadaCore(nomeProjeto,versaoDotNet);
                break;
                case EnumCamadas.DATA: CriarCamadaData(nomeProjeto,versaoDotNet);
                break;
                default: throw new Exception("Opção inválida");
            }
        }
        public static void ConfigurarCamadas(EnumCamadas camadas,string diretorio)
        {
            switch (camadas)
            {
                case EnumCamadas.API: ConfigurarCamadaAPI(diretorio);
                break;
                case EnumCamadas.DOMAIN: ConfigurarCamadaDOMAIN(diretorio);
                break;
                case EnumCamadas.CORE: ConfigurarCamadaCORE(diretorio);
                break;
                case EnumCamadas.DATA: ConfigurarCamadaDATA(diretorio);
                break;
                default: throw new Exception("Opção inválida");
            }
        }
        public static string InstalarPacotes(string versaoDotNet, string nomePacote)    
        {
            string comando = "";
            
            if (nomePacote.Contains("EntityFrameworkCore") && versaoDotNet.Contains("5.0"))
                comando = @$"dotnet add package {nomePacote} --version 5.0.17";
            else   
                comando = @$"dotnet add package {nomePacote}";

            return Util.ExecutaComandoCMD(comando);
        }
        private static void ConfigurarCamadaAPI(string diretorio)
        {
            Directory.CreateDirectory(@$"{diretorio}\Configurations");
            LogCriacaoCamada(@$"{diretorio}\Configurations");

            Directory.CreateDirectory(@$"{diretorio}\Middleware");
            LogCriacaoCamada(@$"{diretorio}\Middleware");
        }
        private static void ConfigurarCamadaDOMAIN(string diretorio)
        {
            Directory.CreateDirectory(@$"{diretorio}\Interfaces");
            LogCriacaoCamada(@$"{diretorio}\Interfaces");
            Directory.CreateDirectory(@$"{diretorio}\Services");
            LogCriacaoCamada(@$"{diretorio}\Services");
            Directory.CreateDirectory(@$"{diretorio}\Entities");
            LogCriacaoCamada(@$"{diretorio}\Entities");
            Directory.CreateDirectory(@$"{diretorio}\Pagination");
            LogCriacaoCamada(@$"{diretorio}\Pagination");
            Directory.CreateDirectory(@$"{diretorio}\DTOs");
            LogCriacaoCamada(@$"{diretorio}\DTOs");
            Directory.CreateDirectory(@$"{diretorio}\Token");
            LogCriacaoCamada(@$"{diretorio}\Token");
        }
        private static void ConfigurarCamadaCORE(string diretorio)
        {
            Directory.CreateDirectory(@$"{diretorio}\Manager");
            LogCriacaoCamada(@$"{diretorio}\Manager");
        }
        private static void ConfigurarCamadaDATA(string diretorio)
        {
            Directory.CreateDirectory(@$"{diretorio}\Repository");
            LogCriacaoCamada(@$"{diretorio}\Repository");
            Directory.CreateDirectory(@$"{diretorio}\Context");
            LogCriacaoCamada(@$"{diretorio}\Context");
            Directory.CreateDirectory(@$"{diretorio}\Mappings");
            LogCriacaoCamada(@$"{diretorio}\Mappings");
        }
        private static void LogCriacaoCamada(string diretorio)
        {
            if (Directory.Exists(@$"{diretorio}"))
                System.Console.WriteLine(@$"{diretorio} criado");
        }
        private static void CriarCamadaData(string nomeProjeto, string versaoDotNet)
        {
            string comando = @$"dotnet new classlib -n {nomeProjeto}.DATA -f {versaoDotNet}";
            Log(Util.ExecutaComandoCMD(comando));
        }  
        private static void CriarCamadaCore(string nomeProjeto, string versaoDotNet)
        {
            string comando = @$"dotnet new classlib -n {nomeProjeto}.CORE -f {versaoDotNet}";
            Log(Util.ExecutaComandoCMD(comando));
        } 
        private static void CriarCamadaDomain(string nomeProjeto, string versaoDotNet)
        {
            string comando = @$"dotnet new classlib -n {nomeProjeto}.DOMAIN -f {versaoDotNet}";
            Log(Util.ExecutaComandoCMD(comando));
        } 
        private static void CriarCamadaWebAPI(string nomeProjeto,string versaoDotNet)
        {
            string comando = @$"dotnet new webapi -n {nomeProjeto}.API -f {versaoDotNet}";
            Log(Util.ExecutaComandoCMD(comando));
        }   
        private static void Log(string mensagem)
        {
            System.Console.WriteLine(mensagem);
        }
    }
}