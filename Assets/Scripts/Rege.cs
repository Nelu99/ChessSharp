using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rege : MonoBehaviour
{
	public static int x,y;
	public int lvl = 1;
	public bool clicked=false;
	private Sprite lvl2;
	public bool inDanger;
	public bool tested=false;

	void Start()
	{
		x = Mathf.Abs ((int)this.transform.position.y);
		y = Mathf.Abs ((int)this.transform.position.x);
		inDanger = false;
	}

	void Awake()
	{
		lvl2 = Resources.Load ("Wrege2", typeof(Sprite)) as Sprite;
	}

	public static bool TestDanger(int x,int y)
	{
		if (y != 7)
			for (int i = y + 1; i <= 7; i++)
				if (Matrice.moves [x, i] == (-1) || (Matrice.board[x, i]!=0 && Matrice.board[x,i] != 1 && Matrice.board[x,i] != 5 && Matrice.board[x,i] != 44))
					break;
				else if (Matrice.board [x, i] == 1 || Matrice.board [x, i] == 5)
					return true;
		if (y != 0)
			for (int i = y - 1; i >= 0; i--)
				if (Matrice.moves [x, i] == (-1) || (Matrice.board[x, i]!=0 && Matrice.board[x,i] != 1 && Matrice.board[x,i] != 5 && Matrice.board[x,i] != 44))
					break;
				else if (Matrice.board [x, i] == 1 || Matrice.board [x, i] == 5)
					return true;
		if (x != 7)
			for (int i = x + 1; i <= 7; i++)
				if (Matrice.moves [i,y] == (-1) || (Matrice.board[i,y]!=0 && Matrice.board[i,y] != 1 && Matrice.board[i,y] != 5 && Matrice.board[i,y] != 44))
					break;
				else if (Matrice.board [i, y] == 1 || Matrice.board [i, y] == 5)
					return true;
		if (x != 0)
			for (int i = x - 1; i >= 0; i--)
				if (Matrice.moves [i,y] == (-1) || (Matrice.board[i,y]!=0 && Matrice.board[i,y] != 1 && Matrice.board[i,y] != 5 && Matrice.board[i,y] != 44))
					break;
				else if (Matrice.board [i, y] == 1 || Matrice.board [i, y] == 5)
					return true;

		int m = x, n = y;

		while (m <= 7 && n >= 0) 
		{
			m++;n--;
			if (m <= 7 && n >= 0) 
			{
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 3 && Matrice.board[m,n] != 5 && Matrice.board[m,n] != 44))
					break;
				else if (Matrice.board [m, n] == 3 || Matrice.board[m, n] == 5)
					return true;
			}
		}
		m = x;n = y;
		while (m <= 7 && n <= 7) 
		{
			m++;n++;
			if (m <= 7 && n <= 7) 
			{
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 3 && Matrice.board[m,n] != 5 && Matrice.board[m,n] != 44))
					break;
				else if (Matrice.board [m, n] == 3 || Matrice.board[m, n] == 5)
					return true;
			}
		}
		m = x;n = y;
		while (m >= 0 && n >= 0) 
		{
			m--;n--;
			if (m >= 0 && n >= 0) 
			{
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 3 && Matrice.board[m,n] != 5 && Matrice.board[m,n] != 44))
					break;
				else if (Matrice.board [m, n] == 3 || Matrice.board[m, n] == 5)
					return true;
			}
		}
		m = x;n = y;
		while (m >= 0 && n <= 7) 
		{
			m--;
			n++;
			if (m >= 0 && n <= 7) {
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 3 && Matrice.board[m,n] != 5 && Matrice.board[m,n] != 44))
					break;
				else if (Matrice.board [m, n] == 3 || Matrice.board[m, n] == 5)
					return true;
			}
		}

		if (x - 2 >= 0 && y - 1 >= 0)
		{
			if (Matrice.board [x - 2, y - 1] == 2)
				return true;
		}
		if (x - 2 >= 0 && y + 1 <= 7)
		{
			if (Matrice.board [x - 2,y + 1] == 2)
				return true;
		}
		if (x + 2 <= 7 && y + 1 <= 7)
		{
			if (Matrice.board [x + 2,y + 1] == 2)
				return true;
		}
		if (x + 2 <= 7 && y - 1 >= 0)
		{
			if (Matrice.board [x + 2,y - 1] == 2)
				return true;
		}
		if (x - 1 >= 0 && y - 2 >= 0)
		{
			if (Matrice.board [x - 1,y - 2] == 2)
				return true;
		}
		if (x - 1 >= 0 && y + 2 <= 7)
		{
			if (Matrice.board [x - 1,y + 2] == 2)
				return true;
		}
		if (x + 1 <= 7 && y + 2 <= 7)
		{
			if (Matrice.board [x + 1,y + 2] == 2)
				return true;
		}
		if (x + 1 <= 7 && y - 2 >= 0)
		{
			if (Matrice.board [x + 1,y - 2] == 2)
				return true;
		}
		if (x - 1 >= 0 && y + 1 <= 7)
		{
			if (Matrice.board [x - 1,y + 1] == 6)
				return true;

		}
		if (x - 1 >= 0 && y - 1 >= 0)
		{
			if (Matrice.board [x - 1,y - 1] == 6)
				return true;
		}

		if (y - 2 >= 0)
		{	
			var cai = GameObject.FindGameObjectsWithTag ("bcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y-2+0.5f,(-1)*x-0.5f,0f)) && cal.GetComponent<CalNegru>().lvl==2 && Matrice.board [x,y - 2] == 2)
					return true;
		}
		if (y + 2 <= 7)
		{	
			var cai = GameObject.FindGameObjectsWithTag ("bcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y+2+0.5f,(-1)*x-0.5f,0f)) && cal.GetComponent<CalNegru>().lvl==2 && Matrice.board [x,y + 2] == 2)
					return true;
		}
		if (x + 2 <= 7)
		{
			var cai = GameObject.FindGameObjectsWithTag ("bcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y+0.5f,(-1)*(x+2)-0.5f,0f)) && cal.GetComponent<CalNegru>().lvl==2 && Matrice.board [x+2,y] == 2)
					return true;
		}
		if (x - 2 >= 0)
		{
			var cai = GameObject.FindGameObjectsWithTag ("bcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y+0.5f,(-1)*(x-2)-0.5f,0f)) && cal.GetComponent<CalNegru>().lvl==2 && Matrice.board [x-2,y] == 2)
					return true;
		}
		return false;
	}

	private bool ExistaMutariPosibile()
	{
		var cai = GameObject.FindGameObjectsWithTag ("wcal");
		foreach (var cal in cai)
			if (cal.GetComponent<Cal> ().CheckMoves () == true && Matrice.board[cal.GetComponent<Cal> ().x,cal.GetComponent<Cal> ().y] >10) {
				return true;
			}
		var nebuni = GameObject.FindGameObjectsWithTag ("wnebun");
		foreach (var nebun in nebuni)
			if (nebun.GetComponent<Nebun> ().CheckMoves () == true && Matrice.board[nebun.GetComponent<Nebun> ().x,nebun.GetComponent<Nebun> ().y] >10) {
				return true;
			}
		var pioni = GameObject.FindGameObjectsWithTag ("wpion");
		foreach (var pion in pioni)
			if (pion.GetComponent<Pion> ().CheckMoves () == true && Matrice.board[pion.GetComponent<Pion> ().x,pion.GetComponent<Pion> ().y] >10) {
				return true;
			}
		var ture = GameObject.FindGameObjectsWithTag ("wtura");
		foreach (var tura in ture)
			if (tura.GetComponent<Tura> ().CheckMoves () == true && Matrice.board[tura.GetComponent<Tura> ().x,tura.GetComponent<Tura> ().y] >10) {
				return true;
			}
		var regina = GameObject.FindGameObjectWithTag ("wregina");
		if (regina.GetComponent<Regina> ().CheckMoves () == true) {
			return true;
		}
		var rege = GameObject.FindGameObjectWithTag ("wrege");
		if (rege.GetComponent<Rege> ().CheckMoves () == true) {
			return true;
		}
		return false;
	}
		
	void Update()
	{
		if (tested == false && Matrice.turn == 1) 
		{
			if (TestDanger (x, y) == true)
				inDanger = true;
			if (ExistaMutariPosibile() == false && inDanger == true)
				Matrice.GameOver ();
			tested = true;
		}	
		if (Input.GetMouseButton (0) == false && (clicked == true) && Matrice.turn == 1) 
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
				if (lvl == 1 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] < 10 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] != 0) 
				{
					lvl = 2;
					this.GetComponent<SpriteRenderer> ().sprite = lvl2;
				}
				if (lvl == 2 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] < 10 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] != 0) 
				{
					lvl = 1;
					Matrice.turn = 1;
					if (TestDanger (x, y) == true)
						inDanger = true;
				}
				else
					Matrice.turn = 2;
				Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] = Matrice.board [x, y];
				Matrice.board [x, y] = 0;
				x = Mathf.Abs ((int)this.transform.position.y);
				y = Mathf.Abs ((int)this.transform.position.x);
				clicked = false;
				Matrice.Clear ();
				inDanger = false;
				tested=false;
			} 
			else
			{
				this.transform.position = new Vector2 (y+0.5f, (-1)*x-0.5f);
				clicked = false;
				Matrice.Clear ();
			}
		}
	}

	public bool CheckMoves()
	{
		if (x != 0) {
			if (TestDanger (x - 1, y) == false && Matrice.moves [x - 1, y] != (-1) && (Matrice.board [x - 1, y] == 0 || (Matrice.board [x - 1, y] < 10 && Matrice.board [x - 1, y] != 4))) {
				return true;
			}	
		}
		if (x != 7) {
			if (TestDanger (x + 1, y) == false && Matrice.moves [x + 1, y] != (-1) && (Matrice.board [x + 1, y] == 0 || (Matrice.board [x + 1, y] < 10 && Matrice.board [x + 1, y] != 4))) {
				return true;
			}	
		}
		if (y != 0) {
			if (TestDanger (x, y - 1) == false && Matrice.moves [x, y - 1] != (-1) && (Matrice.board [x, y - 1] == 0 || (Matrice.board [x, y - 1] < 10 && Matrice.board [x, y - 1] != 4))) {
				return true;
			}
		}
		if (y != 7) {
			if (TestDanger (x, y + 1) == false && Matrice.moves [x, y + 1] != (-1) && (Matrice.board [x, y + 1] == 0 || (Matrice.board [x, y + 1] < 10 && Matrice.board [x, y + 1] != 4))) {
				return true;
			}
		}
		if (x != 7 && y != 7) {
			if (TestDanger (x + 1, y + 1) == false && Matrice.moves [x + 1, y + 1] != (-1) && (Matrice.board [x + 1, y + 1] == 0 || (Matrice.board [x + 1, y + 1] < 10 && Matrice.board [x + 1, y + 1] != 4))) {
				return true;
			}
		}
		if (x != 7 && y != 0) {
			if (TestDanger (x + 1, y - 1) == false && Matrice.moves [x + 1, y - 1] != (-1) && (Matrice.board [x + 1, y - 1] == 0 || (Matrice.board [x + 1, y - 1] < 10 && Matrice.board [x + 1, y - 1] != 4))) {
				return true;
			}
		}
		if (x != 0 && y != 7) {
			if (TestDanger (x - 1, y + 1) == false && Matrice.moves [x - 1, y + 1] != (-1) && (Matrice.board [x - 1, y + 1] == 0 || (Matrice.board [x - 1, y + 1] < 10 && Matrice.board [x - 1, y + 1] != 4))) {
				return true;
			}
		}
		if (x != 0 && y != 0) {
			if (TestDanger (x - 1, y - 1) == false && Matrice.moves [x - 1, y - 1] != (-1) && (Matrice.board [x - 1, y - 1] == 0 || (Matrice.board [x - 1, y - 1] < 10 && Matrice.board [x - 1, y - 1] != 4))) {
				return true;
			}
		}
		return false;
	}

	void OnMouseDown()
	{
		if (Matrice.turn == 1 && clicked == false) 
		{
			if (x != 0) {
				if (TestDanger(x-1,y)==false && Matrice.moves [x - 1, y] != (-1) && (Matrice.board [x - 1, y] == 0 || (Matrice.board [x - 1, y] < 10 && Matrice.board [x - 1, y] != 4))) {
					Matrice.moves [x - 1, y] = 1;
				}	
			}
			if (x != 7) {
				if (TestDanger(x+1,y)==false && Matrice.moves [x + 1, y] != (-1) && (Matrice.board [x + 1, y] == 0 || (Matrice.board [x + 1, y] < 10 && Matrice.board [x + 1, y] != 4))) {
					Matrice.moves [x + 1, y] = 1;
				}	
			}
			if (y != 0) {
				if (TestDanger(x,y-1)==false && Matrice.moves [x, y - 1] != (-1) && (Matrice.board [x, y - 1] == 0 || (Matrice.board [x, y - 1] < 10 && Matrice.board [x, y - 1] != 4))) {
					Matrice.moves [x, y - 1] = 1;
				}
			}
			if (y != 7) {
				if (TestDanger(x,y+1)==false && Matrice.moves [x, y + 1] != (-1) && (Matrice.board [x, y + 1] == 0 || (Matrice.board [x, y + 1] < 10 && Matrice.board [x, y + 1] != 4))) {
					Matrice.moves [x, y + 1] = 1;
				}
			}
			if(x!=7 && y!=7){
				if (TestDanger(x+1,y+1)==false && Matrice.moves [x + 1, y + 1] != (-1) && (Matrice.board [x + 1, y + 1] == 0 || (Matrice.board [x + 1, y + 1] < 10 && Matrice.board [x + 1, y + 1] != 4))) {
					Matrice.moves [x + 1, y + 1] = 1;
				}
			}
			if(x!=7 && y!=0){
				if (TestDanger(x+1,y-1)==false && Matrice.moves [x + 1, y - 1] != (-1) && (Matrice.board [x + 1, y - 1] == 0 || (Matrice.board [x + 1, y - 1] < 10 && Matrice.board [x + 1, y - 1] != 4))) {
					Matrice.moves [x + 1, y - 1] = 1;
				}
			}
			if(x!=0 && y!=7){
				if (TestDanger(x-1,y+1)==false && Matrice.moves [x - 1, y + 1] != (-1) && (Matrice.board [x - 1, y + 1] == 0 || (Matrice.board [x - 1, y + 1] < 10 && Matrice.board [x - 1, y + 1] != 4))) {
					Matrice.moves [x - 1, y + 1] = 1;
				}
			}
			if(x!=0 && y!=0){
				if (TestDanger(x-1,y-1)==false && Matrice.moves [x - 1, y - 1] != (-1) && (Matrice.board [x - 1, y - 1] == 0 || (Matrice.board [x - 1, y - 1] < 10 && Matrice.board [x - 1, y - 1] != 4))) {
					Matrice.moves [x - 1, y - 1] = 1;
				}
			}
			clicked = true;
			Matrice.cloned = true;
		}
	}
}
