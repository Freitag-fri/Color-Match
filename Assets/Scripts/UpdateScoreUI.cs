using DG.Tweening;
using UnityEngine;
using TMPro;

public class UpdateScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _changedScoreText;

    public void StartAnimation(string text)
    {
        _changedScoreText.gameObject.SetActive(true);
        _changedScoreText.text = text;
        _changedScoreText.transform
            .DOMoveY(0.4f, 0.8f)
            .SetEase(Ease.InOutQuad)
            .OnComplete(() => Destroy(gameObject));
    }
}
