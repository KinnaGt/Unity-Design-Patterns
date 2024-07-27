using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Subject subjectToObserve;

    [SerializeField]
    TextMeshProUGUI lifeValue;

    private void OnThingHappened(float life)
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            return;
        }
        lifeValue.text = "" + life;
        Debug.Log("Observer responds");
    }

    private void Awake()
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.ThingHappened += OnThingHappened;
        }
    }

    private void OnDestroy()
    {
        if (subjectToObserve != null)
        {
            subjectToObserve.ThingHappened -= OnThingHappened;
        }
    }
}
