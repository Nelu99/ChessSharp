using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimUpOnWake : MonoBehaviour
{
    bool anim = false;
    public float speed = 10;
    float total = 0;
    public int distance;

    void Start()
    {
        anim = true;
    }

    private void Update()
    {
        if (anim)
        {
            transform.Translate(0f, speed, 0f);
            total += speed;
            speed += .5f;
            if (total >= distance)
            {
                total = 0;
                anim = false;
                speed = 10;
            }
        }
    }
}
