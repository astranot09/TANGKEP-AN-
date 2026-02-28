using UnityEngine;

public class Item : Stuff
{
    protected override void Do()
    {
        GameManager.instance.GetPoint(1);
        ScoreUI.instance.UpdateScoreUI();
        Destroy(gameObject);
    }
}
