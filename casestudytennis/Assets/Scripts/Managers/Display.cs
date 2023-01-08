
using UnityEngine;

public class Display : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(this);

    private void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        Application.targetFrameRate = 60;
    }
}