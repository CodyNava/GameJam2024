using UnityEngine;

public class Enemy : MonoBehaviour, i_Update
{
    [Header("Stats")]
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float deathTime;
    [Header("Movement")]
    public float detectionRadius;
    public float moveSpeed;
    public float chargeSpeed;
    public float chargeDelay;
    public float chargeDistance;
    public float chargeCoolDown;
    [Header("Bools")]
    public bool chargeReady;
    public bool isDead;
    public bool isCharging;
    private Transform playerTransform;
    private Vector2 chargeTarget;
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); currentHealth = maxHealth; playerTransform = GameObject.FindGameObjectWithTag("Player").transform; }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    public void CustomUpdate()
    {
        if (currentHealth <= 0f)
        {
            Dying();
        }
        else
        {
            DetectAndChargePlayer();
        }
    }
    private void DetectAndChargePlayer()
    {
        if (playerTransform != null && !isCharging)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= detectionRadius && distanceToPlayer > chargeDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            }
            else if (distanceToPlayer <= chargeDistance)
            {
                chargeTarget = playerTransform.position;
                if (chargeReady)
                {
                    StartCoroutine(PauseAndCharge());
                }
            }
        }
    }
    private System.Collections.IEnumerator PauseAndCharge()
    {
        isCharging = true;
        chargeReady = false;
        yield return new WaitForSeconds(chargeDelay);
        while (Vector2.Distance(transform.position, chargeTarget) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, chargeTarget, chargeSpeed * Time.deltaTime);
            yield return null;
        }
        isCharging = false;
        yield return new WaitForSeconds(chargeCoolDown);
        chargeReady = true;
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
        if (isCharging)
        {
            PlayerStats.Instance.currentHealth -= damage * 2;
        }
        else
        {
            PlayerStats.Instance.currentHealth -= damage;
        }
    }
    public void Dying()
    {
        Destroy(gameObject, deathTime);
        isDead = true;
    }
}
