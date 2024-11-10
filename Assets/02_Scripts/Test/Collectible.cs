using UnityEngine;
using static CharacterForms;

public class Collectible : MonoBehaviour
{
    public CharacterForm Normal; //vier verschiedene Formen

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.CollectItem(requiredForm);
            Destroy(gameObject); 
        }
    }
}
