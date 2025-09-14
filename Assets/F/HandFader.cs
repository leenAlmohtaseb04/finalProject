using UnityEngine;
using System.Collections;

public class HandFader : MonoBehaviour
{
    [Header("Fade Settings")]
    public float fadeDuration = 2f; // الوقت (بالثواني) لحتى تختفي اليد
    private Material[] materials;

    void Start()
    {
        // خزن كل المواد تبع الموديل
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        int count = 0;
        foreach (var r in renderers) count += r.materials.Length;

        materials = new Material[count];
        int i = 0;
        foreach (var r in renderers)
        {
            foreach (var m in r.materials)
            {
                materials[i] = m;
                i++;
            }
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        Color[] startColors = new Color[materials.Length];

        for (int i = 0; i < materials.Length; i++)
            startColors[i] = materials[i].color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

            for (int i = 0; i < materials.Length; i++)
            {
                Color c = startColors[i];
                c.a = alpha;
                materials[i].color = c;
            }

            yield return null;
        }

        // أخفي اليد بالكامل بعد ما تصير شفافة
        gameObject.SetActive(false);
    }
}
