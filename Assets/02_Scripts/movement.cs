using UnityEngine;

public class PlayerMovement : MonoBehaviour, i_Update
{
    [Header("Animator")]
    public Animator running;
    [Header("Movement")]
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true;
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }

    void Start()
    {
        UpdateManager.Instance.RegisterUpdate(this);
        rb = GetComponent<Rigidbody2D>();
    }

    public void CustomUpdate()
    {
        OnMove();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * PlayerStats.Instance.movesSpeed * Time.fixedDeltaTime);
    }
    public void OnMove()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float vertiacalInput = Input.GetAxisRaw("Vertical");

        running.SetFloat("Speed", Mathf.Abs(vertiacalInput + horizontalInput));

        Vector3 inputVector = new Vector3(horizontalInput, vertiacalInput, 0);
        transform.position += inputVector * Time.deltaTime * PlayerStats.Instance.movesSpeed;

        if (horizontalInput < 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

