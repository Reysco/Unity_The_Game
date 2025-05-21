using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{
    public static GUIControl gControl { get; private set; }
    public static GUIControl guicontrol;

    public GameObject GreenKeyOnOff;
    public bool GreenKeyOn;

    public GameObject keyOnOff;
    public bool keyOn;

    private void Awake()
    {
        if (gControl == null)
        {
            gControl = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void KeyOn()
    {
        keyOnOff.SetActive(true);
        keyOn = true;

    }

    public void GreenKeyON()
    {
        GreenKeyOnOff.SetActive(true);
        GreenKeyOn = true;

    }

}
