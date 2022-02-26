using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField] private ScreenFade screenFade;

    static public CustomSceneManager instance;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
        }

        DontDestroyOnLoad(gameObject);
    }

    public void GoToScene(string sceneName)
    {
        StartCoroutine(GoToSceneRoutine(sceneName));
    }

    IEnumerator GoToSceneRoutine(string sceneName)
    {
        if (screenFade == null) { screenFade = GameObject.Find("ScreenFade").GetComponent<ScreenFade>(); } //fix screen fade reference by finding it in current scene

        screenFade.FadeOut();
        yield return new WaitForSeconds(screenFade.fadeDuration);

        //Launch loading scene
        SceneManager.LoadScene("LoadingScene");

        yield return new WaitForSeconds(3); //<--manually waits in load scene for 3 seconds before starting to load the next scene

        screenFade = GameObject.Find("ScreenFade").GetComponent<ScreenFade>(); //fix screen fade reference by finding it in loading scene

        //Load new scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float timer = 0;
        while (timer <= screenFade.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
