﻿using MimicaRemake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MimicaRemake.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jogo : ContentPage
    {
        public Jogo(Grupo grupo)
        {
            InitializeComponent();
            BindingContext = new ViewModel.JogoViewModel(grupo);
        }
    }
}