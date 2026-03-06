using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using EasyCodeBuilder.Application.Interfaces;
using Microsoft.CSharp;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// コンパイラサービスの実装
    /// </summary>
    public class CompilerService : ICompilerService, IDisposable
    {
        private Process _runningProcess;
        private string _tempFolderPath;

        public event EventHandler<CompileResult> CompileCompleted;

        public CompilerService()
        {
            // 一時フォルダのパスを設定
            _tempFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "一時ファイルEasyCodeBuilder"
            );
        }

        public CompileResult Compile(string sourceCode, string outputPath)
        {
            var result = new CompileResult();

            try
            {
                var provider = CSharpCodeProvider.CreateProvider("CSharp");
                var cp = new CompilerParameters
                {
                    GenerateExecutable = true,
                    OutputAssembly = outputPath,
                    GenerateInMemory = false,
                    TreatWarningsAsErrors = false,
                    CompilerOptions = "/optimize"
                };

                // 参照アセンブリを追加
                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("System.Threading.Tasks.dll");
                cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                cp.ReferencedAssemblies.Add("System.Windows.dll");
                cp.ReferencedAssemblies.Add("System.Linq.dll");
                cp.ReferencedAssemblies.Add("System.Drawing.dll");
                cp.ReferencedAssemblies.Add("System.Core.dll");
                cp.ReferencedAssemblies.Add("System.Xml.dll");
                cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
                cp.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
                cp.ReferencedAssemblies.Add("System.Data.dll");

                CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode);

                if (cr.Errors.Count > 0)
                {
                    result.Success = false;
                    result.Errors = cr.Errors;
                    result.ErrorMessage = string.Join("\n", cr.Errors);
                }
                else
                {
                    result.Success = true;
                    result.OutputPath = outputPath;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }

            CompileCompleted?.Invoke(this, result);
            return result;
        }

        public CompileResult CompileAndRun(string sourceCode)
        {
            EnsureTempFolderExists();

            // 実行ファイル名を生成
            int counter = 0;
            string exeName = Path.Combine(_tempFolderPath, "Program.exe");
            while (File.Exists(exeName))
            {
                counter++;
                exeName = Path.Combine(_tempFolderPath, $"Program[{counter}].exe");
            }

            var result = Compile(sourceCode, exeName);

            if (result.Success)
            {
                try
                {
                    _runningProcess = Process.Start(exeName);
                    _runningProcess.EnableRaisingEvents = true;
                    _runningProcess.Exited += (s, e) =>
                    {
                        try
                        {
                            File.Delete(exeName);
                        }
                        catch { }
                    };
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.ErrorMessage = ex.Message;
                }
            }

            return result;
        }

        public void TerminateRunningProcess()
        {
            if (_runningProcess != null)
            {
                try
                {
                    if (!_runningProcess.HasExited)
                    {
                        _runningProcess.Kill();
                    }
                    _runningProcess.Close();
                    _runningProcess.Dispose();
                }
                catch { }
                finally
                {
                    _runningProcess = null;
                }
            }
        }

        private void EnsureTempFolderExists()
        {
            if (!Directory.Exists(_tempFolderPath))
            {
                Directory.CreateDirectory(_tempFolderPath);
                var di = new DirectoryInfo(_tempFolderPath);
                di.Attributes |= FileAttributes.Hidden;
            }
        }

        public void Dispose()
        {
            TerminateRunningProcess();
        }
    }
}
