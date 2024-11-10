using System;
using UnityEngine;

public class SlimeGen : MonoBehaviour
{
	[SerializeField] private GameObject GenActive;
	[SerializeField] private GameObject GenDestroy;
	[SerializeField] private float delay;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (BoolControler.Instance.isDashing)
			{
				GenActive.SetActive(false);
				GenDestroy.SetActive(true);
				Invoke(nameof(onDelay), delay);
			}
		}
	}

	private void onDelay()
	{
		gameObject.SetActive(false);
	}
}
