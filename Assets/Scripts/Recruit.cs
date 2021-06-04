using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruit : MonoBehaviour
{
    public static int recr;
    public static bool active;
    public static int updated;
    public static string team;
    float speed = 15, total = 0;

    private void FixedUpdate()
    {
        if (recr != 0)
        {
            if (!active)
                active = true;
            transform.Translate(0f, recr * speed, 0f);
            total += speed;
            speed += .5f;
            if (total >= 875)
            {
                total = 0;
                recr = 0;
                speed = 15;
                active = false;
            }
        }
    }
    void Start()
    {
        team = "";
        updated = 4;
        recr = 0;
    }
    
}