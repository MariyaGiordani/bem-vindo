using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using bem.vindo_Util;
using bem.vindo;

namespace bem.vindo.Models
{
    public class Cliente
    {
        public EnumTipoCliente TipoCliente { get; set; }
        public Guid CodigoDoCliente { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public EnumEstadoCivil EstadoCivil { get; set; }
        public EnumGenero Genero { get; set; }
        public List<Endereco> listaEndereco = new List<Endereco>();

        
    }

}

