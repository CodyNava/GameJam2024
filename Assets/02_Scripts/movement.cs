using UnityEngine;

public class PlayerMovement : MonoBehaviour,i_Update

    
{
    [Header("Animator")]
    //public Animator running;
    [Header("Movement")] // Geschwindigkeit des Spielers
    private Rigidbody2D rb;               // Referenz zum Rigidbody2D des Spielers
    private Vector2 movement;             // Bewegungsvektor

    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }

    void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D holen
    }

   public void CustomUpdate()
    {
       OnMove();
      
    }

    void FixedUpdate()
    {
        // Bewegung anwenden
        rb.MovePosition(rb.position + movement * PlayerStats.Instance.movesSpeed * Time.fixedDeltaTime);
    }
    public void OnMove()
    {
        //moveSpeed
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float vertiacalInput = Input.GetAxisRaw("Vertical");

        //running.SetFloat("speed", Mathf.Abs(vertiacalInput + horizontalInput));

        Vector3 inputVector = new Vector3(horizontalInput, vertiacalInput, 0);
        transform.position += inputVector * Time.deltaTime * PlayerStats.Instance.movesSpeed;
    }
}
