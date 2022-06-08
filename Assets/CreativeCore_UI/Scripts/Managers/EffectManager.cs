using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    [Header("Effects")]
    public Effect playerBloodEffect;
    public Effect enemyBloodEffect;
    public Effect footStepEffect;

    [Header("Sounds")]
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioSource run;
    public AudioClip dead;
    public AudioClip win, fireworks;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        audioSource = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        run = GameObject.FindGameObjectWithTag("RunSound").GetComponent<AudioSource>();
    }

    public void SpawnPlayerBloodEffect(Vector3 pos)
    {
        //pos = pos.SetY(1.6f);
        SpawnEffect("Player_blood_fx", playerBloodEffect, pos);
    }

    public void SpawnEnemyBloodEffect(Vector3 pos)
    {
        pos = pos.SetY(1.6f);
        SpawnEffect("Enemy_blood_fx", enemyBloodEffect, pos);
    }

    public void SpawnFootStepEffect(Vector3 pos)
    {
        //pos = pos.SetY();
        SpawnEffect("step_fx", footStepEffect, pos);
    }

    private void SpawnEffect(string name, Effect effectPrefab, Vector3 pos, Transform parent = null, Quaternion rot = default(Quaternion))
    {
        Effect effect = ObjectPool.Get<Effect>(name);
        if (effect == null)
        {
            effect = Instantiate(effectPrefab, parent == null ? transform : parent);
        }
        if (parent != null) effect.transform.SetParent(parent);
        effect.transform.position = pos;
        if (rot != default(Quaternion))
            effect.transform.rotation = rot;
        effect.gameObject.SetActive(true);
        effect.Init(name);
    }

    public void spawnDeadSound()
    {
        audioSource.PlayOneShot(dead);
    }

    public void runSoundOn()
    {
        run.enabled = true;
    }

    public void runSoundOff()
    {
        run.enabled = false;
    }

    public void spawnWinSound()
    {
        audioSource.PlayOneShot(win);
        audioSource.PlayOneShot(fireworks);
    }
}
