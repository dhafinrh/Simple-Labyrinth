using DG.Tweening;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup UIPanel;
    [SerializeField] private CanvasGroup Splash;
    [SerializeField] private float timer;
    private Tween fadeTween;
    bool gone = true;

    private void Awake()
    {
        Splash.alpha = 1;
        Splash.interactable = false;
        Splash.blocksRaycasts = true;

        UIPanel.alpha = 0;
        UIPanel.interactable = false;
        UIPanel.blocksRaycasts = false;
    }

    void Update()
    {
        if (timer > 0 && timer != 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (gone)
            {
                FadeMain(0, 0.4f);
                gone = false;
            }
        }
    }

    public void FadePanel(bool value)
    {
        if (value)
        {
            Fade(1f, 0.2f, value);
        }
        else
        {
            Fade(0f, 0.2f, value);
        }
    }

    private void FadeMain(float endValue, float duration)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }
        if (Splash != null)
        {
            fadeTween = Splash.DOFade(endValue, duration).OnComplete(() =>
                {
                    Splash.blocksRaycasts = false;
                }); ;
        }
        // fadeTween.Kill(complete: false);
    }

    private void Fade(float endValue, float duration, bool showUp)
    {
        if (showUp)
        {
            if (UIPanel != null)
            {
                UIPanel.DOFade(endValue, duration).OnComplete(() =>
                {
                    UIPanel.interactable = true;
                    UIPanel.blocksRaycasts = true;
                    fadeTween.Kill(false);
                });
            }
        }
        else
        {
            if (UIPanel != null)
            {
                UIPanel.DOFade(endValue, duration).OnComplete(() =>
                {
                    UIPanel.interactable = false;
                    UIPanel.blocksRaycasts = false;
                    fadeTween.Kill(false);
                });
            }
        }
    }
}
