using UnityEngine;

public class BoolControler : MonoBehaviour
{
    public static BoolControler Instance { get; private set; }

    //-----------//

    public bool isFire;
    public bool isWater;
    public bool isNature;
    public bool isDead;

    //-----------//
    private void Awake()
    {
        Instance = this;
    }
}
