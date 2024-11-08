using UnityEngine;

public class ShapeShifting : MonoBehaviour, i_Update
{
    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }
    public void CostumUpdate()
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
}
