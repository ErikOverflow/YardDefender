using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] bool open = false;

    public void ToggleWindow()
    {
        if (open)
        {
            CloseWindow();
        }
        else
        {
            OpenWindow();
        }
        open = !open;
    }

    private void OpenWindow()
    {
        animator.SetTrigger("Open");
        Time.timeScale = 0;
    }

    private void CloseWindow()
    {
        animator.SetTrigger("Close");
        Time.timeScale = 1;
    }
}
