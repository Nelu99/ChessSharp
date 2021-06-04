using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInstrumente : MonoBehaviour {

	public bool isEnabled=false;
    public GameObject info, menu;
    public void OnMouseDown()
    {
        if (info.GetComponent<ClickInfo>().anim == 0 && !Matrice.info)
        {
            if (isEnabled == false)
            {
                info.GetComponent<ClickInfo>().anim = 1;
                menu.GetComponent<Play>().anim = 1;
                isEnabled = true;
            }
            else if (isEnabled == true)
            {
                info.GetComponent<ClickInfo>().anim = -1;
                menu.GetComponent<Play>().anim = -1;
                isEnabled = false;
            }
        }
    }
}
