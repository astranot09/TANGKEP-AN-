using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    public GameObject scoreBoardPanel;
    

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Scoreboard()
    {
        scoreBoardPanel.SetActive(!scoreBoardPanel.activeSelf);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
