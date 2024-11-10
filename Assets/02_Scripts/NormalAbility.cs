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
    public void CustomUpdate()
    {
        if (BoolControler.Instance.isNormal)
        {
            Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (inputDirection != Vector2.zero)
            {
                lastMovementDirection = inputDirection.normalized;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                if (lastDashTime >= cooldown)
                {
                    StartCoroutine(Dash());
                }
            }
            lastDashTime += Time.deltaTime;
        }
    }
    IEnumerator Dash()
    {
        dashAnimation.SetTrigger("Dash");
        BoolControler.Instance.isDashing = true;
        trailRenderer.emitting = true;
        Vector2 dashPosition = (Vector2)transform.position + lastMovementDirection * dashDistance;

        float timeelapsed = 0f;
        while (timeelapsed <= dashTime)
        {
            float dashspeed = dashTime;


            transform.position = Vector2.Lerp(transform.position, dashPosition, dashspeed);
            timeelapsed += Time.deltaTime;
            yield return null;
        }
        lastDashTime = 0f;
        BoolControler.Instance.isDashing = false;
        trailRenderer.emitting = false;
    }
}
