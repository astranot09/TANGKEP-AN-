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
    }
    public int ReturnScore()
    {
        return score;
    }
}
