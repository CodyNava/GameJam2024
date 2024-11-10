using System.Collections;
using UnityEngine;

public class StoneAbility : MonoBehaviour, i_Update
{
    public GameObject shockWave;
    public Transform ShockWaveSpawnTransform;
    public float shockWaveDuration;
    public float shockWaveCooldown;
    public bool canUseAbility;
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    //-----------------------------------------------//
    public void CustomUpdate()
    {
        if (BoolControler.Instance.isStone && canUseAbility)
        {
            StartCoroutine(UsingAbility());
        }
    }
    IEnumerator UsingAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject SpawnedShockWave = Instantiate(shockWave, ShockWaveSpawnTransform.position, Quaternion.identity);
            SpawnedShockWave.transform.parent = null;
            canUseAbility = false;
            yield return new WaitForSeconds(shockWaveCooldown);
            canUseAbility = true;
        }
    }
}
