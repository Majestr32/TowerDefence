using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class TurretLevel
{
    public int coinsPrice;
    public int woodsPrice;
    public int bricksPrice;
    public float timeOnBuild;
    public Bullet bullet;
    public float AttacksPerSecond;
}
public class Turret : MonoBehaviour
{
    public TurretLevel[] Levels;
    private int currentLevelIndex = 0;
    public List<GameObject> AimsInRange = new List<GameObject>();
    public float attackRange = 1.5f;
    private float CurrentShootCooldown;
    public int CurrentLevel
    {
        get
        {
            return currentLevelIndex + 1;
        }
    }
    private void Update()
    {
        StartCoroutine(CheckTargets());
        Rotate();
        RunCooldown();
        Shoot();
    }
    public void RunCooldown()
    {
        if (CurrentShootCooldown >= 0)
        {
            CurrentShootCooldown -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        if(CurrentShootCooldown <= 0 && AimsInRange.Count > 0)
        {
            Bullet bull = Instantiate(Levels[currentLevelIndex].bullet,transform.position,Quaternion.identity);
            bull.SetDestination(AimsInRange[0]);
            CurrentShootCooldown = 1 / Levels[currentLevelIndex].AttacksPerSecond;
        }
    }
    public void Rotate()
    {
        if(AimsInRange.Count > 0 && AimsInRange[0] != null)
        {
            Vector3 direction = (AimsInRange[0].transform.position - transform.position).normalized;
            transform.rotation = Quaternion.FromToRotation(Vector3.up,direction);
        }
    }
    private void AddTargetIfNew(GameObject[] enemies)
    {
        foreach (var enemy in enemies)
        {
            if (!AimsInRange.Contains(enemy))
            {
                AimsInRange.Add(enemy);
            }
        }
    }
    private IEnumerator CheckTargets()
    {
        yield return new WaitForSeconds(0.5f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        GameObject[] enemiesObjects = colliders.Select(c => c.gameObject).Where(c => c.CompareTag("Enemy")).ToArray();
        RemoveTargetIfOut(enemiesObjects);
        AddTargetIfNew(enemiesObjects);
        CheckTargets();
    }
    private void RemoveTargetIfOut(GameObject[] enemies)
    {
        GameObject[] enemiesToRemove = AimsInRange.Except(enemies).ToArray();
        foreach(var enemyToRemove in enemiesToRemove)
        {
            AimsInRange.Remove(enemyToRemove);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
