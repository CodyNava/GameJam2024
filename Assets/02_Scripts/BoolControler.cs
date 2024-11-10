using UnityEngine;

public class BoolControler : MonoBehaviour
{
    public static BoolControler Instance { get; private set; }

    //-----------//

    public bool isNormal;
    public bool isFire;
    public bool isWater;
    public bool isStone;
    public bool isDead;
    public bool isDashing;
    public bool useWaterAbility;
    public bool useEarthAbility;
    public bool useFireAbility;
    public bool isEnemyStunned;
    

    //-----------//
    private void Awake()
    {
        Instance = this;
    }
}
