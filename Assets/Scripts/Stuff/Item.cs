using UnityEngine;

public class Item : Stuff
{
    [SerializeField] private ParticleSystem ps;
    private void Awake()
    {
        ps = GameObject.Find("Basket").GetComponent<ParticleSystem>();
    }
    protected override void Do()
    {
        GameManager.instance.GetPoint(1);
        ps.Play();
        ScoreUI.instance.UpdateScoreUI();
        Destroy(gameObject);
    }
}
