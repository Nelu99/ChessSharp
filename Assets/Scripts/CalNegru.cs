using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalNegru : MonoBehaviour {

	public int x,y;
	public int lvl = 1;
	public bool clicked = false;
	private Sprite lvl2;

	void Awake()
	{
		x = Mathf.Abs ((int)this.transform.position.y);
		y = Mathf.Abs ((int)this.transform.position.x);
		lvl2 = Resources.Load ("Bcal2", typeof(Sprite)) as Sprite;
	}

	void Update()
	{
		if (Input.GetMouseButton (0) == false && (clicked == true) && Matrice.turn == 2) 
		{
			clicked = false;
			this.transform.position = new Vector2 ((int)this.transform.position.x + 0.5f, ((int)this.transform.position.y - 0.5f));
			if (this.transform.position.x < 0 || this.transform.position.x > 8 || this.transform.position.y < (-8) || this.transform.position.y > 0 || Matrice.moves [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] < 1)
			{
				this.transform.position = new Vector2 (y + 0.5f, (-1) * x - 0.5f);
				Matrice.Clear ();
			}
			else if (Matrice.moves [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] == 1)
			{
				if (lvl == 1 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] > 10 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] != 0) {
					lvl = 2;
					this.GetComponent<SpriteRenderer> ().sprite = lvl2;
				}
				Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] = Matrice.board [x, y];
				Matrice.board [x, y] = 0;
				x = Mathf.Abs ((int)this.transform.position.y);
				y = Mathf.Abs ((int)this.transform.position.x);
				clicked = false;
				Matrice.Clear ();
				Matrice.turn = 1;
			} 
			else
			{
				this.transform.position = new Vector2 (y+0.5f, (-1)*x-0.5f);
				clicked = false;
				Matrice.Clear ();
			}
		}
		if (Matrice.board [x, y] > 10) {
			Destroy (this.gameObject);
			Matrice.alive [7]--;
		}
	}

	bool checkMove(int x1,int y1)
	{
		int lastPiece = Matrice.board [x1,y1];
		Matrice.board [x1,y1] = Matrice.board [x, y];
		Matrice.board [x, y] = 0;
		if (RegeNegru.TestDanger (RegeNegru.x, RegeNegru.y) == true) 
		{
			Matrice.board [x, y] = Matrice.board [x1,y1];
			Matrice.board [x1,y1] = lastPiece;
			return true;
		}
		else
		{
			Matrice.board [x, y] = Matrice.board [x1,y1];
			Matrice.board [x1,y1] = lastPiece;
			return false;
		}
	}

	public bool CheckMoves()
	{
		if (x - 2 >= 0 && y - 1 >= 0) {
			if ((Matrice.board [x - 2, y - 1] > 10 || Matrice.board [x - 2, y - 1] == 0) && Matrice.board [x - 2, y - 1] != 44 && Matrice.moves [x - 2, y - 1] != (-1) && checkMove (x - 2, y - 1) == false)
				return true;
		}
		if (x - 2 >= 0 && y + 1 <= 7) {
			if ((Matrice.board [x - 2, y + 1] > 10 || Matrice.board [x - 2, y + 1] == 0) && Matrice.board [x - 2, y + 1] != 44 && Matrice.moves [x - 2, y + 1] != (-1) && checkMove (x - 2, y + 1) == false)
				return true;
		}
		if (x + 2 <= 7 && y + 1 <= 7) {
			if ((Matrice.board [x + 2, y + 1] > 10 || Matrice.board [x + 2, y + 1] == 0) && Matrice.board [x + 2, y + 1] != 44 && Matrice.moves [x + 2, y + 1] != (-1) && checkMove (x + 2, y + 1) == false)
				return true;
		}
		if (x + 2 <= 7 && y - 1 >= 0) {
			if ((Matrice.board [x + 2, y - 1] > 10 || Matrice.board [x + 2, y - 1] == 0) && Matrice.board [x + 2, y - 1] != 44 && Matrice.moves [x + 2, y - 1] != (-1) && checkMove (x + 2, y - 1) == false)
				return true;
		}
		if (x - 1 >= 0 && y - 2 >= 0) {
			if ((Matrice.board [x - 1, y - 2] > 10 || Matrice.board [x - 1, y - 2] == 0) && Matrice.board [x - 1, y - 2] != 44 && Matrice.moves [x - 1, y - 2] != (-1) && checkMove (x - 1, y - 2) == false)
				return true;
		}
		if (x - 1 >= 0 && y + 2 <= 7) {
			if ((Matrice.board [x - 1, y + 2] > 10 || Matrice.board [x - 1, y + 2] == 0) && Matrice.board [x - 1, y + 2] != 44 && Matrice.moves [x - 1, y + 2] != (-1) && checkMove (x - 1, y + 2) == false)
				return true;
		}
		if (x + 1 <= 7 && y + 2 <= 7) {
			if ((Matrice.board [x + 1, y + 2] > 10 || Matrice.board [x + 1, y + 2] == 0) && Matrice.board [x + 1, y + 2] != 44 && Matrice.moves [x + 1, y + 2] != (-1) && checkMove (x + 1, y + 2) == false)
				return true;
		}
		if (x + 1 <= 7 && y - 2 >= 0) {
			if ((Matrice.board [x + 1, y - 2] > 10 || Matrice.board [x + 1, y - 2] == 0) && Matrice.board [x + 1, y - 2] != 44 && Matrice.moves [x + 1, y - 2] != (-1) && checkMove (x + 1, y - 2) == false)
				return true;
		}
		if (lvl == 2) {
			if (y - 2 >= 0) {
				if ((Matrice.board [x, y - 2] > 10 || Matrice.board [x, y - 2] == 0) && Matrice.board [x, y - 2] != 44 && Matrice.moves [x, y - 2] != (-1) && checkMove (x, y - 2) == false)
					return true;
			}
			if (y + 2 <= 7) {
				if ((Matrice.board [x, y + 2] > 10 || Matrice.board [x, y + 2] == 0) && Matrice.board [x, y + 2] != 44 && Matrice.moves [x, y + 2] != (-1) && checkMove (x, y + 2) == false)
					return true;
			}
			if (x + 2 <= 7) {
				if ((Matrice.board [x + 2, y] > 10 || Matrice.board [x + 2, y] == 0) && Matrice.board [x + 2, y] != 44 && Matrice.moves [x + 2, y] != (-1) && checkMove (x + 2, y) == false)
					return true;
			}
			if (x - 2 >= 0) {
				if ((Matrice.board [x - 2, y] > 10 || Matrice.board [x - 2, y] == 0) && Matrice.board [x - 2, y] != 44 && Matrice.moves [x - 2, y] != (-1) && checkMove (x - 2, y) == false)
					return true;
			}
		}
		return false;
	}

	public void OnMouseDown()
	{
		if (Matrice.turn == 2 && clicked == false) 
		{
			if (x - 2 >= 0 && y - 1 >= 0)
			{
				if ((Matrice.board [x - 2, y - 1] > 10 ||  Matrice.board [x - 2, y - 1] == 0) && Matrice.board [x - 2, y - 1] != 44 && Matrice.moves [x - 2, y - 1] != (-1) && checkMove (x - 2, y - 1) == false)
					Matrice.moves [x - 2, y - 1] = 1;
			}
			if (x - 2 >= 0 && y + 1 <= 7)
			{
				if ((Matrice.board [x - 2, y + 1] > 10 ||  Matrice.board [x - 2, y + 1] == 0) && Matrice.board [x - 2, y + 1] != 44 && Matrice.moves [x - 2, y + 1] != (-1) && checkMove (x - 2, y + 1) == false)
					Matrice.moves [x - 2, y + 1] = 1;
			}
			if (x + 2 <= 7 && y + 1 <= 7)
			{
				if ((Matrice.board [x + 2, y + 1] > 10 ||  Matrice.board [x + 2, y + 1] == 0) && Matrice.board [x + 2, y + 1] != 44 && Matrice.moves [x + 2, y + 1] != (-1) && checkMove (x + 2, y + 1) == false)
					Matrice.moves [x + 2, y + 1] = 1;
			}
			if (x + 2 <= 7 && y - 1 >= 0)
			{
				if ((Matrice.board [x + 2, y - 1] > 10 ||  Matrice.board [x + 2, y - 1] == 0) && Matrice.board [x + 2, y - 1] != 44 && Matrice.moves [x + 2, y - 1] != (-1) && checkMove (x + 2, y - 1) == false)
					Matrice.moves [x + 2, y - 1] = 1;
			}
			if (x - 1 >= 0 && y - 2 >= 0)
			{
				if ((Matrice.board [x - 1, y - 2] > 10 ||  Matrice.board [x - 1, y - 2] == 0) && Matrice.board [x - 1, y - 2] != 44 && Matrice.moves [x - 1, y - 2] != (-1) && checkMove (x - 1, y - 2) == false)
					Matrice.moves [x - 1, y - 2] = 1;
			}
			if (x - 1 >= 0 && y + 2 <= 7)
			{
				if ((Matrice.board [x - 1, y + 2] > 10 ||  Matrice.board [x - 1, y + 2] == 0) && Matrice.board [x - 1, y + 2] != 44 && Matrice.moves [x - 1, y + 2] != (-1) && checkMove (x - 1, y + 2) == false)
					Matrice.moves [x - 1, y + 2] = 1;
			}
			if (x + 1 <= 7 && y + 2 <= 7)
			{
				if ((Matrice.board [x + 1, y + 2] > 10 ||  Matrice.board [x + 1, y + 2] == 0) && Matrice.board [x + 1, y + 2] != 44 && Matrice.moves [x + 1, y + 2] != (-1) && checkMove (x + 1, y + 2) == false)
					Matrice.moves [x + 1, y + 2] = 1;
			}
			if (x + 1 <= 7 && y - 2 >= 0)
			{
				if ((Matrice.board [x + 1, y - 2] > 10 ||  Matrice.board [x + 1, y - 2] == 0) && Matrice.board [x + 1, y - 2] != 44 && Matrice.moves [x + 1, y - 2] != (-1) && checkMove (x + 1, y - 2) == false)
					Matrice.moves [x + 1, y - 2] = 1;
			}
			if (lvl == 2) 
			{
				if (y - 2 >= 0)
				{
					if ((Matrice.board [x, y - 2] > 10 ||  Matrice.board [x, y - 2] == 0) && Matrice.board [x, y - 2] != 44 && Matrice.moves [x, y - 2] != (-1) && checkMove (x, y - 2) == false)
						Matrice.moves [x, y - 2] = 1;
				}
				if (y + 2 <= 7)
				{
					if ((Matrice.board [x, y + 2] > 10 ||  Matrice.board [x, y + 2] == 0) && Matrice.board [x, y + 2] != 44 && Matrice.moves [x, y + 2] != (-1) && checkMove (x, y + 2) == false)
						Matrice.moves [x, y + 2] = 1;
				}
				if (x + 2 <= 7)
				{
					if ((Matrice.board [x + 2, y] > 10 ||  Matrice.board [x + 2 , y] == 0) && Matrice.board [x + 2, y] != 44 && Matrice.moves [x + 2, y] != (-1) && checkMove (x + 2, y) == false)
						Matrice.moves [x + 2, y] = 1;
				}
				if (x - 2 >= 0)
				{
					if ((Matrice.board [x - 2, y] > 10 ||  Matrice.board [x - 2, y] == 0) && Matrice.board [x - 2, y] != 44 && Matrice.moves [x - 2, y] != (-1) && checkMove (x - 2, y) == false)
						Matrice.moves [x - 2, y] = 1;
				}
			}

			clicked = true;
			Matrice.cloned = true;
		}
	}
}
