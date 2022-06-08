using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Texture collectedTexture;
    public PlayerState playerState;
    public LevelState levelState;

    public List<GameObject> collidedList;

    public Transform collectedPoolTransform;
    public enum PlayerState
    {
        Idle,
        Run
    }

    public enum LevelState
    {
        NotFinished,
        Finished
    }
}
