using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnim : MonoBehaviour
{
    RectTransform transf;
    int anim = 1;

    void Start()
    {
        transf = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        transf.localScale = new Vector3(transf.localScale.x + anim * 0.001f, transf.localScale.y + anim * 0.001f, 1f);
        if (transf.localScale.x >= 6.1f)
            anim = -1;
        if (transf.localScale.x <= 6f)
            anim = 1;
    }
}
