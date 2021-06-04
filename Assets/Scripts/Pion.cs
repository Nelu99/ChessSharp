using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pion : MonoBehaviour
{
	public int x,y;
	public int lvl = 1;
	public bool clicked=false;
	private Sprite lvl2;
	public static bool recruited;
	private bool end = false;

	void Start()
	{
		recruited = false;
	}

	void Awake()
	{
		x = Mathf.Abs ((int)this.transform.position.y);
		y = Mathf.Abs ((int)this.transform.position.x);
		lvl2 = Resources.Load ("Wpion2", typeof(Sprite)) as Sprite;
	}

    void Update()
	{
		if (Input.GetMouseButton (0) == false && clicked == true && Matrice.turn == 1) 
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
				if (lvl == 1 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] < 10 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] != 0) {
					lvl = 2;
					this.GetComponent<SpriteRenderer> ().sprite = lvl2;
				}
				Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] = Matrice.board [x, y];
				Matrice.board [x, y] = 0;
				x = Mathf.Abs ((int)this.transform.position.y);
				y = Mathf.Abs ((int)this.transform.position.x);
				clicked = false;
				Matrice.Clear ();
				Matrice.turn = 2;
				end = false;
			} 
			else
			{
				this.transform.position = new Vector2 (y+0.5f, (-1)*x-0.5f);
				clicked = false;
				Matrice.Clear ();
			}
		}
		if (Matrice.board [x, y] < 10)
			Destroy (this.gameObject);
		if (end==false && recruited == false && x == 0 && (Matrice.alive [0] < 1 || Matrice.alive [1] < 2 || Matrice.alive [2] < 2 || Matrice.alive [3] < 2))
		{
            Recruit.recr = 1;
            Recruit.team = "alb";
			recruited = true;
		}
		if (x == 0)
			end = true;
	}
		
	bool checkMove(int x1,int y1)
	{
		int lastPiece = Matrice.board [x1,y1];
		Matrice.board [x1,y1] = Matrice.board [x, y];
		Matrice.board [x, y] = 0;
		if (Rege.TestDanger (Rege.x, Rege.y) == true) 
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
		if (x != 0) {
			if (Matrice.board [x - 1, y] == 0 && Matrice.moves [x - 1, y] != (-1) && checkMove (x - 1, y) == false)
				return true;
			if ((y - 1) >= 0) {
				if (Matrice.board [x - 1, y - 1] < 10 && Matrice.board [x - 1, y - 1] != 4 && Matrice.board [x - 1, y - 1] != 0 && Matrice.moves [x - 1, y - 1] != (-1) && checkMove (x - 1, y - 1) == false)
					return true;
			}
			if ((y + 1) <= 7) {
				if (Matrice.board [x - 1, y + 1] < 10 && Matrice.board [x - 1, y + 1] != 4 && Matrice.board [x - 1, y + 1] != 0 && Matrice.moves [x - 1, y + 1] != (-1) && checkMove (x - 1, y + 1) == false)
					return true;
			}
		}
		if (lvl == 2 && x + 1 <= 7 && Matrice.board [x + 1, y] == 0 && Matrice.moves [x + 1, y] != (-1) && checkMove (x + 1, y) == false)
			return true;
		return false;
	}

	void OnMouseDown()
	{
		if (Matrice.turn == 1 && clicked == false) 
		{
			if (x != 0)
			{
				if (Matrice.board [x - 1, y] == 0 && Matrice.moves [x - 1, y] != (-1) && checkMove(x - 1, y) == false)
					Matrice.moves [x - 1, y] = 1;
				if ((y - 1) >= 0) {
					if (Matrice.board [x - 1, y - 1] < 10 && Matrice.board [x - 1, y - 1] != 4 && Matrice.board [x - 1, y - 1] != 0 && Matrice.moves [x - 1, y - 1] != (-1)  && checkMove(x - 1, y - 1) == false)
						Matrice.moves [x - 1, y - 1] = 1;
				}
				if ((y + 1) <= 7) {
					if (Matrice.board [x - 1, y + 1] < 10 && Matrice.board [x - 1, y + 1] != 4 && Matrice.board [x - 1, y + 1] != 0 && Matrice.moves [x - 1, y + 1] != (-1) && checkMove(x - 1, y + 1) == false)
						Matrice.moves [x - 1, y + 1] = 1;
				}
			}
			if (lvl == 2 && x + 1 <= 7  && Matrice.board[x + 1,y] == 0 && Matrice.moves [x + 1, y] != (-1) && checkMove(x + 1, y) == false)
				Matrice.moves [x + 1, y] = 1;	
			clicked = true;
			Matrice.cloned = true;
		}
	}
}
