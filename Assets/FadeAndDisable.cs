using UnityEngine;
using System.Collections;

public class FadeAndDisableUI : MonoBehaviour
{
    [SerializeField] private float delayBeforeFade = 1f;
    [SerializeField] private float fadeDuration = 2f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1f; // تأكد إنها تبدأ مرئية
    }

    public void StartFade()
    {
        StopAllCoroutines(); // احتياط لو انطلب الفيد أكثر من مرة
        StartCoroutine(FadeOutAndDisable());
    }

    private IEnumerator FadeOutAndDisable()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(1f - (elapsed / fadeDuration)); // يحافظ على [0,1]
            canvasGroup.alpha = alpha;
            yield return null;
        }

        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }
}
