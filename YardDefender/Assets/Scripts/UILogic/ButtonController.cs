using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.ErikOverflow
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField]
        Animator animator = null;
        [SerializeField]
        AudioSource audioSource = null;
        public void Pressed()
        {
            animator?.SetTrigger("ButtonPress");
            audioSource?.Play();
        }
    }
}