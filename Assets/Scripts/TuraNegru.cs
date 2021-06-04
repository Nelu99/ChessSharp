using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuraNegru : MonoBehaviour {

	public int x,y;
	private int bombx,bomby;
	public int lvl = 1;
	public bool clicked=false;
	private Sprite lvl2;

	void Awake()
	{
		x = Mathf.Abs ((int)this.transform.position.y);
		y = Mathf.Abs ((int)this.transform.position.x);
		lvl2 = Resources.Load ("Btura2", typeof(Sprite)) as Sprite;
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
				if(lvl==2)
					Matrice.moves [bombx, bomby] = 0;
				if (lvl == 2)
				{
					Matrice.moves [x, y] = (-1);
					bombx = x;
					bomby = y;
					GameObject bomb =
						Instantiate (GameObject.Find ("Bomb"),
							new Vector3 (y + 0.5f, (-1) * x - 0.5f, 0f),
							Quaternion.identity) as GameObject;
					bomb.tag = "clone";
				}
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
		if (Matrice.board [x, y] > 10) 
		{
			Matrice.moves [bombx, bomby] = 0;
			Matrice.Clear ();
			Destroy (this.gameObject);
			Matrice.alive [5]--;
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
		if (y != 7)
			for (int i = y + 1; i <= 7; i++) {
				if (Matrice.board [x, i] == 0 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false)
					return true;
				else if (Matrice.board [x, i] > 10 && Matrice.board [x, i] != 44 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false) {
					return true;
				} else if (Matrice.board [x, i] != 0 && (Matrice.board [x, i] < 10 || Matrice.moves [x, i] == (-1) || Matrice.board [x, i] == 44 || Matrice.board [x, i] == 4))
					break;
			}
		if (y != 0)
			for (int i = y - 1; i >= 0; i--) {
				if (Matrice.board [x, i] == 0 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false)
					return true;
				else if (Matrice.board [x, i] > 10 && Matrice.board [x, i] != 44 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false) {
					return true;
				} else if (Matrice.board [x, i] != 0 && (Matrice.board [x, i] < 10 || Matrice.moves [x, i] == (-1) || Matrice.board [x, i] == 44 || Matrice.board [x, i] == 4))
					break;
			}
		if (x != 7)
			for (int i = x + 1; i <= 7; i++) {
				if (Matrice.board [i, y] == 0 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false)
					return true;
				else if (Matrice.board [i, y] > 10 && Matrice.board [i, y] != 44 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false) {
					return true;
				} else if (Matrice.board [i, y] != 0 && (Matrice.board [i, y] < 10 || Matrice.moves [i, y] == (-1) || Matrice.board [i, y] == 44 || Matrice.board [i, y] == 4))
					break;
			}
		if (x != 0)
			for (int i = x - 1; i >= 0; i--) {
				if (Matrice.board [i, y] == 0 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false)
					return true;
				else if (Matrice.board [i, y] > 10 && Matrice.board [i, y] != 44 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false) {
					return true;
				} else if (Matrice.board [i, y] != 0 && (Matrice.board [i, y] < 10 || Matrice.moves [i, y] == (-1) || Matrice.board [i, y] == 44 || Matrice.board [i, y] == 4))
					break;
			}
		return false;
	}

	public void OnMouseDown()
	{
		if (Matrice.turn == 2 && clicked == false)
		{
			if (y != 7)
				for (int i = y + 1; i <= 7; i++)
				{
					if (Matrice.board [x, i] == 0 && Matrice.moves [x , i] != (-1) && checkMove(x, i) == false)
						Matrice.moves [x, i] = 1;
					else if (Matrice.board [x, i] > 10 && Matrice.board [x, i] != 44 && Matrice.moves [x , i] != (-1) && checkMove(x, i) == false) 
					{
						Matrice.moves [x, i] = 1;
						break;
					} 
					else if (Matrice.board[x,i]!=0 && (Matrice.board [x, i] < 10 || Matrice.moves [x , i] == (-1) || Matrice.board[x,i]==44 || Matrice.board[x,i]==4))
						break;
				}
			if (y != 0)
				for (int i = y - 1; i >= 0; i--)
				{
					if (Matrice.board [x, i] == 0 && Matrice.moves [x , i] != (-1) && checkMove(x, i) == false)
						Matrice.moves [x, i] = 1;
					else if (Matrice.board [x, i] > 10 && Matrice.board [x, i] != 44 && Matrice.moves [x , i] != (-1) && checkMove(x, i) == false) 
					{
						Matrice.moves [x, i] = 1;
						break;
					} 
					else if (Matrice.board[x,i]!=0 && (Matrice.board [x, i] < 10 || Matrice.moves [x , i] == (-1) || Matrice.board[x,i]==44 || Matrice.board[x,i]==4))
						break;
				}
			if (x != 7)
				for (int i = x + 1; i <= 7; i++)
				{
					if (Matrice.board [i, y] == 0 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false)
						Matrice.moves [i, y] = 1;
					else if (Matrice.board [i, y] > 10 && Matrice.board [i, y] != 44 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false) {
						Matrice.moves [i, y] = 1;	
						break;
					} 
					else if (Matrice.board[i,y]!=0 && (Matrice.board [i, y] < 10 || Matrice.moves [i, y] == (-1) || Matrice.board [i, y] == 44 || Matrice.board [i, y] == 4))
						break;
				}
			if (x != 0)
				for (int i = x - 1; i >= 0; i--)
				{
					if (Matrice.board [i, y] == 0 && Matrice.moves [i , y] != (-1) && checkMove(i, y) == false)
						Matrice.moves [i, y] = 1;
					else if (Matrice.board [i, y] > 10 && Matrice.board [i, y] != 44 && Matrice.moves [i, y] != (-1) && checkMove(i, y) == false) 
					{
						Matrice.moves [i, y] = 1;
						break;
					} 
					else if (Matrice.board[i,y]!=0 && (Matrice.board [i, y] < 10 || Matrice.moves [i,y] == (-1) || Matrice.board[i,y]==44 || Matrice.board[i,y]==4))
						break;
				}
			clicked = true;
			Matrice.cloned = true;
		}
	}
}
