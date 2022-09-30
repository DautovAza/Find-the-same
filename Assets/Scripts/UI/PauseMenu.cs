using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
   
    [SerializeField] private Button pauseButton;
    public void ShowPanel(bool show)
    {
        pauseButton.gameObject.SetActive(!show);
        gameObject.SetActive(true);
        Game.gamePaused = show;
    }

    private void Awake()
    {
        gameObject.SetActive(false);

        if (pauseButton)
        {
            pauseButton.onClick .AddListener( () => ShowPanel(true));
        }
    }
}

