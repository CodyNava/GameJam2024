using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isStunned = false;
    private float stunEndTime;

    void Update()
    {
        if (isStunned)
        {
            // �berpr�fen, ob der Stun vorbei ist
            if (Time.time >= stunEndTime)
            {
                isStunned = false;
            }
            return; // Stoppt die Bewegung, wenn der Gegner gestunnt ist
        }

        // Hier kannst du den normalen Bewegungs-Code des Gegners einf�gen
        MoveEnemy();
    }

    public void DisableMovement(float duration)
    {
        isStunned = true;
        stunEndTime = Time.time + duration;
    }

    void MoveEnemy()
    {
        // Beispielbewegungscode, z.B. einfaches Vorw�rtslaufen
        transform.Translate(Vector2.left * Time.deltaTime);
    }
}
