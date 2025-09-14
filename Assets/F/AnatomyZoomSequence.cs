using UnityEngine;
using System.Collections;

public class AnatomyZoomSequence : MonoBehaviour
{
    [Header("Cameras")]
    public Camera xrCamera;
   // public Camera zoomCamera;        // للخطوة الثانية
    public Camera innerZoomCamera;   // للخطوة الخامسة

    [Header("Layers")]
    public GameObject Default;

    [Header("Muscles Sequence")]
    public GameObject[] muscles; // [0] = أول عضلة, [1] = أول داخلية, [2] = ثانية داخلية, [3] = ثالثة داخلية

    private int step = 0;

    void Start()
    {
        ResetSequence();
    }

    public void NextStep()
    {
        step++;

        switch (step)
        {
            case 1:
                // أول كبسة: بين الجسم
                if (Default != null) Default.SetActive(true);
                xrCamera.enabled = true;
               // zoomCamera.enabled = false;
                if (innerZoomCamera != null) innerZoomCamera.enabled = false;
                break;

            case 2:
                // كبسة تانية: زوم على العضلة
                if (Default != null) Default.SetActive(false);

               // xrCamera.enabled = false;
               // zoomCamera.enabled = true;
            // if (innerZoomCamera != null) innerZoomCamera.enabled = false;

                if (muscles.Length > 0 && muscles[0] != null)
                    muscles[0].SetActive(true);

               //  🔥 بعد ثانيتين رجع للـ XR
               //StartCoroutine(ReturnToXR(1f));
               break;

            case 3:
                // كبسة ثالثة: العضلة الداخلية الأولى
                if (muscles.Length > 0 && muscles[0] != null)
                    muscles[0].SetActive(false);

                if (muscles.Length > 1 && muscles[1] != null)
                    muscles[1].SetActive(true);
                break;

            case 4:
                // كبسة رابعة: العضلة الداخلية الثانية
                if (muscles.Length > 1 && muscles[1] != null)
                    muscles[1].SetActive(false);

                if (muscles.Length > 2 && muscles[2] != null)
                    muscles[2].SetActive(true);
                break;

            case 5:
                // كبسة خامسة: العضلة الداخلية الثالثة + الكاميرا التانية
                if (muscles.Length > 2 && muscles[2] != null)
                    muscles[2].SetActive(false);

                if (muscles.Length > 3 && muscles[3] != null)
                    muscles[3].SetActive(true);

                xrCamera.enabled = false;
               // zoomCamera.enabled = false;
                if (innerZoomCamera != null) innerZoomCamera.enabled = true;

                // 🔥 بعد 10 ثواني رجع للـ XR
                StartCoroutine(ReturnToXR(10f));
                break;

            default:
                ResetSequence();
                break;
        }
    }

    IEnumerator ReturnToXR(float delay)
    {
        yield return new WaitForSeconds(delay);

        xrCamera.enabled = true;
       // zoomCamera.enabled = false;
        if (innerZoomCamera != null) innerZoomCamera.enabled = false;
    }

    void ResetSequence()
    {
        step = 0;

        xrCamera.enabled = true;
       // zoomCamera.enabled = false;
        if (innerZoomCamera != null) innerZoomCamera.enabled = false;

        if (Default != null) Default.SetActive(false);

        foreach (var m in muscles)
            if (m != null) m.SetActive(false);
    }
}
