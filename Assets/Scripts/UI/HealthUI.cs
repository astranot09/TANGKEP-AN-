using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthUI : MonoBehaviour
{
    public static HealthUI instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private GameObject healthBar;
    private Image healthImage;
    [SerializeField] private TMP_Text healthText;

    [SerializeField] private Player player;

    private void Start()
    {
        healthImage = healthBar.GetComponent<Image>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {
        healthImage.fillAmount = player.currHealth/player.maxHealth;
        healthText.text = $"{player.currHealth}/{player.maxHealth}";
    }
}
