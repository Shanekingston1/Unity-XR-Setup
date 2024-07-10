using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    public float TimerValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}