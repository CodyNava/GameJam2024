using UnityEngine;

public class BoolControler : MonoBehaviour
{
    public static BoolControler Instance { get; private set; }

    //-----------//

    public bool isNormal;
    public bool isFire;
    public bool isWater;
    public bool isNature;
    public bool isDead;
    public bool isDashing;
    public bool useWaterAbility;
    public bool useEarthAbility;
    public bool useFireAbility;
    

    //-----------//
    private void Awake()
    {
        Instance = this;
    }
}
