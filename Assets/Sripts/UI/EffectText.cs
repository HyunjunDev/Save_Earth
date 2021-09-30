using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EffectText : MonoBehaviour
{
    private Text touchText = null;

    public void Show(int number)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        touchText = GetComponent<Text>();
        touchText.text = string.Format("+{0}", number);
        touchText.DOFade(0f, 0.5f).OnComplete(() => Despawn());
        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 100f;
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);
    }
    private void Despawn()
    {
        touchText.DOFade(1f, 0f);
        touchText.transform.SetParent(GameManager.Instance.Pool);
        touchText.gameObject.SetActive(false);
    }
}
