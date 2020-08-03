using MimicaRemake.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using MimicaRemake.Storage;

namespace MimicaRemake.ViewModel 
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command IniciarCommand{ get; set; }

        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.GrupoA = new Grupo();
            Jogo.GrupoB = new Grupo();
        }

        private void IniciarJogo()
        {
            SaveGame.Jogo = this.Jogo;
            SaveGame.RodadaAtual = 1;
            App.Current.MainPage = new View.Jogo(Jogo.GrupoA);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
