using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bem.vindo.Utils
{
    public class EntityFile
    {
        public string Path { get; set; }
        private EntityFile() { }
        
	public EntityFile(EnumTipoArquivo tipoArquivo)
        {
            switch (tipoArquivo.ToString())
            {
                case "Cliente":
                    Path = @"c:\temp\CADASTROCLIENTE.TXT";
                    break;
                case "Endereco":
                    Path = @"c:\temp\CADASTROENDERECO.TXT";
                    break;
                default:
                    break;

            }
        }
    }
}
