using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float timer;
    private void Awake()
    {
        Destroy(gameObject, timer);
    }
}
