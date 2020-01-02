﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField] Animator animator = null;

    public void ToggleWindow()
    {
        if (gameObject.activeInHierarchy)
        {
            CloseWindow();
        }
        else
        {
            OpenWindow();
        }
    }

    private void OpenWindow()
    {
        StopCoroutine(WaitForAnimationFinishBeforeInactivate());
        gameObject.SetActive(true);
        animator.SetTrigger("Open");
    }

    private void CloseWindow()
    {
        animator.SetTrigger("Close");
        StartCoroutine(WaitForAnimationFinishBeforeInactivate());
    }

    IEnumerator WaitForAnimationFinishBeforeInactivate()
    {
        yield return null;
        while(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
