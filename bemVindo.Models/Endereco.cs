using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using bem.vindo_Util;

namespace bem.vindo.Models
{
    [Serializable]
    public class Endereco
    {
        public Guid IdAddress { get; set; }
        public Guid CodigoDoCliente { get; set; }
        public EnumTipoLogradouro TipoLogradouro { get; set; }
        public String NomeLogradouro { get; set; }
        public String Complemento { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
    }
}
