using System;
using System.Collections.Generic;
using System.Text;
using MimicaRemake.Model;

namespace MimicaRemake.Storage
{
    public class SaveGame
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras =
        {
            //Facil - 1 pts
            new string []{"Olho","Lingua", "Milho","Bola","Tenis"},
            //Medias - 3 pts
            new string []{"Marcenero","Lixeiro","Mercador", "Abelha", "Bolsa"},
            //Dificieis - 5 pts
            new string []{"Pneu", "Lançamento","Raiz","Oculista", "Ofensa", "Cimento"},
        };
    }
}
