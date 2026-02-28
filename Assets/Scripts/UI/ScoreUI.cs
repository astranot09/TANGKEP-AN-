using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        UpdateScoreUI();
    }


  
    public void UpdateScoreUI()
    {
        scoreText.text = GameManager.instance.ReturnScore().ToString();
    }
}
