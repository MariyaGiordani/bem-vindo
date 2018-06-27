
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bem.vindo.Util
{
    public class FileUtil //: IUtil
    {
        private string path { get; set; }

        private FileUtil() 
        {
        }

        public FileUtil(string _path)
        {
            path = _path;
        }
        public void Open()
        {
            bool isFileExists = FileExists(path);
            if (!isFileExists)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        Console.WriteLine("Arquivo foi criado!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFalha na criação do arquivo: " + ex.Message);
                }
            }
        }

        public bool FileExists(string path)
        {
            bool fileExists = File.Exists(path);
            if (!fileExists)
            {
                Console.WriteLine("O arquivo não existe!");
            }
            return fileExists;
        }

        public void Delete()
        {
            bool isFileExists = FileExists(path);
            if (isFileExists)
            {
                try
                {
                    File.Delete(path);
                    Console.WriteLine("{0} está delitado com sucesso!", path);
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

        public void Update()
        {
            try
            {
                Open();
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(fs);

                    //sw.Write(newString);
                    //sw.Close();


                    Console.WriteLine("Arquivo salvo!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMensagem: " + ex.Message);
            }
        }
    }
}


