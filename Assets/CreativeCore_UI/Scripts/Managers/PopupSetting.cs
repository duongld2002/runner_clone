using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupSetting : MonoBehaviour
{
    public GameObject popup;
    public CanvasGroup canvasGroup;
    public Image soundToggle;
    //public Image vibrationToggle;
    private void OnEnable()
    {
        popup.transform.localScale = Vector3.one * 0.6f;
        canvasGroup.alpha = 0f;
        DOTween.To(() => { return canvasGroup.alpha; }, (a) => { canvasGroup.alpha = a; }, 1f, 0.35f);
        popup.transform.DOScale(Vector3.one, 0.35f).SetEase(Ease.OutBounce);
    }
    public void Close()
    {
        canvasGroup.alpha = 1f;
        DOTween.To(() => { return canvasGroup.alpha; }, (a) => { canvasGroup.alpha = a; }, 0f, 0.2f);
        popup.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
    public void TurnSound()
    {
        //DataManager.Instance.TurnSound();
        //soundToggle.gameObject.SetActive(DataManager.Instance.IsOnSound());
    }
}
