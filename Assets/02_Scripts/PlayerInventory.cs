using UnityEngine;

public class PlayerInventory : MonoBehaviour, I_Inventory
{
	public int Elements {get => _element; set => _element = value; }

	private int _element = 0;
}
