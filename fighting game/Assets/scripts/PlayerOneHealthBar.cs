using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class PlayerOneHealthBar : MonoBehaviour
{
    public Image currentHealthbar;

    public static float health = 100;
    public static float maxHealth = 100;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = health / maxHealth;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        UpdateHealthBar();
    }

}
