using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class controlmuscle : MonoBehaviour
{


    public GameObject OtharGameObject;
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);

    }


    private void OnSelectEntered(SelectEnterEventArgs args)
    {

        if (grabInteractable != null)
        {
            {
                OtharGameObject.SetActive(false);


            }

        }
        }

        private void OnSelectExited(SelectExitEventArgs args)
        { if (grabInteractable != null)
            {
                OtharGameObject.SetActive(true);

            } }





        void OnDestroy()
        {
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.RemoveListener(OnSelectEntered);


            }
        }




            }


