using System;
using UnityEngine; 

[Serializable]
public class GameGrid
{
    [SerializeField] private int _width = 4;
    [SerializeField] private int _height = 4;
    [SerializeField] private int _sameCount = 2;

  
    public GameGrid(Settings settings)
    {
        _width = settings.Width;
        _height = settings.Height;
        _sameCount = settings.SameCardsCount;
    }

    public int Width => _width;
    public int Height => _height;


    public int SameCardsCount => _sameCount;

    public int CardCount => Width * Height;

}
