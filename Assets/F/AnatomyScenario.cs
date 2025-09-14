using UnityEngine;

public class AnatomyScenario : MonoBehaviour
{
    [Header("Layers")]
    public GameObject bodyLayer;      // الجسم الخارجي
    public GameObject muscleLayer;    // العضلات
   // public GameObject innerLayer;     // الأعضاء/العظام الداخلية

    private int step = 0;

    public void NextStep()
    {
        step++;

        switch (step)
        {
            case 1: // من الجسم → للعضلات
               if (bodyLayer != null) bodyLayer.SetActive(false);
                if (muscleLayer != null) muscleLayer.SetActive(true);
                break;

            case 2: // من العضلات → للأعضاء الداخلية
                if (muscleLayer != null) muscleLayer.SetActive(false);
              //  if (innerLayer != null) innerLayer.SetActive(true);
                break;

            default:
                // رجّع كلشي
              if (bodyLayer != null) bodyLayer.SetActive(true);
                if (muscleLayer != null) muscleLayer.SetActive(false);
              //  if (innerLayer != null) innerLayer.SetActive(false);
                step = 0;
                break;
        }
    }
}
