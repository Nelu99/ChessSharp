using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag : MonoBehaviour {

	public string team;
	private bool dragging = false;
	private float distance;
	void OnMouseDown()
	{
		if ((team == "alb" && Matrice.turn == 1 || team == "negru" && Matrice.turn == 2 ) && !Recruit.active)
		{
			distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			this.transform.localScale -= new Vector3 (0.1f, 0.1f, 0f);
			GetComponent<Renderer> ().sortingOrder++;
			dragging = true;
		}
	}

	void OnMouseUp()
	{
		if ((team == "alb" && Matrice.turn == 1 || team == "negru" && Matrice.turn == 2 ) && !Recruit.active)
		{
			this.transform.localScale += new Vector3 (0.1f, 0.1f, 0f);
			GetComponent<Renderer> ().sortingOrder--;
			dragging = false;
		}
	}

	void Update()
	{
		if (dragging && (team == "alb" && Matrice.turn == 1  || team == "negru" && Matrice.turn == 2))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
}