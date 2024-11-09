using UnityEngine;

public class PlayerCombat : MonoBehaviour, i_Update
{

    private void Start() { UpdateManager.Instance.RegisterUpdate(this); }
    private void OnDisable() { UpdateManager.Instance.UnregisterUpdate(this); }

    public void CustomUpdate()
    {

    }
}
