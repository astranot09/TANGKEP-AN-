using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private int score;

    public void GetPoint(int scoreValue)
    {
        score += scoreValue;
        AudioManager.instance.PlaySFX(AudioManager.instance.gainPoint);
    }
    public int ReturnScore()
    {
        return score;
    }
}
