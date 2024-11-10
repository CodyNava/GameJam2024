using System.Collections;
using UnityEngine;

public class NormalAbility : MonoBehaviour, i_Update
{
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }

    public float dashDistance = 3f;
    public float dashTime = 2f;
    public float cooldown = 2f;
    [SerializeField] float lastDashTime = 0f;
    private Vector2 lastMovementDirection;
    private bool isDashing = false;
    public TrailRenderer trailRenderer;
    public Animator dashAnimation;
    private bool canDash;

    public void Update()
    {
        canDash = Input.GetKey(KeyCode.Space);
        if (BoolControler.Instance.isNormal)
        {
            Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


            lastMovementDirection = inputDirection.normalized;

            if (canDash)
            {
                if (lastDashTime <= Time.time - cooldown)
                {
                    lastDashTime = Time.time;
                    StartCoroutine(Dash());
                }
                canDash = false;
            }
        }
    }
    
    public void CustomUpdate()
    {
    }
    IEnumerator Dash()
    {
        
        Vector2 dashPosition;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastMovementDirection, dashDistance, LayerMask.GetMask("Wall"));
        if (hit)
        {
            
            dashPosition = hit.point;

        }
        else
        {
            
            dashPosition = (Vector2)transform.position + lastMovementDirection * dashDistance;

        }
        dashAnimation.SetTrigger("Dash");
        BoolControler.Instance.isDashing = true;
        trailRenderer.emitting = true;
        

        float timeelapsed = 0f;
        while (timeelapsed <= dashTime)
        {
            
            float dashspeed = dashTime;


            transform.position = Vector2.Lerp(transform.position, dashPosition, dashspeed);
            timeelapsed += Time.deltaTime;
            yield return null;
        }

        BoolControler.Instance.isDashing = false;
        trailRenderer.emitting = false;
        
    }
}
