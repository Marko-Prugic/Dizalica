using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private Color Default;
    void OnMouseEnter()
    {
        Default = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.green;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Default;
    }
}
