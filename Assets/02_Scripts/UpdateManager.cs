using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager Instance { get; private set; }
    private List<i_Update> updates = new List<i_Update>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
            Debug.Log("1");
        }
        else if (Instance != this)
        {
            Debug.Log("2");
            Destroy(gameObject);
        }
    }
    public void RegisterUpdate(i_Update update)
    {
        if (!updates.Contains(update))
        {
            updates.Add(update);
        }
    }
    public void UnregisterUpdate(i_Update update)
    {
        if (updates.Contains(update))
        {
            updates.Remove(update);
        }
    }
    private void FixedUpdate()
    {
        foreach (var update in updates)
        {
            update.CostumUpdate();
        }
    }
}
