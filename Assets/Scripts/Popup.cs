using System.Diagnostics;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public AudioSource sound;

    public void OnMouseDown()
    {
        sound.Play();
        Process.Start(Application.dataPath + "\\Resources\\" + gameObject.name + ".pdf");
    }
}
