using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public Animator transitionAnim;
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        //transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

}
