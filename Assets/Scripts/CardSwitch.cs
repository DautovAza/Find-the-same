using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardSwitch : MonoBehaviour
{
    public event Action onCardKill;

    [SerializeField, Min(0.1f)] private float showDuration = 1;

    private List<ICard> _openCards = new List<ICard>();
    private int _maxSameCardsCount;
    private Coroutine _showTimer;

    public void Initialize(GameGrid grid)
    {
        _maxSameCardsCount = grid.SameCardsCount;
    }

    public void OnCardOpen(ICard card)
    {
        if (_openCards.Count == _maxSameCardsCount)
        {
            if (CheckSame())
            {
                KillOpenCards();
            }
            else
            {
                if (_showTimer != null)
                {
                    StopCoroutine(_showTimer);
                }

                _showTimer = StartCoroutine(ShowTimer());
            }
        }
    }

    private void CloseCards()
    {
        _openCards.ForEach(card => card.Close());
        _openCards.Clear();
    }

    private void KillOpenCards()
    {
        _openCards.ForEach(card => card.Kill());
        _openCards.Clear();

        onCardKill?.Invoke();
    }

    public void OnCardClick(ICard card)
    {
        if (_openCards.Count < _maxSameCardsCount)
        {
            _openCards.Add(card);
            card.Open();
        }
    }

    private bool CheckSame()
    {
        ICard template = _openCards.FirstOrDefault();
        return template != null && _openCards.All(card => template.IsSame(card));
    }

    private IEnumerator ShowTimer()
    {
        yield return new WaitForSeconds(showDuration);
        CloseCards();
    }

}
