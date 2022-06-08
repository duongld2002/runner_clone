using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType
{
    StopLeft, StopRight, StopAll, None
}
public class PlayerInput : MonoBehaviour
{
    public static bool canControl = true;
    public MoveType moveType = MoveType.None;
    public FixedTouchField fixedTouchField;
    public float moveAxisDeadZone = 0.2f;
    public Vector2 MoveInput { get; private set; }
    public Vector2 LastMoveInput { get; private set; }
    public Vector2 CameraInput { get; private set; }

    public bool HasMoveInput { get; private set; }

    public float DistanceX { get; private set; }

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        fixedTouchField.pointerDown.AddListener(StartGameOnPointerDown);
    }
    private void OnEnable()
    {
        canControl = true;
        fixedTouchField.pointerDown.AddListener(OnPointerDown);
        fixedTouchField.pointerUp.AddListener(OnPointerUp);
    }
    private void OnDisable()
    {
        fixedTouchField.pointerDown.RemoveListener(OnPointerDown);
        fixedTouchField.pointerUp.RemoveListener(OnPointerUp);
    }
    private void OnPointerUp()
    {
    }

    private void OnPointerDown()
    {
    }
    private void StartGameOnPointerDown()
    {
       
        fixedTouchField.pointerDown.RemoveListener(StartGameOnPointerDown);
    }
    public void UpdateInput()
    {
        if (canControl)
        {
            UpdateAndroidInput();
        }
    }
    private void UpdateAndroidInput()
    {
        if (fixedTouchField.IsPressed)
        {
            DistanceX = Mathf.Lerp(DistanceX, fixedTouchField.TouchDist.x, Time.deltaTime * 5f);
        }
        else
        {
            DistanceX = 0;
        }
    }
}