using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectLose;

    public void ReplayGame()
    {
        SceneManager.LoadScene("StickyScene");
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Transform>().Length <= 2)
        {
            gameObjectLose.SetActive(true);
        }


    }
}
