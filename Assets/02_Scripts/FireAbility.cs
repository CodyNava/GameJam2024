using System.Collections;
using UnityEngine;

public class FireAbility : MonoBehaviour, i_Update
{
    public GameObject firaball;
    public Transform FireballSpawnTransform;
    public float FireballDuration;
    public float FireballCooldown;
    public bool canUseAbility;
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    //-----------------------------------------------//
    public void CustomUpdate()
    {
        if (BoolControler.Instance.isFire && canUseAbility)
        {
            StartCoroutine(UsingAbility());
        }
    }
    IEnumerator UsingAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject SpawnedFireball = Instantiate(firaball, FireballSpawnTransform.position, Quaternion.identity);
            SpawnedFireball.transform.parent = null;
            canUseAbility = false;
            yield return new WaitForSeconds(FireballCooldown);
            canUseAbility = true;
        }
    }
}
