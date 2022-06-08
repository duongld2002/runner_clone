using UnityEngine;
using UnityEngine.UI;

public class TestMovement : MonoBehaviour
{
    //Hanlde move foward and run animation
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    PlayerManager playerManager;

    public GameObject gameObjectImg, gameObjectSetting;
    public FixedTouchField fixedTouchField;

    public Animator[] animators;

    public void Update()
    {
        animators = GetComponentsInChildren<Animator>();
        if (fixedTouchField.IsPressed)
        {
            //playerManager.playerState = PlayerManager.PlayerState.Run;

            EffectManager.Instance.runSoundOn();

            gameObjectImg.SetActive(false);
            gameObjectSetting.SetActive(false);
            transform.position += Vector3.forward * speed * Time.deltaTime;
           
            foreach (Animator animator in animators)
            {
                animator.SetBool("IsRun", true);
            }
        } else
        {
            //playerManager.playerState = PlayerManager.PlayerState.Idle;

            EffectManager.Instance.runSoundOff();

            foreach (Animator animator in animators)
            {
                animator.SetBool("IsRun", false);
            }
        }
    }

}
