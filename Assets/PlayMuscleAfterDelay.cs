using UnityEngine;
using System.Collections;

public class PlayMuscleAfterDelay : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string triggerName = "ShowMuscle";
    [SerializeField] private float delaySeconds = 2f; // الوقت قبل تشغيل الأنيميشن

    private void Start()
    {
        StartCoroutine(DelayedAnimation());
    }

    private IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(delaySeconds);

        if (animator != null)
        {
            animator.SetTrigger(triggerName);
            Debug.Log("Animation Triggered after " + delaySeconds + " seconds.");
        }
        else
        {
            Debug.LogWarning("Animator not assigned!");
        }
    }
}
