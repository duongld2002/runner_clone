using UnityEngine;

public class FacingObject : MonoBehaviour
{
    public Transform facing;

    private void Start()
    {
        facing = GameObject.FindGameObjectWithTag("LookAt").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(new Vector3(facing.position.x, facing.position.y, facing.position.z));        
    }
}
