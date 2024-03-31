using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    [SerializeField] private Material transitionMaterial;
    [SerializeField] private float speed;
    [SerializeField] private Ease easing;
    [SerializeField] private bool debug;

    private void Update()
    {
        if(debug && Input.GetKeyDown(KeyCode.Space))
            StartTransition("Tutorial1");
    }

    public void StartTransition(string sceneName)
    {
        transitionMaterial.DOFloat(0f, "_Value", speed).SetEase(easing).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
            transitionMaterial.DOFloat(0.5f, "_Value", speed).SetEase(easing);
        });
    }
    
    public void StartTransition(int buildIndex)
    {
        transitionMaterial.DOFloat(0f, "_Value", speed).SetEase(easing).OnComplete(() =>
        {
            SceneManager.LoadScene(buildIndex);
            transitionMaterial.DOFloat(0.5f, "_Value", speed).SetEase(easing);
        });
    }
    
    public void StartTransitionQuit()
    {
        transitionMaterial.DOFloat(0f, "_Value", speed).SetEase(easing).OnComplete(Application.Quit);
    }
}
