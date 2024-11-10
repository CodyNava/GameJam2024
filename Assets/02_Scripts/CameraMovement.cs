using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera mainCamera;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.collider.tag == "Player")
            {
                Debug.Log("Camera move is triggerd");

                mainCamera.transform.position += mainCamera.transform.position - new Vector3(28.18f, 0, 0);
            }
        }
    }
}
