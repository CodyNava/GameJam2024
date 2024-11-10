using UnityEngine;
using UnityEngine.UI;
using static CharacterForms;

public class PlayerController : MonoBehaviour
{
    public CharacterForm currentForm = CharacterForm.Normal; // Start Form
    public int collectedCount = 0; 
    public Text collectibleCounterText; 

    private int totalCollectibles = 4; 

    private void Start()
    {
        UpdateCollectibleCounter();
    }

    // Methode zum Wechseln der Form
    public void ChangeForm(CharacterForm newForm)
    {
        currentForm = newForm;
        Debug.Log("Changed form to: " + currentForm);
    }

    
    public void CollectItem(CharacterForm requiredForm)
    {
        if (currentForm == requiredForm)
        {
            collectedCount++;
            UpdateCollectibleCounter();

            if (collectedCount >= totalCollectibles)
            {
                Debug.Log("Alle Collectibles gesammelt!");
            }
        }
        else
        {
            Debug.Log("Falsche Form, um dieses Collectible einzusammeln.");
        }
    }

    
    private void UpdateCollectibleCounter()
    {
        collectibleCounterText.text = collectedCount + "/" + totalCollectibles;
    }
}
