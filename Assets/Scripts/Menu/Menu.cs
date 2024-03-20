using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public RectTransform rectTransform;
    bool mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = true;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rectTransform.anchoredPosition.y >= 15)
        {
            mover = true;
        }
        else if (rectTransform.anchoredPosition.y <= -15)
        {
            mover = false;
        }

        if (mover)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 0.1f);
        }
        if (!mover)
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 0.1f);
    }
    
}
