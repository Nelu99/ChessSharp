using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInfo : MonoBehaviour {

    public bool isEnabled = false;
    public GameObject infos;
    public int anim = 0;
    float speed = 10, total = 0;

    private void FixedUpdate()
    {
        if (anim != 0)
        {
            transform.Translate(0f, anim * speed, 0f);
            total += speed;
            speed += .5f;
            if (total >= 550)
            {
                total = 0;
                anim = 0;
                speed = 10;
            }
        }
    }
    public void OnMouseDown()
    {
        if (infos.GetComponent<LeftAnimation>().anim == 0)
        {
            if (isEnabled == false)
            {
                infos.GetComponent<LeftAnimation>().anim = 1;
                isEnabled = true;
                Matrice.info = true;
            }
            else if (isEnabled == true)
            {
                infos.GetComponent<LeftAnimation>().anim = -1;
                isEnabled = false;
                Matrice.info = false;
            }
        }
    } 
}
