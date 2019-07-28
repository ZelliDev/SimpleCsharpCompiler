using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCsharpCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseCode = File.ReadAllText("test.cs");

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = "test.exe";
            // parameters.ReferencedAssemblies.Add("lib/System.IO.FileSystem.dll");
            if (File.Exists("test.exe"))
            {
                File.Delete("test.exe");
            }
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, baseCode);

            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    Console.WriteLine("Line number " + CompErr.Line +
                        ", Error Number: " + CompErr.ErrorNumber +
                        ", '" + CompErr.ErrorText + ";" +
                        Environment.NewLine + Environment.NewLine);

                }
            }
            else
            {
                Console.WriteLine("Votre application a été généré");
            }

            Console.ReadKey();

        }
    }
}
