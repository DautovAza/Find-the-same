using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private Text lable;
    [SerializeField] private string winText = "������!";
    [SerializeField] private string loseText = "�� ������!";

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowPanel(bool win)
    {
        gameObject.SetActive(true);
        if (lable)
        {
            lable.text = win ? winText : loseText;
        }
    }
}
