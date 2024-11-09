using UnityEngine;

public class Pickup : MonoBehaviour
{
    private int elementToPickUp = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            I_Inventory inventory = collision.GetComponent<I_Inventory>();

            if (inventory != null)
            {
                inventory.Elements = inventory.Elements + elementToPickUp;
                print("Element Picked Up");
                gameObject.SetActive(false);
            }
        }
    }
}
