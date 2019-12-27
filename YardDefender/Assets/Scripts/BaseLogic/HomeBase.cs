using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    [SerializeField] BaseData baseData = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] int health = 10;

    public void Initialize(BaseData _baseData)
    {
        baseData = _baseData;
        UpdateBase();
    }

    void UpdateBase()
    {
        spriteRenderer.sprite = baseData.sprite;
        health = baseData.health;
    }

    private void OnValidate()
    {
        if (baseData == null)
            return;
        UpdateBase();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health <= 0)
            return;
        GameObject go = collision.gameObject;
        Debug.Log(go.name);
        MobStats mobStats = collision.gameObject.GetComponent<MobStats>();
        if (mobStats != null)
        {
            health -= 1;
            mobStats.gameObject.SetActive(false);
        }
    }
}
