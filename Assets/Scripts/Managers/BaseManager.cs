using UnityEngine;

public abstract class BaseManager<U> : MonoBehaviour where U : MonoBehaviour
{
    public static U Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this as U;
        }
    }
}