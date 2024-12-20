using UnityEngine;

public class Enemy : MonoBehaviour
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
    public float stunTime = 5f;
    public ParticleSystem hitEffect;
    [Header("Bools")]
    public bool rangedEnemy;
    public bool meleeEnemy;
    public bool chargeReady;
    public bool isDead;
    public bool isCharging;
    public bool isEnemyStunned;

    public Animator animator;
    private Transform playerTransform;
    private Vector2 chargeTarget;
    private void Start() { currentHealth = maxHealth; playerTransform = GameObject.FindGameObjectWithTag("Player").transform; }

    public void Update()
    {
        if (currentHealth <= 0f)
        {
            Dying();
        }
        else
        {
            if (!isEnemyStunned)
            {
                DetectAndChargePlayer();
            }
        }
    }
    private void DetectAndChargePlayer()
    {
        if (meleeEnemy)
        {
            if (playerTransform != null && !isCharging)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

                if (distanceToPlayer <= detectionRadius && distanceToPlayer > chargeDistance)
                {
                    animator.SetBool("IsMoving", true);
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
                else
                {
                    animator.SetBool("IsMoving", false);
                }
            }
        }
    }
    private System.Collections.IEnumerator PauseAndCharge()
    {
        isCharging = true;
        chargeReady = false;
        animator.SetTrigger("Attack");
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
        if (BoolControler.Instance.useWaterAbility && collision.gameObject.tag == "Player")
        {
            StartCoroutine(PauseMovement());
        }
    }
    public void TakeDamage()
    {
        hitEffect.Play();
        currentHealth -= PlayerStats.Instance.damage;
    }
    public void DealDamage()
    {
        if (!BoolControler.Instance.isDashing || !BoolControler.Instance.useWaterAbility)
        {
            PlayerStats.Instance.currentHealth -= damage;
        }
    }
    public void Dying()
    {
        Destroy(gameObject, deathTime);
        isDead = true;
    }
    public System.Collections.IEnumerator PauseMovement()
    {
        isEnemyStunned = true;
        yield return new WaitForSeconds(5f);
        isEnemyStunned = false;
    }
}
