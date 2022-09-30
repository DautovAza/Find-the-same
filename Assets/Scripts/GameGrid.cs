using System;
using UnityEngine; 

[Serializable]
public class GameGrid
{
    [SerializeField] private int width = 4;
    [SerializeField] private int height = 4;
    [SerializeField] private int sameCount = 2;

    public int Width => width;
    public int Height => height;

    public int SameCardsCount => sameCount;

    public int CardCount => Width * Height;

}
