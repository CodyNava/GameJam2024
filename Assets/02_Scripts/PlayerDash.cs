using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour, i_Update
{
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }


    public float dashDistance = 3f;         // Entfernung des Dashes
    public float dashTime = 2f;           // Dauer des Dashes
    public float cooldown = 2f;             //Dash cooldown
    private float lastDashTime = 0f;        // Zeitpunkt für denletzten Dash
    private Vector2 lastMovementDirection;  // Speichert die letzte Bewegungsrichtung
    private bool isDashing = false;
    public TrailRenderer trailRenderer;
    public Animator dashAnimation;

    public void CustomUpdate()
    {
        // Eingaben prüfen und die letzte Bewegungsrichtung speichern
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (inputDirection != Vector2.zero)
        {
            lastMovementDirection = inputDirection.normalized;
        }

        // Dash auslösen, wenn die Space-Taste gedrückt und der Cooldown vorbei ist
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (lastDashTime >= cooldown)
            {
                StartCoroutine(Dash());
            }
        }
        lastDashTime += Time.deltaTime;
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
