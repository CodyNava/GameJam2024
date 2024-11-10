using UnityEngine;
using UnityEngine.UI;
using static CharacterForms;

public class PlayerController : MonoBehaviour
{
    public CharacterForm currentForm = CharacterForm.Normal; // Startform
    public int collectedCount = 0; // Anzahl gesammelter Collectibles
    public Text collectibleCounterText; // Referenz zur UI-Textkomponente

    private int totalCollectibles = 4; // Maximale Anzahl der Collectibles

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

    // Methode zum Einsammeln der Collectibles
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

    // Aktualisiere den UI-Text für den Zähler
    private void UpdateCollectibleCounter()
    {
        collectibleCounterText.text = collectedCount + "/" + totalCollectibles;
    }
}
