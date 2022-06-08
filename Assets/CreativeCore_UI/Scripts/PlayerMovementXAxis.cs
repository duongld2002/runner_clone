using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementXAxis : MonoBehaviour
{
    [Header("OffsetSign")]
    [Range(0, 1f)] public float offsetDistanceX;
    public Vector2 distanceXInterval;
    private float _signDistanceX;

    private float _distanceX;
    public float speed = 10f;

    [Header("Lerp")]
    public float frameLerpTarget;
    public float lerpStep;

    [Header("Bounderies")]
    public float minXBound;
    public float maxXBound;

    [Header("Reference")]
    public PlayerInput playerInput;

    private void Update()
    {
        if (playerInput)
        {
            playerInput.UpdateInput();
            _distanceX = playerInput.DistanceX;
            _signDistanceX = Mathf.Abs(playerInput.DistanceX) / Time.deltaTime;
            MoveX();
        }
        else
        {
            _distanceX = 0;
            _signDistanceX = 0;
        }
    }
    public void MoveX()
    {
        Vector3 newTargetPosition = transform.position + Vector3.right * _distanceX * offsetDistanceX;
        Vector3 tempPosition = Vector3.MoveTowards(transform.position, newTargetPosition, _signDistanceX * Time.deltaTime);
        //Vector3 tempPosition = Vector3.Lerp(transform.position, newTargetPosition, lerpStep * Time.deltaTime);
        Vector3 fixedPostion = new Vector3(Mathf.Clamp(tempPosition.x, minXBound, maxXBound), transform.position.y, transform.position.z);

        transform.position = fixedPostion;
    }

}