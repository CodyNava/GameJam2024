using UnityEngine;

public class PlayerMovement : MonoBehaviour,i_Update
{
    public float moveSpeed = 5f;          // Geschwindigkeit des Spielers
    private Rigidbody2D rb;               // Referenz zum Rigidbody2D des Spielers
    private Vector2 movement;             // Bewegungsvektor
    
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }

    void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D holen
    }

   public void CostumUpdate()
    {
        // Eingaben sammeln

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Bewegung anwenden
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
