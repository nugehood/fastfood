using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class awakeLoadScene : MonoBehaviour
{
    public string sceneName;
    public float time;
    private void Awake()
    {
        StartCoroutine(loadOnSeconds(time));
    }

    IEnumerator loadOnSeconds(float delay)
    {
       
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
