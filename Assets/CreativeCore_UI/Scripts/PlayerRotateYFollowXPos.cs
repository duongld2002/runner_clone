using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateYFollowXPos : MonoBehaviour
{
    public Transform playerModelTransform;
    public Vector2 rotationInterval;
    public Vector2 positionStepInterval;
    public float stepSnapThreshHold;
    public float rotateTargetAngleStep;
    public float rotateAngleStep;

    float _currentTargetAngleY;
    float _prePosX;
    public void Start()
    {
        _currentTargetAngleY = playerModelTransform.eulerAngles.y;
        _prePosX = playerModelTransform.position.y;
    }
    private void Update()
    {
        RotateY();
    }
    private void RotateY()
    {
        float stepDirPreviousFrame = playerModelTransform.position.x - _prePosX;
        float stepPreviousFrame = Mathf.Abs(stepDirPreviousFrame);

        if(stepPreviousFrame > stepSnapThreshHold)
        {
            playerModelTransform.eulerAngles = new Vector3(playerModelTransform.eulerAngles.x, stepDirPreviousFrame > 0? rotationInterval.y: rotationInterval.x, playerModelTransform.eulerAngles.z);
        }
        _prePosX = playerModelTransform.position.x;

        float targetAngleY = stepDirPreviousFrame.RemapClamp(positionStepInterval.x, positionStepInterval.y, rotationInterval.x, rotationInterval.y);

        _currentTargetAngleY = Mathf.LerpAngle(playerModelTransform.eulerAngles.y, targetAngleY, Time.deltaTime * rotateTargetAngleStep);
        playerModelTransform.eulerAngles = new Vector3(playerModelTransform.eulerAngles.x, _currentTargetAngleY, playerModelTransform.eulerAngles.z);
    }
    public void ResetY()
    {
        playerModelTransform.eulerAngles = new Vector3(playerModelTransform.eulerAngles.x, 0, playerModelTransform.eulerAngles.z);
    }
}
public static class MathEx
{
    public static float RemapClamp(this float f, float fromMin, float fromMax, float toMin, float toMax)
    {
        float t = (f - fromMin) / (fromMax - fromMin);
        return Mathf.Lerp(toMin, toMax, t);
    }
}
