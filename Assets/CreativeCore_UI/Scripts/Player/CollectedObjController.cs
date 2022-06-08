using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjController : MonoBehaviour
{
    [SerializeField]
    PlayerManager playerManager;

    public FixedTouchField fixedTouchField;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        fixedTouchField = GameObject.FindGameObjectWithTag("FixedTouchField").GetComponent<FixedTouchField>();

        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();

            Rigidbody rb = GetComponent<Rigidbody>();

            

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Transform>().Length);
    }

    private void Update()
    {
        if (fixedTouchField.IsPressed)
        {
            EffectManager.Instance.SpawnFootStepEffect(transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Collectable"))
        {
            if (!playerManager.collidedList.Contains(collision.gameObject))
            {
                collision.gameObject.tag = "Player";
                collision.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.SetTexture("_BaseMap", playerManager.collectedTexture);
                collision.transform.parent = playerManager.collectedPoolTransform;
                playerManager.collidedList.Add(collision.gameObject);
                collision.gameObject.AddComponent<CollectedObjController>();
                
            }
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            EffectManager.Instance.SpawnPlayerBloodEffect(transform.position);
            EffectManager.Instance.spawnDeadSound();
            gameObject.SetActive(false);
        }

    }

   //private void OnTriggerEnter(Collider other)
   //{
   //
   //    if (other.gameObject.CompareTag("Castle"))
   //    {
   //        animator.SetBool("IsWin", true);
   //    }
   //}
}
