using System;
using System.Collections.Generic;
using System.Text;

namespace MimicaRemake.Model
{
    public class Jogo
    {
        public Grupo GrupoA { get; set; }
        public Grupo GrupoB { get; set; }
        public string Nivel { get; set; }
        public short TempoPalavra{ get; set; }
        public short Rodadas { get; set; }
        public int NivelNumerico { get; set; }

    }
}
