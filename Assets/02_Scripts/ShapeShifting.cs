using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShapeShifting : MonoBehaviour, i_Update
{
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); ActivateForm(currentFormIndex); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }

    public GameObject[] forms; // Array für die 4 Formen
    public Slider[] cooldownSlider;
    private int currentFormIndex = 0; // Aktuelle Form-Index
    private bool canChangeForm = true; // Cooldown-Kontrolle
    private float cooldownDuration = 5f; // Cooldown in Sekunden
    public Animator animator;

    public void CustomUpdate()
    {
        if (BoolControler.Instance.isNormal) { NormalFormEnabled(); }
        if (BoolControler.Instance.isFire) { FireFormEnabled(); }
        if (BoolControler.Instance.isWater) { WaterFormEnabled(); }
        if (BoolControler.Instance.isStone) { StoneFormEnabled(); }


        float dpadHorizontal = Input.GetAxis("DPadHorizontal");
        float dpadVertical = Input.GetAxis("DPadVertical");

        if (canChangeForm)
        {    /*
            if (Input.GetKeyDown(KeyCode.Alpha1) || (dpadHorizontal == -1)) ChangeForm(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2) || (dpadVertical == 1)) ChangeForm(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3) || (dpadHorizontal == 1)) ChangeForm(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4) || (dpadVertical == -1)) ChangeForm(3);*/

            if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeForm(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeForm(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeForm(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeForm(3);

        }
    }
    public void NormalFormEnabled()
    {

    }
    public void FireFormEnabled()
    {

    }
    public void WaterFormEnabled()
    {

    }
    public void StoneFormEnabled()
    {

    }

    void ActivateForm(int index)
    {
        for (int i = 0; i < forms.Length; i++)
        {
            forms[i].SetActive(i == index);
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

            switch (formIndex)
            {
                case 0:
                    animator.SetBool("Normal", true);
                    animator.SetBool("Stone", false);
                    animator.SetBool("Water", false);
                    animator.SetBool("Fire", false);
                    BoolControler.Instance.isNormal = true;
                    BoolControler.Instance.isFire = false;
                    BoolControler.Instance.isWater = false;
                    BoolControler.Instance.isStone = false;
                    break;
                case 1:
                    animator.SetBool("Normal", false);
                    animator.SetBool("Stone", false);
                    animator.SetBool("Water", false);
                    animator.SetBool("Fire", true);
                    BoolControler.Instance.isNormal = false;
                    BoolControler.Instance.isFire = true;
                    BoolControler.Instance.isWater = false;
                    BoolControler.Instance.isStone = false;
                    break;
                case 2:
                    animator.SetBool("Normal", false);
                    animator.SetBool("Stone", false);
                    animator.SetBool("Water", true);
                    animator.SetBool("Fire", false);
                    BoolControler.Instance.isNormal = false;
                    BoolControler.Instance.isFire = false;
                    BoolControler.Instance.isWater = true;
                    BoolControler.Instance.isStone = false;
                    break;
                case 3:
                    animator.SetBool("Normal", false);
                    animator.SetBool("Stone", true);
                    animator.SetBool("Water", false);
                    animator.SetBool("Fire", false);
                    BoolControler.Instance.isNormal = false;
                    BoolControler.Instance.isFire = false;
                    BoolControler.Instance.isWater = false;
                    BoolControler.Instance.isStone = true;
                    break;
            }
        }
    }

    IEnumerator FormChangeCooldown()
    {
        canChangeForm = false;
        yield return new WaitForSeconds(cooldownDuration);
        canChangeForm = true;
    }

}
