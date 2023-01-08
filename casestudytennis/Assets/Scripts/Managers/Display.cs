using UnityEngine;

public class Display : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(720,1280,true);
        Application.targetFrameRate = 60;
    }
}