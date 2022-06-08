using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    
    public SkinnedMeshRenderer renderer;

    private Rigidbody rb;

    [SerializeField] bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer.material.SetTexture("_BaseMap", playerManager.collectedTexture);

        playerManager.collidedList.Add(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
    }

    void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Run;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(this, 1);
    }
}
