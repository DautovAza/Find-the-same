using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenes : MonoBehaviour
{
    
    public void LoadGame()
    {
        Game.gamePaused = false;
        SceneManager.LoadScene("Game");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
public static class Game
{
    public static bool gamePaused = false;

}