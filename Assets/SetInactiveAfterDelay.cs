using UnityEngine;
using System.Collections;

public class SetInactiveAfterDelay : MonoBehaviour
{
    [SerializeField] private float delay = 3f; // عدد الثواني قبل ما يتعطل

    private void Start()
    {
        StartCoroutine(DisableAfterSeconds());
    }

    private IEnumerator DisableAfterSeconds()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
