using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template_Projetos_Padrao3Camadas.src
{
    public static class Camadas
    {
        public static string CriarCamadaData(string nomeProjeto, string versaoDotNet)
        {
            string comando = @$"dotnet new classlib -n {nomeProjeto}.Data -f {versaoDotNet}";
            return Util.ExecutaComandoCMD(comando);
        }  
        public static string CriarCamadaDomain(string nomeProjeto, string versaoDotNet)
        {
            string comando = @$"dotnet new classlib -n {nomeProjeto}.Domain -f {versaoDotNet}";
            return Util.ExecutaComandoCMD(comando);
        } 
        public static string CriarCamadaWebAPI(string nomeProjeto,string versaoDotNet)
        {
            string comando = @$"dotnet new webapi -n {nomeProjeto}.API -f {versaoDotNet}";
            return Util.ExecutaComandoCMD(comando);
        }   
        public static void InstalarPacotes(string versaoDotNet, string nomePacote)    
        {
            string comando = "";
            
            if (nomePacote.Contains("EntityFrameworkCore") && versaoDotNet.Contains("5.0"))
                comando = @$"dotnet add package {nomePacote} --version 5.0.17";
            else   
                comando = @$"dotnet add package {nomePacote}";

            Util.ExecutaComandoCMD(comando);
        }
    }
}