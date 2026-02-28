using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{

    public static LosePanel instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Score Text")]
    [SerializeField] private TMP_Text scoreText;

    [Header("Name Input")]

    [SerializeField] private string inputNameText;
    [SerializeField] private GameObject losePanel;

    [Header("Choose Exit or Restart")]
    [SerializeField] private GameObject SubmitButton;
    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject ExitButton;

    public void LoseSetUp()
    {
        losePanel.SetActive(true);
        SubmitButton.SetActive(true);
        RestartButton.SetActive(false);
        ExitButton.SetActive(false);
        scoreText.text = GameManager.instance.ReturnScore().ToString();
    }

    public void GrabFromInputField(string input)
    {
        inputNameText = input;
    }

    public void SubmitGame()
    {
        Debug.Log("tes");
        if (string.IsNullOrWhiteSpace(inputNameText))
            return;
        Debug.Log("tes lagi");
        LeaderboardManager.instance.AddScore(inputNameText, GameManager.instance.ReturnScore());
        SubmitButton.SetActive(false);
        RestartButton.SetActive(true);
        ExitButton.SetActive(true);
    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}
