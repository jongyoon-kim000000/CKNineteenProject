using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class UITweenAnimator : MonoBehaviour
{
    public enum StopActionType
    {
        None,
        Disable,
        Destroy,
    }

    private Vector3 originPosition;
    private Quaternion originRotation;
    private Vector3 originScale;

    public List<UIAnimationData> animationList;
    [SerializeField]
    private UnityEvent endEvent;

    private List<Tween> playTweenList = new List<Tween>();
    private Coroutine animationCoroutine;

    public StopActionType stopActionType;

    [SerializeField]
    private bool autoActiveByPlay = false;
    [SerializeField]
    private bool autoStartPlay = false;
    [SerializeField]
    private bool resetOriginTransformByStop = false;

    private void Start()
    {
        if (autoStartPlay)
            PlayAnimation();
    }

    [Button("Play")]
    public virtual void PlayAnimation()
    {
        PlayAnimation(animationList, null);
    }

    public virtual void PlayAnimation(UnityAction completeEvent)
    {
        PlayAnimation(animationList, completeEvent);
    }

    public virtual void PlayAnimation(List<UIAnimationData> animations, UnityAction completeEvent = null)
    {
        if (resetOriginTransformByStop)
        {
            originPosition = transform.position;
            originRotation = transform.localRotation;
            originScale = transform.localScale;
        }

        playTweenList.Clear();

        if (autoActiveByPlay)
            gameObject.SetActive(true);

        for (var i = 0; i < animations.Count; ++i)
        {
            var animationData = animations[i];
            Tween tween = null;
            switch (animationData.AnimationType)
            {
                case UIAnimationType.Move:
                    tween = transform.DOLocalMove(animationData.DestinationVector, animationData.Duration);
                    break;
                case UIAnimationType.Rotate:
                    tween = transform.DOLocalRotate(animationData.DestinationVector, animationData.Duration);
                    break;
                case UIAnimationType.Scale:
                    tween = transform.DOScale(animationData.DestinationVector, animationData.Duration);
                    break;
                case UIAnimationType.Color:
                    tween = GetComponent<Graphic>()?.DOColor(animationData.DestinationColor, animationData.Duration);
                    break;
                case UIAnimationType.Alpha:
                    tween = GetComponent<CanvasGroup>()?.DOFade(animationData.DestinationFloat, animationData.Duration);
                    break;
            }

            if (animationData.LoopCount > 0)
            {
                tween.SetLoops(animationData.LoopCount, animationData.LoopType);
            }

            playTweenList.Add(tween);
            tween.SetDelay(animationData.Delay);
            tween.SetEase(animationData.EaseType);
            tween.OnComplete(() => { playTweenList.Remove(tween); });
            tween.SetRelative(animationData.IsRelative);
            tween.Play();
        }

        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        animationCoroutine = StartCoroutine(CoWaitCompleteAnimation(completeEvent));
    }

    public void Stop()
    {
        for (var i = 0; i < playTweenList.Count; ++i)
        {
            playTweenList[i].Kill();
        }

        playTweenList.Clear();

        if (resetOriginTransformByStop)
        {
            ResetOrigin();
        }
    }

    private void ResetOrigin()
    {
        transform.position = originPosition;
        transform.localRotation = originRotation;
        transform.localScale = originScale;
    }

    private IEnumerator CoWaitCompleteAnimation(UnityAction completeEvent)
    {
        while (playTweenList.Count > 0)
        {
            yield return null;
        }

        completeEvent?.Invoke();
        AutoHide();
        animationCoroutine = null;
    }

    public void AutoHide()
    {
        endEvent?.Invoke();

        switch (stopActionType)
        {
            case StopActionType.Disable:
                gameObject.SetActive(false);
                break;
            case StopActionType.Destroy:
                Destroy(gameObject);
                break;
            default: break;
        }
    }
}
