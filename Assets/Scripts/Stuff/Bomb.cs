using UnityEngine;

public class Bomb : Stuff
{
    [SerializeField] float damage;
    protected override void Do()
    {
        giveDamage();
        Destroy(gameObject);
    }
    protected override void PlayerGet()
    {
        giveDamage();
    }

    private void giveDamage()
    {
        Player.instance.TakeDamage(damage);
    }


}
