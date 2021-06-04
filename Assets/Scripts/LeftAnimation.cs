using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAnimation : MonoBehaviour
{
    public int anim = 0;
    float speed = 15, total = 0;

    private void FixedUpdate()
    {
        if (anim != 0)
        {   
            transform.Translate(anim*speed, 0f, 0f);
            total += speed;
            speed += 1f;
            if (total >= 875)
            {
                total = 0;
                anim = 0;
                speed = 15;
            }
        }
    }
}
