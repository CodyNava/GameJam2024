using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShapeShifting : MonoBehaviour
{

    //--------------------------------------------------------//
    public Slider[] cooldownSlider;
    public bool canChangeForm = true;
    private float cooldownDuration = 5f;
    public Animator animator;
    public void Update()
    {
        //float dpadHorizontal = Input.GetAxis("DPadHorizontal");
        //float dpadVertical = Input.GetAxis("DPadVertical");
        if (canChangeForm)
        {
            ChangeForm();
        }
    }
    public void NormalFormEnabled()
    {
        animator.SetBool("Normal", true);
        animator.SetBool("Water", false);
        animator.SetBool("Fire", false);
        animator.SetBool("Stone", false);
        BoolControler.Instance.isNormal = true;
        BoolControler.Instance.isFire = false;
        BoolControler.Instance.isWater = false;
        BoolControler.Instance.isStone = false;
    }
    public void FireFormEnabled()
    {
        animator.SetBool("Normal", false);
        animator.SetBool("Fire", true);
        animator.SetBool("Water", false);
        animator.SetBool("Stone", false);
        BoolControler.Instance.isNormal = false;
        BoolControler.Instance.isFire = true;
        BoolControler.Instance.isWater = false;
        BoolControler.Instance.isStone = false;
    }
    public void WaterFormEnabled()
    {
        animator.SetBool("Normal", false);
        animator.SetBool("Fire", false);
        animator.SetBool("Water", true);
        animator.SetBool("Stone", false);
        BoolControler.Instance.isNormal = false;
        BoolControler.Instance.isFire = false;
        BoolControler.Instance.isWater = true;
        BoolControler.Instance.isStone = false;
    }
    public void StoneFormEnabled()
    {
        animator.SetBool("Normal", false);
        animator.SetBool("Fire", false);
        animator.SetBool("Water", false);
        animator.SetBool("Stone", true);
        BoolControler.Instance.isNormal = false;
        BoolControler.Instance.isFire = false;
        BoolControler.Instance.isWater = false;
        BoolControler.Instance.isStone = true;
    }
    void ChangeForm()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { BoolControler.Instance.isNormal = true; StartCoroutine(FormChangeCooldown()); NormalFormEnabled(); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { BoolControler.Instance.isFire = true; StartCoroutine(FormChangeCooldown()); FireFormEnabled(); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { BoolControler.Instance.isWater = true; StartCoroutine(FormChangeCooldown()); WaterFormEnabled(); }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { BoolControler.Instance.isStone = true; StartCoroutine(FormChangeCooldown()); StoneFormEnabled(); }
    }
    IEnumerator FormChangeCooldown()
    {
        canChangeForm = false;
        yield return new WaitForSeconds(cooldownDuration);
        canChangeForm = true;
    }
}
