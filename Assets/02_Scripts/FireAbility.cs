using System.Collections;
using UnityEngine;

public class FireAbility : MonoBehaviour, i_Update
{
    public GameObject firaball;
    public Transform FireballSpawnTransform;
    public float FireballCooldown;
    public bool canUseAbility;
    private Vector2 lastMovementDirection;
    public float shotForce;
    [SerializeField] float lastDashTime = 0f;
    public Animator fireAnimation;

    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    //-----------------------------------------------//
    public void CustomUpdate()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (inputDirection != Vector2.zero)
        {
            lastMovementDirection = inputDirection.normalized;
        }
        
        if (BoolControler.Instance.isFire && canUseAbility)
        {
            StartCoroutine(UsingAbility());
        }
    }
    IEnumerator UsingAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireAnimation.SetTrigger("FireAbility");
            GameObject SpawnedFireball = Instantiate(firaball, FireballSpawnTransform.position, FireballSpawnTransform.rotation);
            SpawnedFireball.GetComponent<Rigidbody2D>().AddForce(lastMovementDirection * shotForce, ForceMode2D.Impulse);
            canUseAbility = false;
            yield return new WaitForSeconds(FireballCooldown);
            canUseAbility = true;
            fireAnimation.ResetTrigger("FireAbility");
        }
    }
}
