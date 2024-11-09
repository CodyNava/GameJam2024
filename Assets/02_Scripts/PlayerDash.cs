using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 3f;          // Entfernung des Dashes
    private float nextDashTime = 0f;         // Zeitpunkt für den nächsten Dash
    private Vector2 lastMovementDirection;   // Speichert die letzte Bewegungsrichtung

    void Update()
    {
        // Eingaben prüfen und die letzte Bewegungsrichtung speichern
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (inputDirection != Vector2.zero)
        {
            lastMovementDirection = inputDirection.normalized;
        }

        // Dash auslösen, wenn die Space-Taste gedrückt und der Cooldown vorbei ist
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    void Dash()
    {
    
        // Zielposition basierend auf der letzten Bewegungsrichtung berechnen
        Vector2 dashPosition = (Vector2)transform.position + lastMovementDirection * dashDistance;

        // Spieler teleportieren
        transform.position = dashPosition;
    }
}
