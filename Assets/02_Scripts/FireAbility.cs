using System.Collections;
using UnityEngine;

public class FireAbility : MonoBehaviour
{
    public GameObject firaball;
    public Transform FireballSpawnTransform;
    public float FireballCooldown;
    public bool canUseAbility;
    private Vector2 lastMovementDirection;
    public float shotForce;
    [SerializeField] float lastDashTime = 0f;
    public Animator fireAnimation;



    //-----------------------------------------------//

    public void Update()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (inputDirection != Vector2.zero)
        {
            lastMovementDirection = inputDirection.normalized;
        }
        
        if (BoolControler.Instance.isFire && canUseAbility && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(UsingAbility());
        }
    }
    IEnumerator UsingAbility()
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
