
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using bem.vindo.Utils;

namespace bem.vindo.Util
{
    public class FileUtil //: IUtil
    {
        private string Path { get; set; }
        private EntityFile EntityFile { get; set; }


        private FileUtil() 
        {
        }

        public FileUtil(EnumTipoArquivo tipoArquivo)
        {
            EntityFile = new EntityFile(tipoArquivo);
            Path = EntityFile.Path;
        }
        public void Open()
        {
            bool isFileExists = FileExists();
            if (!isFileExists)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(Path))
                    {
                        Console.WriteLine("Arquivo foi criado!");
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFalha na criação do arquivo: " + ex.Message);
                }
            }
        }

        public bool FileExists()
        {
            bool fileExists = File.Exists(Path);
            if (!fileExists)
            {
                Console.WriteLine("O arquivo não existe!");
            }
            return fileExists;
        }

        public void Delete()
        {
            bool isFileExists = FileExists();
            if (isFileExists)
            {
                try
                {
                    File.Delete(Path);
                    Console.WriteLine("{0} está delitado com sucesso!", Path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nMensagem: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Não tem arquivos para deletar!");
            }
        }

        public void Update(string newString)
        {
            try
            {
                Open();
                using (FileStream fs = new FileStream(Path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(newString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMensagem: " + ex.Message);
            }
        }

        public void Listagem()
        {
            try
            {
                Open();
                using (StreamReader sr = new StreamReader(Path))
                {
                    String linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


