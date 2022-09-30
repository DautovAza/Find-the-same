using System;
using UnityEngine;
using UnityEngine.UI;

public class NumberedCard : MonoBehaviour, ICard
{
    public event Action<ICard> onClick;
    public event Action<ICard> onOpen;

    public int Number { get; private set; }

    [SerializeField] private Text nameText;
    [SerializeField] private SpriteRenderer sprite;

    private readonly Vector3 _openRotation = new Vector3(0, 0, 0);
    private readonly Vector3 _closeRotation = new Vector3(0, 0, 180);

    private bool _isOpen;

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
        else
        {
            Debug.Log(this.name + ": карта уже открыта!");
        }
    }

    public void Close()
    {
        if (_isOpen)
        {
            Rotate(_closeRotation);
        }
        else
        {
            Debug.Log(this.name + ": карта уже закрыта!");
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    public bool IsSame(ICard other)
    {
        var numCard = other as NumberedCard;
        return numCard != null && numCard.Number == Number;
    }

    private void Rotate(Vector3 targetRot)
    {
        transform.rotation = Quaternion.Euler(targetRot);
        AfterRotation();
    }

    private void AfterRotation()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            onOpen?.Invoke(this);
        }
    }

    private void OnMouseDown()
    {
        if (!_isOpen)
        {
            onClick?.Invoke(this);
        }
    }
}
