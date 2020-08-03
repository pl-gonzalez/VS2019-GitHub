using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using MimicaRemake.Storage;
using MimicaRemake.Model;


namespace MimicaRemake.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        public Grupo Grupo { get; set; }
        public string NomeGrupo { get; set; }
        public string Palavra { get { return _Palavra; } set { _Palavra = value; OnPropertyChanged("Palavra"); } }
        private string _Palavra  { get; set; }
       
        public short PalavraPontuacao { get { return _PalavraPontuacao; } set { _PalavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } }
        private short _PalavraPontuacao { get; set; }
        
        public string TextoContagem { get { return _TextoContagem; } set { _TextoContagem = value; OnPropertyChanged("TextoContagem"); } }
        private string _TextoContagem { get; set; }


        public bool IsVisiblebtnIniciar { get { return _IsVisiblebtnIniciar; } set { _IsVisiblebtnIniciar = value; OnPropertyChanged("IsVisiblebtnIniciar"); } }
        private bool _IsVisiblebtnIniciar { get; set; }
       
        public bool IsVisibleContainerContagem { get { return _IsVisibleContainerContagem; }set { _IsVisibleContainerContagem = value; OnPropertyChanged("IsVisibleContainerContagem");} }
        private bool _IsVisibleContainerContagem { get; set; }

        public bool IsVisiblebtnMostrar { get { return _IsVisiblebtnMostrar; } set { _IsVisiblebtnMostrar = value; OnPropertyChanged("IsVisiblebtnMostrar");} }
        private bool _IsVisiblebtnMostrar { get; set; }


        public Command Acertou { get; set; }
        public Command MostrarPalavra { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }


        public JogoViewModel(Grupo grupo)
        {
            Grupo = grupo;
            NomeGrupo = grupo.Nome;
            IsVisiblebtnIniciar = false;
            IsVisibleContainerContagem = false;
            IsVisiblebtnMostrar = true;

            Palavra = "*********";

            MostrarPalavra = new Command (MostrarPalavraAction);
            Acertou = new Command (AcertouAction);
            Errou = new Command (ErrouAction);
            Iniciar = new Command (IniciarAction);
        }

        private void AcertouAction()
        {
            Grupo.Pontuacao += PalavraPontuacao;
            GoProximoGrupo();

        }
        private void GoProximoGrupo()
        {
            //TODO - Verificar fim de rodada
            Grupo grupo;
            if (SaveGame.Jogo.GrupoA == Grupo)
            {
                grupo = SaveGame.Jogo.GrupoB;
               
            }
            else
            {
                grupo = SaveGame.Jogo.GrupoA;
                SaveGame.RodadaAtual++;
            }
            if (SaveGame.RodadaAtual > SaveGame.Jogo.Rodadas)
            {
                App.Current.MainPage = new View.Resultado();
            }
            else
            {
            App.Current.MainPage = new View.Jogo(grupo);

            }
        }

        private void ErrouAction()
        {
            GoProximoGrupo();
        }

        private void IniciarAction()
        {
            //TODO - Quando termina tempo, para contagem
            IsVisiblebtnIniciar = false;
            IsVisibleContainerContagem = true;

            int t = SaveGame.Jogo.TempoPalavra;
            Device.StartTimer(TimeSpan.FromSeconds(1), ()=>
            {
                TextoContagem = t.ToString();
                t--;
                if(t < 0)
                {
                    TextoContagem = "Esgotou o tempo";
                }
                return true;
            });
                
        }

        private void MostrarPalavraAction()
        {
            PalavraPontuacao = 3;
            Palavra = "Sentar";
            var NumNivel = SaveGame.Jogo.NivelNumerico;
            if (NumNivel == 0)
            {
                //Aleatorio
                Random rd = new Random();
                int niv = rd.Next(0, 2);
                int ind = rd.Next(0, SaveGame.Palavras[niv].Length);
                Palavra = SaveGame.Palavras[niv][ind];
                PalavraPontuacao = (short)((niv==0)? 1 : (niv == 1) ? 3 : 5);
            }
            else if (NumNivel == 1)
            {
                //fac
                Random rd = new Random();
                int ind = rd.Next(0, SaveGame.Palavras[NumNivel - 1].Length);
                Palavra = SaveGame.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 1;
            }
            else if (NumNivel == 2)
            {
                //Med
                Random rd = new Random();
                int ind = rd.Next(0, SaveGame.Palavras[NumNivel - 1].Length);
                Palavra = SaveGame.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 3;
            }
            else if (NumNivel == 3)
            {
                //Dif
                Random rd = new Random();
                int ind = rd.Next(0, SaveGame.Palavras[NumNivel - 1].Length);
                Palavra = SaveGame.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 5;
            }


            IsVisiblebtnMostrar = false;
            IsVisiblebtnIniciar = true;
            
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
