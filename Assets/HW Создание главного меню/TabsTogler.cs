using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsTogler : MonoBehaviour
{
    [SerializeField] private List<Button> _tabs;
    [SerializeField] private List<Button> _windows;

    public void ActivateAll()
    {
        foreach (var tab in _tabs) 
        {
            tab.interactable = true;
        }

        foreach (var window in _windows) 
        {
            window.interactable = true;
        }
    }
}
