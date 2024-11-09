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
    private void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);
        playerMovement = GetComponent<PlayerStats>();
        if (playerMovement != null)
        {
            originalSpeed = playerMovement.movesSpeed;
            print(originalSpeed);
        }
    }

    public void CustomUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9) && !useWaterAbility)
        {
            StartCoroutine(UsingWaterAbility());
        }
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
        BoolControler.Instance.useWaterAbility = false;
    }
}
