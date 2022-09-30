using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private float offset = 1;
    [SerializeField] private NumberedCard numberedCardPrefab;

    private GameGrid _grid;
    private List<ICard> _spawnedCards = new List<ICard>();

    public void Initialize(GameGrid grid)
    {
        _grid = grid;

        if (numberedCardPrefab == null)
        {
            throw new ArgumentNullException("numberedCardPrefab","Не назначен префаб карты!");
        }
    }

    public List<ICard> SpawnCards()
    {
        _spawnedCards.ForEach(card => card?.Kill());
        _spawnedCards.Clear();

        var emptyCells = Enumerable.Range(0, _grid.CardCount).ToList();

        for (int i = 0; i < _grid.CardCount; i++)
        {
            Vector3 position = GetRndPosition(emptyCells);
            ICard card = SpawnCard(position, i / _grid.SameCardsCount + 1);
            _spawnedCards.Add(card);
        }

        return _spawnedCards;
    }

    private NumberedCard SpawnCard(Vector3 position, int num)
    {
        var card = Instantiate(numberedCardPrefab, position, Quaternion.identity);
        card.Initialize(num);
        return card;
    }
   
    protected Vector3 GetRndPosition(List<int> points)
    {
        int rndIndex = Random.Range(0, points.Count);
        int rndCell = points[rndIndex];

        points.RemoveAt(rndIndex);

        float x = (rndCell % _grid.Width) * offset - (_grid.Width - 1) * offset / 2;
        float z = (rndCell / _grid.Width) * offset - (_grid.Height - 1) * offset / 2;

        return new Vector3(x, 0, z);
    }
}
