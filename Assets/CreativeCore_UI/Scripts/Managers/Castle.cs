using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectWin;

    public Animator[] animators;

    private void Update()
    {
        animators = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("IsWin", true);
            }
            gameObjectWin.SetActive(true);
            EffectManager.Instance.spawnWinSound();
        }
    }
}
