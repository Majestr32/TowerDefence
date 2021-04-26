using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyGroup
{
    public GameObject enemy;
    public int count;
    public void InstantiateEnemy()
    {
        GameObject.Instantiate(enemy, EnemiesSpawner.Instance.spawnPosition, Quaternion.identity);
    }
}
[System.Serializable]
public class EnemyWave
{
    public EnemyGroup[] groups;
}
public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner Instance { get; private set; }
    public Vector3 spawnPosition;
    public EnemyWave[] waves;
    [SerializeField]
    private int currentWaveIndex = 0;
    [SerializeField]
    private int currentGroupIndex = 0;
    private bool EnemiesOnTheMap;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(SpawnWaveGroup());
    }
    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(15);
        NextWave();
    }
    private IEnumerator SpawnWaveGroup()
    {
        if (currentGroupIndex == 0)
            WavePannel.Instance.ShowWave(currentWaveIndex + 1);
        int howManyToSpawn = waves[currentWaveIndex].groups[currentGroupIndex].count;
        while (howManyToSpawn > 0)
        {
            yield return new WaitForSeconds(1f);
            waves[currentWaveIndex].groups[currentGroupIndex].InstantiateEnemy();
            howManyToSpawn--;
        }
        NextGroup();
    }
    private IEnumerator WaitBetweenGroups()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnWaveGroup());
    }
    public void NextGroup()
    {
        if (!GroupsAreOver())
        {
            currentGroupIndex++;
            StartCoroutine(WaitBetweenGroups());
        }
        else
        {
            StartCoroutine(SpawnWaves());
            currentGroupIndex = 0;
        }
    }
    public void NextWave()
    {
        if (!WavesAreOver())
        {
            currentWaveIndex++;
            StartCoroutine(SpawnWaveGroup());
        }
        else StartCoroutine(CheckWin());
    }
    private IEnumerator CheckWin()
    {
        EnemiesOnTheMap = true;
        while(EnemiesOnTheMap)
        {
            yield return new WaitForSeconds(1f);
            EnemiesOnTheMap = GameObject.FindGameObjectsWithTag("Enemy").Length == 0 ? false : true;
        }
        WinPannel.Instance.ShowWinPannel();
    }
    private bool GroupsAreOver()
    {
        return currentGroupIndex + 1 == waves[currentWaveIndex].groups.Length;
    }
    private bool WavesAreOver()
    {
        return currentWaveIndex + 1 == waves.Length;
    }
}
