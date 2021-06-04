using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

	public string gamemode;
    public int anim = 0;
    float speed = 10, total = 0;
    public AudioSource tap;

    public void playTap()
    {   
        tap.Play(0);
    }
    private void FixedUpdate()
    {
        if (gamemode == "")
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
    }
    public void OnMouseDown()
	{
		if (gamemode == "PVP")
			SceneManager.LoadScene ("Chess");
		else if (gamemode == "Single")
			SceneManager.LoadScene ("ChessSingle");
        else
            SceneManager.LoadScene("MainMenu");
    }
}
