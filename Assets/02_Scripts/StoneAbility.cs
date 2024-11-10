using System.Collections;
using UnityEngine;

public class StoneAbility : MonoBehaviour
{
    public GameObject shockWave;
    public Transform ShockWaveSpawnTransform;
    public float shockWaveDuration;
    public float shockWaveCooldown;
    public bool canUseAbility;
    public Animator stoneAnimation;
    //-----------------------------------------------//
    public void Update()
    {
        if (BoolControler.Instance.isStone && canUseAbility && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(UsingAbility());
        }
    }
    IEnumerator UsingAbility()
    {
        stoneAnimation.SetTrigger("StoneAbility");
        GameObject SpawnedShockWave = Instantiate(shockWave, ShockWaveSpawnTransform.position, Quaternion.identity);
        SpawnedShockWave.transform.parent = null;
        canUseAbility = false;
        yield return new WaitForSeconds(shockWaveCooldown);
        canUseAbility = true;
        stoneAnimation.ResetTrigger("StoneAbility");
    }
}
