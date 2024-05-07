using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleUI : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FillCircle()
    {
        var current = gameObject.GetComponent<UnityEngine.UI.Image>().fillAmount;
        if (current < 1.0f)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().fillAmount += 0.1f;
        }
        else
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().fillAmount = 0.0f;
        }
    }
}
