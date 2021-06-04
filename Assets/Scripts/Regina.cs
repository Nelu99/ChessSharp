using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regina : MonoBehaviour {

	public int x,y;
	public int lvl = 1;
	public bool clicked=false;
	private Sprite lvl2;

	void Awake()
	{
		x = Mathf.Abs ((int)this.transform.position.y);
		y = Mathf.Abs ((int)this.transform.position.x);
		lvl2 = Resources.Load ("Wregina2", typeof(Sprite)) as Sprite;
	}

	void Update () 
	{
		if (Input.GetMouseButton (0) == false && clicked == true && Matrice.turn == 1) 
		{
			clicked = false;
			this.transform.position = new Vector2 ((int)this.transform.position.x + 0.5f, ((int)this.transform.position.y - 0.5f));
			if (this.transform.position.x < 0 || this.transform.position.x > 8 || this.transform.position.y < (-8) || this.transform.position.y > 0 || Matrice.moves [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] == 0 || Matrice.moves [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] == (-1)|| (Matrice.moves [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] == (-2) && lvl==1)) 
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
			} 
			else if (lvl == 2 && Matrice.moves [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] == (-2))
			{
				var friends1 = GameObject.FindGameObjectsWithTag ("wpion");
				var friends2 = GameObject.FindGameObjectsWithTag ("wtura");
				var friends3 = GameObject.FindGameObjectsWithTag ("wnebun");
				var friends4 = GameObject.FindGameObjectsWithTag ("wcal");
				foreach (var friend in friends1) 
					if(friend.transform.position == new Vector3 ((int)this.transform.position.x + 0.5f, (int)this.transform.position.y - 0.5f,0f))
					{
						friend.transform.position = new Vector2 (y + 0.5f, (-1) * x - 0.5f);
						if (friend.GetComponent<Pion> ().lvl == 2)
						{
							Destroy(friend.GetComponent<Pion>());
							friend.AddComponent (typeof(Pion));
							friend.GetComponent<Pion> ().lvl = 2;
						} 
						else
						{
							Destroy(friend.GetComponent<Pion>());
							friend.AddComponent (typeof(Pion));
						}
							break;
					}
				foreach (var friend in friends2) 
					if(friend.transform.position == new Vector3 ((int)this.transform.position.x + 0.5f, (int)this.transform.position.y - 0.5f,0f))
					{
						friend.transform.position = new Vector2 (y + 0.5f, (-1) * x - 0.5f);
						if (friend.GetComponent<Tura> ().lvl == 2)
						{
							Destroy(friend.GetComponent<Tura>());
							friend.AddComponent (typeof(Tura));
							friend.GetComponent<Tura> ().lvl = 2;
						} 
						else
						{
							Destroy(friend.GetComponent<Tura>());
							friend.AddComponent (typeof(Tura));
						}
						break;
					}
				foreach (var friend in friends3) 
					if(friend.transform.position == new Vector3 ((int)this.transform.position.x + 0.5f, (int)this.transform.position.y - 0.5f,0f))
					{
						friend.transform.position = new Vector2 (y + 0.5f, (-1) * x - 0.5f);
						if (friend.GetComponent<Nebun> ().lvl == 2)
						{
							Destroy(friend.GetComponent<Nebun>());
							friend.AddComponent (typeof(Nebun));
							friend.GetComponent<Nebun> ().lvl = 2;
						} 
						else
						{
							Destroy(friend.GetComponent<Nebun>());
							friend.AddComponent (typeof(Nebun));
						}
						break;
					}
				foreach (var friend in friends4) 
					if(friend.transform.position == new Vector3 ((int)this.transform.position.x + 0.5f, (int)this.transform.position.y - 0.5f,0f))
					{
						friend.transform.position = new Vector2 (y + 0.5f, (-1) * x - 0.5f);
						if (friend.GetComponent<Cal> ().lvl == 2)
						{
							Destroy(friend.GetComponent<Cal>());
							friend.AddComponent (typeof(Cal));
							friend.GetComponent<Cal> ().lvl = 2;
						} 
						else
						{
							Destroy(friend.GetComponent<Cal>());
							friend.AddComponent (typeof(Cal));
						}
						break;
					}
				int p = Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)];
				Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] = Matrice.board [x, y];
				Matrice.board [x, y] = p;
				x = Mathf.Abs ((int)this.transform.position.y);
				y = Mathf.Abs ((int)this.transform.position.x);
				clicked = false;
				Matrice.Clear ();
				Matrice.turn = 2;
			}
			else
			{
				this.transform.position = new Vector2 (y+0.5f, (-1)*x-0.5f);
				clicked = false;
				Matrice.Clear ();
			}
		}
		if (Matrice.board [x, y] < 10) {
			Destroy (this.gameObject);
			Matrice.alive [0]--;
		}
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
		if (y != 7)
			for (int i = y + 1; i <= 7; i++) {
				if (Matrice.board [x, i] == 0 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false && checkMove (x, i) == false)
					return true;
				else if (Matrice.board [x, i] < 10 && Matrice.board [x, i] != 4 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false) {
					return true;
				} else if (Matrice.board [x, i] > 10 && Matrice.board [x, i] != 44) {
					break;
				} else if (Matrice.board [x, i] != 0 && (Matrice.moves [x, i] == (-1) || Matrice.board [x, i] == 4 || Matrice.board [x, i] == 44))
					break;
			}
		if (y != 0)
			for (int i = y - 1; i >= 0; i--) {
				if (Matrice.board [x, i] == 0 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false && checkMove (x, i) == false)
					return true;
				else if (Matrice.board [x, i] < 10 && Matrice.board [x, i] != 4 && Matrice.moves [x, i] != (-1) && checkMove (x, i) == false) {
					return true;
				} else if (Matrice.board [x, i] > 10 && Matrice.board [x, i] != 44) {
					break;
				} else if (Matrice.board [x, i] != 0 && (Matrice.moves [x, i] == (-1) || Matrice.board [x, i] == 4 || Matrice.board [x, i] == 44))
					break;
			}
		if (x != 7)
			for (int i = x + 1; i <= 7; i++) {
				if (Matrice.board [i, y] == 0 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false)
					return true;
				else if (Matrice.board [i, y] < 10 && Matrice.board [i, y] != 4 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false) {
					return true;
				} else if (Matrice.board [i, y] > 10 && Matrice.board [i, y] != 44) {
					break;
				} else if (Matrice.board [i, y] != 0 && (Matrice.moves [i, y] == (-1) || Matrice.board [i, y] == 4 || Matrice.board [i, y] == 44))
					break;
			}
		if (x != 0)
			for (int i = x - 1; i >= 0; i--) {
				if (Matrice.board [i, y] == 0 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false)
					return true;
				else if (Matrice.board [i, y] < 10 && Matrice.board [i, y] != 4 && Matrice.moves [i, y] != (-1) && checkMove (i, y) == false) {
					return true;
				} else if (Matrice.board [i, y] > 10 && Matrice.board [i, y] != 44) {
					break;
				} else if (Matrice.board [i, y] != 0 && (Matrice.moves [i, y] == (-1) || Matrice.board [i, y] == 4 || Matrice.board [i, y] == 44))
					break;
			}

		int m = x, n = y;

		while (m <= 7 && n >= 0) {
			m++;
			n--;
			if (m <= 7 && n >= 0) {
				if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false)
					return true;
				else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44) {
					break;
				} else if (Matrice.board [m, n] != 0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
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
				else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44) {
					break;
				} else if (Matrice.board [m, n] != 0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
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
				else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44) {
					break;
				} else if (Matrice.board [m, n] != 0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
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
				else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove (m, n) == false) {
					return true;
				} else if (Matrice.board [m, n] > 10 && Matrice.board [m, n] != 44) {
					break;
				} else if (Matrice.board [m, n] != 0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
					break;
			}
		}
		return false;
	}

	void OnMouseDown()
	{
		if (Matrice.turn == 1 && clicked == false) 
		{
			if (y != 7)
				for (int i = y + 1; i <= 7; i++)
				{
					if (Matrice.board [x, i] == 0 && Matrice.moves [x , i] != (-1) && checkMove(x, i) == false && checkMove(x, i) == false)
						Matrice.moves [x, i] = 1;
					else if (Matrice.board [x, i] < 10 && Matrice.board [x, i] != 4 && Matrice.moves [x , i] != (-1) && checkMove(x, i) == false) 
					{
						Matrice.moves [x, i] = 1;
						break;
					} 
					else if (Matrice.board [x, i] > 10 && Matrice.board[x,i]!=44) 
					{
						if(lvl==2 && checkMove(x, i) == false)
							Matrice.moves [x, i] = (-2);
						break;
					}
					else if (Matrice.board[x,i] != 0 && (Matrice.moves [x, i] == (-1) || Matrice.board [x, i] == 4 || Matrice.board [x, i] == 44))
						break;
				}
			if (y != 0)
				for (int i = y - 1; i >= 0; i--)
				{
					if (Matrice.board [x, i] == 0 && Matrice.moves [x, i] != (-1) && checkMove(x, i) == false && checkMove(x, i) == false)
						Matrice.moves [x, i] = 1;
					else if (Matrice.board [x, i] < 10 && Matrice.board [x, i] != 4 && Matrice.moves [x, i] != (-1) && checkMove(x, i) == false)
					{
						Matrice.moves [x, i] = 1;
						break;
					}
					else if (Matrice.board [x, i] > 10 && Matrice.board[x,i]!=44) 
					{
						if(lvl==2 && checkMove(x, i) == false)
							Matrice.moves [x, i] = (-2);
						break;
					}
					else if (Matrice.board[x,i] != 0 && (Matrice.moves [x, i] == (-1) || Matrice.board [x, i] == 4 || Matrice.board [x, i] == 44))
						break;
				}
			if (x != 7)
				for (int i = x + 1; i <= 7; i++)
				{
					if (Matrice.board [i, y] == 0 && Matrice.moves [i , y] != (-1) && checkMove(i, y) == false)
						Matrice.moves [i, y] = 1;
					else if (Matrice.board [i, y] < 10 && Matrice.board [i, y] != 4 && Matrice.moves [i , y] != (-1) && checkMove(i, y) == false) 
					{
						Matrice.moves [i, y] = 1;
						break;
					} 
					else if (Matrice.board [i,y] > 10 && Matrice.board[i,y]!=44) 
					{
						if(lvl==2 && checkMove(i, y) == false)
							Matrice.moves [i,y] = (-2);
						break;
					}
					else if (Matrice.board[i,y] != 0 && (Matrice.moves [i, y] == (-1) || Matrice.board [i, y] == 4 || Matrice.board [i, y] == 44))
						break;
				}
			if (x != 0)
				for (int i = x - 1; i >= 0; i--)
				{
					if (Matrice.board [i, y] == 0 && Matrice.moves [i , y] != (-1) && checkMove(i, y) == false)
						Matrice.moves [i, y] = 1;
					else if (Matrice.board [i, y] < 10 && Matrice.board [i, y] != 4 && Matrice.moves [i, y] != (-1) && checkMove(i, y) == false) 
					{
						Matrice.moves [i, y] = 1;
						break;
					} 
					else if (Matrice.board [i,y] > 10 && Matrice.board[i,y]!=44) 
					{
						if(lvl==2 && checkMove(i, y) == false)
							Matrice.moves [i,y] = (-2);
						break;
					}
					else if (Matrice.board[i,y] != 0 && (Matrice.moves [i, y] == (-1) || Matrice.board [i, y] == 4 || Matrice.board [i, y] == 44))
						break;
				}

			int m = x, n = y;

			while (m <= 7 && n >= 0) 
			{
				m++;n--;
				if (m <= 7 && n >= 0) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove(m, n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove(m,n) == false) {
						Matrice.moves [m, n] = 1;
						break;
					}
					else if (Matrice.board [m,n] > 10 && Matrice.board[m,n]!=44) 
					{
						if(lvl==2 && checkMove(m, n) == false)
							Matrice.moves [m,n] = (-2);
						break;
					}
					else if (Matrice.board[m,n]!=0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
						break;
				}
			}
			m = x;n = y;
			while (m <= 7 && n <= 7) 
			{
				m++;n++;
				if (m <= 7 && n <= 7) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove(m,n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove(m,n) == false) 
					{
						Matrice.moves [m, n] = 1;
						break;
					}
					else if (Matrice.board [m,n] > 10 && Matrice.board[m,n]!=44) 
					{
						if(lvl==2 && checkMove(m,n) == false)
							Matrice.moves [m,n] = (-2);
						break;
					}
					else if (Matrice.board[m,n]!=0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
						break;
				}
			}
			m = x;n = y;
			while (m >= 0 && n >= 0) 
			{
				m--;n--;
				if (m >= 0 && n >= 0) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove(m,n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove(m,n) == false)
					{
						Matrice.moves [m, n] = 1;
						break;
					} 
					else if (Matrice.board [m,n] > 10 && Matrice.board[m,n]!=44) 
					{
						if(lvl==2 && checkMove(m,n) == false)
							Matrice.moves [m,n] = (-2);
						break;
					}
					else if (Matrice.board[m,n]!=0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
						break;
				}
			}
			m = x;n = y;
			while (m >= 0 && n <= 7) 
			{
				m--;n++;
				if (m >= 0 && n <= 7) 
				{
					if (Matrice.board [m, n] == 0 && Matrice.moves [m, n] != (-1) && checkMove(m,n) == false)
						Matrice.moves [m, n] = 1;
					else if (Matrice.board [m, n] < 10 && Matrice.board [m, n] != 4 && Matrice.moves [m, n] != (-1) && checkMove(m,n) == false) 
					{
						Matrice.moves [m, n] = 1;
						break;
					}
					else if (Matrice.board [m,n] > 10 && Matrice.board[m,n]!=44) 
					{
						if(lvl==2 && checkMove(m,n) == false)
							Matrice.moves [m,n] = (-2);
						break;
					} else if (Matrice.board[m,n]!=0 && (Matrice.moves [m, n] == (-1) || Matrice.board [m, n] == 4 || Matrice.board [m, n] == 44))
						break;
				}
			}

			clicked = true;
			Matrice.cloned = true;
		}
	}
}	
