using System;
using System.Collections;
using UnityEngine;

public class WaterAbility : MonoBehaviour, i_Update
{
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }


    [SerializeField] private float waterBoost = 2f;
    [SerializeField] private float boostDuration = 2f;

    private PlayerStats playerMovement;
    private bool useWaterAbility = false;
    private float originalSpeed;
    private float lastAbilityUseTime = 0f;
    public float cooldown = 2f;
    private void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);

        // saves base player movement speed
        playerMovement = GetComponent<PlayerStats>();
        if (playerMovement != null)
        {
            originalSpeed = playerMovement.movesSpeed;
            print(originalSpeed);
        }
    }

    public void CustomUpdate()
    {
        // use ability on button press
        if (Input.GetKeyDown(KeyCode.Alpha9) && !useWaterAbility && BoolControler.Instance.isWater)
        {
            if (lastAbilityUseTime >= cooldown)
            {
                StartCoroutine(UsingWaterAbility());
            }
        }
        lastAbilityUseTime += Time.deltaTime;
    }

    private IEnumerator UsingWaterAbility()
    {
        BoolControler.Instance.useWaterAbility = true;

        float timeelapsed = 0f;

        while (timeelapsed <= boostDuration)
        {
            playerMovement.movesSpeed = waterBoost;

            timeelapsed += Time.deltaTime;
            yield return null;
        }
        playerMovement.movesSpeed = originalSpeed;
        lastAbilityUseTime = 0f;
        BoolControler.Instance.useWaterAbility = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (BoolControler.Instance.useWaterAbility && collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(PauseMovement());
        }
    }
    private IEnumerator PauseMovement()
    {
        BoolControler.Instance.isEnemyStunned = true;
        yield return new WaitForSeconds(5f);
        BoolControler.Instance.isEnemyStunned = false;
    }
    
}
