using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float MaxHp = 100f;
    public float BountyKilling = 20f;
    private GameObject healthBar;
    private float maxHealthBarLengthX;
    private float currentHp;
    private void Awake()
    {
        currentHp = MaxHp;
        healthBar = transform.Find("healthBar").gameObject;
        maxHealthBarLengthX = healthBar.transform.localScale.x;
    }
    public void ReceiveDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            PlayerData.Instance.ReceiveCoins((int)BountyKilling);
            Destroy(gameObject);
        }
        UpdateHpView();
    }
    private void UpdateHpView()
    {
        float HpCoeff = currentHp / MaxHp;
        healthBar.transform.localScale = new Vector3(HpCoeff * maxHealthBarLengthX, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
