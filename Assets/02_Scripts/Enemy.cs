using UnityEngine;

public class Enemy : MonoBehaviour, i_Update
{
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public bool isDead;
    public float deathTime;
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }

    public void CostumUpdate()
    {
        if (currentHealth <= 0f)
        {
            Dying();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage();
            DealDamage();
        }
    }
    public void TakeDamage()
    {
        currentHealth -= PlayerStats.Instance.damage;
    }
    public void DealDamage()
    {
        PlayerStats.Instance.currentHealth -= damage;
    }
    public void Dying()
    {
        Destroy(gameObject, deathTime);
        isDead = true;
    }
}
