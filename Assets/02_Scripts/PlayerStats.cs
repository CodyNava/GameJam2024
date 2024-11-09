using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    //
    public float damage;
    public float movesSpeed;
    public float maxHealth;
    public float currentHealth;

    private void Awake()
    {
        Instance = this;
    }
}
