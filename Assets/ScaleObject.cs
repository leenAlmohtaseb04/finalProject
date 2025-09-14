using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    [Header("Target Object")]
    public Transform target;

    [Header("Scale Settings")]
    public float scaleFactor = 2f; // قدّيش بدك تكبير
    public float duration = 1f;    // وقت التكبير (ثواني)

    private Vector3 initialScale;
    private Vector3 targetScale;
    private float timer;
    private bool isScaling;

    void Start()
    {
        if (target == null) target = transform;
        initialScale = target.localScale;
        targetScale = initialScale * scaleFactor;
    }

    void Update()
    {
        // كبسة Space للتكبير
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = 0f;
            isScaling = true;
        }

        if (isScaling)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            target.localScale = Vector3.Lerp(initialScale, targetScale, t);

            if (t >= 1f) isScaling = false;
        }
    }
}
