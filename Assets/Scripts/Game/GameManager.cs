using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CardSpawner), typeof(CardSwitch))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameGrid grid;
    [SerializeField] private SoundEffects soundEffects;
    [SerializeField] private EndGameMenu endGameMenu;

    [SerializeField] private float gameEndDelay = 2;
    [SerializeField] private bool loadSettingsFile = true;



    private CardSpawner _cardSpawner;
    private CardSwitch _cardSwitch;
    private int _score;
    
    private void Awake()
    {
        if (loadSettingsFile)
        {
            grid = new GameGrid(SettingProvider.LoadFile());
        }

        _cardSpawner = GetComponent<CardSpawner>();
        _cardSwitch = GetComponent<CardSwitch>();

        _cardSpawner.Initialize(grid);
        _cardSwitch.Initialize(grid);

        StartLevel();
    }

    private void StartLevel()
    {
        _score = 0;
        var cards = _cardSpawner.SpawnCards();

        foreach (var card in cards)
        {
            SubForCardEvents(card);
        }

        _cardSwitch.onCardKill += OnCardsKill;

        if (soundEffects)
        {
            _cardSwitch.onCardKill += soundEffects.KillEffectPlay;
        }
    }

    private void SubForCardEvents(ICard card)
    {
        card.onClick += _cardSwitch.OnCardClick;
        card.onOpen += _cardSwitch.OnCardOpen;

        if (soundEffects)
        {
            card.onClick += (c) =>
            {
                soundEffects.ClickEffectPlay();
            };
        }
    }

    private void OnCardsKill()
    {
        _score++;
        if (_score == grid.CardCount / grid.SameCardsCount)
        {
            Debug.Log("Победа!");
            Invoke("WinGame",gameEndDelay);
        }
    }

    private void WinGame()
    {
        endGameMenu?.ShowPanel(true);
        soundEffects.WinEffectPlay();
    }

    private void LoseGame()
    {
        endGameMenu?.ShowPanel(true);
        soundEffects.LoseEffect();
    }

}
