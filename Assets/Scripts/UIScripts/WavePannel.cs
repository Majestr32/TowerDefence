using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavePannel : MonoBehaviour
{
    public static WavePannel Instance { get; private set; }
    [SerializeField]
    private Text txtWave;
    [SerializeField]
    private GameObject objWave;
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        #endregion
    }



    public void ShowWave(int wave)
    {
        StartCoroutine(AnimationWave(wave));
    }
    private IEnumerator AnimationWave(int wave)
    {
        objWave.SetActive(true);
        txtWave.text = "Wave " + wave;
        yield return new WaitForSeconds(2f);
        objWave.SetActive(false);
    }
}
