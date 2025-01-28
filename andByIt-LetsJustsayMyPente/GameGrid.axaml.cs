using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using SkiaSharp;
using System;
using System.Collections.Generic;

namespace andByIt_LetsJustSayMyPente;

    public partial class GameGrid : UserControl
    {
        private int MAX_SIZE = 19;
        public List<List<Bitmap>> choiceGridData { get; set; }
    public GameGrid()
        {
        InitializeComponent();
        choiceGridData = new List<List<Bitmap>>();
        Bitmap bitmap = new Bitmap(AssetLoader.Open(new Uri("avares://andByIt-LetsJustSayMyPente/images/emptyPiece.png")));
        //code utilizing a for loop to generate the mass amount of "buttons", being images
            for (int i = 0; i < MAX_SIZE; i++)
            {
            var row = new List<Bitmap>();
            for (int j = 0; j < MAX_SIZE; j++)
            {
                row.Add(bitmap);
                if (bitmap == null)
                {
                    Console.WriteLine("Bug testing cause this thing hates working");
                }
            }
            choiceGridData.Add(row);
            }
        } 
    }