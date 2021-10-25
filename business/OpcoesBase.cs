using System;

namespace business
{
    public class OpcoesBase : Attribute
    {
        public bool Obrigatorio { get; set; }
        public bool ChavePrimaria { get; set; }
        public bool ChaveEstrangeira { get; set; }
        public bool Index { get; set; }
        public int Caracteres { get; set; }
    }
}