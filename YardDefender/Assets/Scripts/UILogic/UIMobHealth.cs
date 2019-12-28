using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMobHealth : MonoBehaviour
{
    [SerializeField] Slider slider = null;

    HealthController healthController = null;
    Transform trackingObject = null;

    public void Initialize(HealthController trackedController)
    {
        healthController = trackedController;
        trackingObject = healthController.transform;
        healthController.OnDamage += HealthChange;
        healthController.OnDeath += Disable;
    }

    public void HealthChange()
    {
        slider.value = healthController.GetPercent();
    }

    void LateUpdate()
    {
        transform.position = trackingObject.position;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        healthController.OnDamage -= HealthChange;
        healthController.OnDeath -= Disable;
    }
}
