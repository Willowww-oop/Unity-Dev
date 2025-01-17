using UnityEngine;

public class Destructable : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 20;
    [SerializeField] GameObject destroyFx;

    bool destroyed = false;

    public void ApplyDamage(float damage)
    {
        if (destroyed) return;

        health -= damage;
        if (health <= 0)
        {
            destroyed = true;
            if (destroyFx != null) Instantiate(destroyFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
