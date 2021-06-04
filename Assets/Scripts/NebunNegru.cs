using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebunNegru : MonoBehaviour {

	public int x,y;
	public int lvl = 1;
	public bool clicked = false;
	private Sprite lvl2;

	void Awake()
	{
		x = Mathf.Abs ((int)this.transform.position.y);
		y = Mathf.Abs ((int)this.transform.position.x);
		lvl2 = Resources.Load ("Bnebun2", typeof(Sprite)) as Sprite;
	}

	void Update () 
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
			Matrice.alive [6]--;
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
		int m = x, n = y;

		while (m <= 7 && n >= 0) {
			m++;
			n--;
			if (m <= 7 && n >= 0) {
				if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					return true;
				else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] != 0 && (Matrice.board [m, n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
					break;
			}
		}
		m = x;
		n = y;
		while (m <= 7 && n <= 7) {
			m++;
			n++;
			if (m <= 7 && n <= 7) {
				if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					return true;
				else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] != 0 && (Matrice.board [m, n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
					break;
			}
		}
		m = x;
		n = y;
		while (m >= 0 && n >= 0) {
			m--;
			n--;
			if (m >= 0 && n >= 0) {
				if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					return true;
				else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] != 0 && (Matrice.board [m, n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
					break;
			}
		}
		m = x;
		n = y;
		while (m >= 0 && n <= 7) {
			m--;
			n++;
			if (m >= 0 && n <= 7) {
				if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					return true;
				else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] != 0 && (Matrice.board [m, n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
					break;
			}
		}
		if (lvl == 2 && (y - 1 >= 0) && (y + 1 <= 7) && Matrice.moves [x, y - 1] != (-1) && Matrice.moves [x, y + 1] != (-1)) {
			if (Matrice.board [x, y - 1] == 0 && checkMove (x, y - 1) == false)
				return true;
			if (Matrice.board [x, y + 1] == 0 && checkMove (x, y + 1) == false)
				return true;
		}
		return false;
	}

	public void OnMouseDown()
	{
		if (Matrice.turn == 2 && clicked == false) 
		{
			int m = x, n = y;

			while (m <= 7 && n >= 0) 
			{
				m++;n--;
				if (m <= 7 && n >= 0) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					{
						Matrice.moves [m, n] = 1;
						break;
					}
					else if (Matrice.board[m,n]!=0 && (Matrice.board [m,n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board[m,n]==4 || Matrice.board[m,n]==44))
						break;
				}
			}
			m = x;n = y;
			while (m <= 7 && n <= 7) 
			{
				m++;n++;
				if (m <= 7 && n <= 7) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) 
					{
						Matrice.moves [m, n] = 1;
						break;
					}
					else if (Matrice.board[m,n]!=0 && (Matrice.board [m,n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board[m,n]==4 || Matrice.board[m,n]==44))
						break;
				}
			}
			m = x;n = y;
			while (m >= 0 && n >= 0) 
			{
				m--;n--;
				if (m >= 0 && n >= 0) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					{
						Matrice.moves [m, n] = 1;
						break;
					} 
					else if (Matrice.board[m,n]!=0 && (Matrice.board [m,n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board[m,n]==4 || Matrice.board[m,n]==44))
						break;
				}
			}
			m = x;n = y;
			while (m >= 0 && n <= 7) 
			{
				m--;n++;
				if (m >= 0 && n <= 7) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					{
						Matrice.moves [m, n] = 1;
						break;
					}
					else if (Matrice.board[m,n]!=0 && (Matrice.board [m,n] < 10 || Matrice.moves [m, n] == (-1) || Matrice.board[m,n]==4 || Matrice.board[m,n]==44))
						break;
				}
			}
			if (lvl == 2 && (y - 1 >= 0) && (y + 1 <= 7) && Matrice.moves [x, y - 1] != (-1) && Matrice.moves [x, y + 1] != (-1)) 
			{
				if (Matrice.board [x, y - 1] == 0 && checkMove (x, y - 1) == false)
					Matrice.moves [x, y - 1] = 1;
				if (Matrice.board [x, y + 1] == 0 && checkMove (x, y + 1) == false)
					Matrice.moves [x, y + 1] = 1;
			}
			clicked = true;
			Matrice.cloned = true;
		}
	}
}
