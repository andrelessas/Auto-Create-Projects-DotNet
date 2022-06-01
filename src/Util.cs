using System;
using System.Diagnostics;

namespace Template_Projetos_Padrao3Camadas.src
{
    public static class Util
    {
        public static string ObterVersaoDotNet(int value)
        {
            switch (value)
            {
                case 5: return "net5.0";
                case 6: return "net6.0";
                default: 
                {
                    System.Console.WriteLine("Opção incorreta.");
                    return "";
                }
            }
        }
        
        public static string ExecutaComandoCMD(string comando)
        {
            try
            {
                var retorno = "";
                using (Process processo = new Process())
                {
                    processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                    // Formata a string para passar como argumento para o cmd.exe
                    processo.StartInfo.Arguments = string.Format("/c "+ comando);

                    processo.StartInfo.RedirectStandardOutput = true;
                    processo.StartInfo.UseShellExecute = false;
                    processo.StartInfo.CreateNoWindow = true;

                    processo.Start();
                    processo.WaitForExit();

                    retorno = processo.StandardOutput.ReadToEnd();
                }
                return retorno;
            }
            catch(Exception e)
            {
                return @"Ocorreu um erro ao executar o comando.\n
                        Erro: "+e.Message;
            }

            
        }
    }
}