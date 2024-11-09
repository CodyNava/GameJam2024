using UnityEngine;

//Character Forms

using UnityEngine;
using System.Collections;

public class FormChanger : MonoBehaviour
{
    public GameObject[] forms; // Array für die 4 Formen
    private int currentFormIndex = 0; // Aktuelle Form-Index
    private bool canChangeForm = true; // Cooldown-Kontrolle
    private float cooldownDuration = 5f; // Cooldown in Sekunden

    void Start()
    {
        ActivateForm(currentFormIndex);
    }

    void Update()
    {
        if (canChangeForm)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeForm(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeForm(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeForm(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeForm(3);
        }
    }
     
    void ChangeForm(int formIndex)
    {
        if (formIndex != currentFormIndex)
        {
            forms[formIndex].gameObject.SetActive(true);
          
            forms[currentFormIndex].gameObject.SetActive(false);
            currentFormIndex = formIndex;
            ActivateForm(currentFormIndex);
            StartCoroutine(FormChangeCooldown());
        }
    }

    void ActivateForm(int index)
    {
        for (int i = 0; i < forms.Length; i++)
        {
            forms[i].SetActive(i == index);
        }
    }

    IEnumerator FormChangeCooldown()
    {
        canChangeForm = false;
        yield return new WaitForSeconds(cooldownDuration);
        canChangeForm = true;
    }
}

/*public class ShapeShifting : MonoBehaviour, i_Update
{
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    public void CustomUpdate()
    {
        if (BoolControler.Instance.isFire) { FireFormEnabled(); }
        if (BoolControler.Instance.isWater) { WaterFormEnabled(); }
        if (BoolControler.Instance.isNature) { NatureFormEnabled(); }
    }
    public void FireFormEnabled()
    {

    }
    public void WaterFormEnabled()
    {

    }
    public void NatureFormEnabled()
    {

    }
}*/
