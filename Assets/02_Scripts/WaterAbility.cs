using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isStunned = false;
    private float stunEndTime;

    void Update()
    {
        if (isStunned)
        {
            // Überprüfen, ob der Stun vorbei ist
            if (Time.time >= stunEndTime)
            {
                isStunned = false;
            }
            return; // Stoppt die Bewegung, wenn der Gegner gestunnt ist
        }

        // Hier kannst du den normalen Bewegungs-Code des Gegners einfügen
        MoveEnemy();
    }

    public void DisableMovement(float duration)
    {
        isStunned = true;
        stunEndTime = Time.time + duration;
    }

    void MoveEnemy()
    {
        // Beispielbewegungscode, z.B. einfaches Vorwärtslaufen
        transform.Translate(Vector2.left * Time.deltaTime);
    }
}
