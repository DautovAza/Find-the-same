using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CardSpawner),typeof(CardSwitch))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameGrid grid;

    private CardSpawner _cardSpawner;
    private CardSwitch _cardSwitch;

    private void Awake()
    {
        _cardSpawner = GetComponent<CardSpawner>();
        _cardSwitch = GetComponent<CardSwitch>();

        _cardSpawner.Initialize(grid);
        _cardSwitch.Initialize(grid);

        StartLevel();
    }

    private void StartLevel()
    {
        var cards = _cardSpawner.SpawnCards();

        foreach (var card in cards)
        {
            card.onClick += _cardSwitch.OnCardClick;
            card.onOpen += _cardSwitch.OnCardOpen;
        }
    }

}
