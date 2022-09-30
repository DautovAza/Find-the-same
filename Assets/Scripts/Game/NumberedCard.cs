using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NumberedCard : MonoBehaviour, ICard
{
    public event Action<ICard> onClick;
    public event Action<ICard> onOpen;

    public int Number { get; private set; }

    [SerializeField] private Text nameText;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private float rotateDuration = 0.5f;
    [SerializeField] private float destroyDuration = 1;
    [SerializeField] private float destroyTargetScale = 0.5f;

    private readonly Vector3 _openRotation = new Vector3(0, 0, 0);
    private readonly Vector3 _closeRotation = new Vector3(0, 0, 180);

    private bool _isOpen;
    private bool _locled;

    #region Initialize
    public void Initialize(int number)
    {
        Number = number;

        if (nameText != null)
        {
            nameText.text = number.ToString();
        }

        transform.rotation = Quaternion.Euler(_closeRotation);
    }
    #endregion

    public void Open()
    {
        if (!_isOpen)
        {
            Rotate(_openRotation);
        }
    }

    public void Close()
    {
        if (_isOpen)
        {
            Rotate(_closeRotation);
        }
    }

    public void Kill()
    {
        transform
            .DOScale(destroyTargetScale*transform.localScale, destroyDuration)
            .OnComplete(() => { Destroy(gameObject); });
    }
    public bool IsSame(ICard other)
    {
        var numCard = other as NumberedCard;
        return numCard != null && numCard.Number == Number;
    }

    private void Rotate(Vector3 targetRot)
    {
        _locled = true;
        transform.DORotate(targetRot, rotateDuration, RotateMode.Fast)
            .OnComplete(AfterRotation);
    }

    private void AfterRotation()
    {
        _isOpen = !_isOpen;        
        if (_isOpen)
        {
            onOpen?.Invoke(this);
        }
        _locled = false;
    }

    private void OnMouseDown()
    {
        if (!_isOpen && !_locled && !Game.gamePaused)
        {
            onClick?.Invoke(this);
        }
    }
}
