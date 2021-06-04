using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOver : MonoBehaviour
{
    public static bool anim = false;
    public static bool active = false;
    float speed = 15, total = 0;

    private void FixedUpdate()
    {
        if (anim)
        {
            if (!active)
                active = true;
            transform.Translate(0f, speed, 0f);
            total += speed;
            speed += .5f;
            if (total >= 875)
            {
                total = 0;
                anim = false;
                speed = 10;
            }
        }
    }
}
