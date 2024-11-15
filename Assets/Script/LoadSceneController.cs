using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadSceneController : MonoBehaviour
{
    private static LoadSceneController instance;

    public static LoadSceneController Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = FindObjectOfType<LoadSceneController>();
                if(obj != null)
                {
                    instance = obj;
                }
                else
                {
                    instance = Creat();
                }
            }
            return instance;
        }
    }

    private static LoadSceneController Creat()
    {
        return Instantiate(Resources.Load<LoadSceneController>("LoadingUI"));
    }

    void Awake()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private CanvasGroup canvasGroup;

    private string loadSceneName;

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;
        loadSceneName = sceneName;
        StartCoroutine(LoadSceneProcess());
    }

    private IEnumerator LoadSceneProcess()
    {
        yield return StartCoroutine(Fade(true));

        AsyncOperation op = SceneManager.LoadSceneAsync(loadSceneName);
        op.allowSceneActivation = false;

        while(!op.isDone)
        {
            yield return null;
            if(op.progress == 0.9f)
            {
                yield return new WaitForSeconds(2f);
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.name == loadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;
        while(timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 3f;
            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);
        }

        if(!isFadeIn)
        {
            gameObject.SetActive(false);
        }    
    }
}
