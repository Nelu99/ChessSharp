using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeNegru : MonoBehaviour
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
		lvl2 = Resources.Load ("Brege2", typeof(Sprite)) as Sprite;
	}

	public static bool TestDanger(int x,int y)
	{
		if (y != 7)
			for (int i = y + 1; i <= 7; i++)
				if (Matrice.moves [x, i] == (-1) || (Matrice.board[x, i]!=0 && Matrice.board[x,i] != 11 && Matrice.board[x,i] != 55 && Matrice.board[x,i] != 4))
					break;
				else if (Matrice.board [x, i] == 11 || Matrice.board [x, i] == 55)
					return true;
		if (y != 0)
			for (int i = y - 1; i >= 0; i--)
				if (Matrice.moves [x, i] == (-1) || (Matrice.board[x, i]!=0 && Matrice.board[x,i] != 11 && Matrice.board[x,i] != 55 && Matrice.board[x,i] != 4))
					break;
				else if (Matrice.board [x, i] == 11 || Matrice.board [x, i] == 55)
					return true;
		if (x != 7)
			for (int i = x + 1; i <= 7; i++)
				if (Matrice.moves [i,y] == (-1) || (Matrice.board[i,y]!=0 && Matrice.board[i,y] != 11 && Matrice.board[i,y] != 55 && Matrice.board[i,y] != 4))
					break;
				else if (Matrice.board [i, y] == 11 || Matrice.board [i, y] == 55)
					return true;
		if (x != 0)
			for (int i = x - 1; i >= 0; i--)
				if (Matrice.moves [i,y] == (-1) || (Matrice.board[i,y]!=0 && Matrice.board[i,y] != 11 && Matrice.board[i,y] != 55 && Matrice.board[i,y] != 4))
					break;
				else if (Matrice.board [i, y] == 11 || Matrice.board [i, y] == 55)
					return true;

		int m = x, n = y;
		while (m <= 7 && n >= 0) 
		{
			m++;n--;
			if (m <= 7 && n >= 0) 
			{
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 33 && Matrice.board[m,n] != 55 && Matrice.board[m,n] != 4))
					break;
				else if (Matrice.board [m, n] == 33 || Matrice.board[m, n] == 55)
					return true;
			}
		}
		m = x;n = y;
		while (m <= 7 && n <= 7) 
		{
			m++;n++;
			if (m <= 7 && n <= 7) 
			{
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 33 && Matrice.board[m,n] != 55 && Matrice.board[m,n] != 4))
					break;
				else if (Matrice.board [m, n] == 33 || Matrice.board[m, n] == 55)
					return true;
			}
		}
		m = x;n = y;
		while (m >= 0 && n >= 0) 
		{
			m--;n--;
			if (m >= 0 && n >= 0) 
			{
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 33 && Matrice.board[m,n] != 55 && Matrice.board[m,n] != 4))
					break;
				else if (Matrice.board [m, n] == 33 || Matrice.board[m, n] == 55)
					return true;
			}
		}
		m = x;n = y;
		while (m >= 0 && n <= 7) 
		{
			m--;
			n++;
			if (m >= 0 && n <= 7) {
				if (Matrice.moves [m,n] == (-1) || (Matrice.board[m,n]!=0 && Matrice.board[m,n] != 33 && Matrice.board[m,n] != 55 && Matrice.board[m,n] != 4))
					break;
				else if (Matrice.board [m, n] == 33 || Matrice.board[m, n] == 55)
					return true;
			}
		}

		if (x - 2 >= 0 && y - 1 >= 0)
		{
			if (Matrice.board [x - 2,y - 1] == 22)
				return true;
		}
		if (x - 2 >= 0 && y + 1 <= 7)
		{
			if (Matrice.board [x - 2,y + 1] == 22)
				return true;
		}
		if (x + 2 <= 7 && y + 1 <= 7)
		{
			if (Matrice.board [x + 2,y + 1] == 22)
				return true;
		}
		if (x + 2 <= 7 && y - 1 >= 0)
		{
			if (Matrice.board [x + 2,y - 1] == 22)
				return true;
		}
		if (x - 1 >= 0 && y - 2 >= 0)
		{
			if (Matrice.board [x - 1,y - 2] == 22)
				return true;
		}
		if (x - 1 >= 0 && y + 2 <= 7)
		{
			if (Matrice.board [x - 1,y + 2] == 22)
				return true;
		}
		if (x + 1 <= 7 && y + 2 <= 7)
		{
			if (Matrice.board [x + 1,y + 2] == 22)
				return true;
		}
		if (x + 1 <= 7 && y - 2 >= 0)
		{
			if (Matrice.board [x + 1,y - 2] == 22)
				return true;
		}
		if (x + 1 >= 0 && y + 1 <= 7)
		{
			if (Matrice.board [x + 1,y + 1] == 66)
				return true;
		
		}
		if (x + 1 >= 0 && y - 1 >= 0)
		{
			if (Matrice.board [x + 1,y - 1] == 66)
				return true;
		}

		if (y - 2 >= 0)
		{	
			var cai = GameObject.FindGameObjectsWithTag ("wcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y-2+0.5f,(-1)*x-0.5f,0f)) && cal.GetComponent<Cal>().lvl==2 && Matrice.board [x,y - 2] == 22)
					return true;
		}
		if (y + 2 <= 7)
		{	
			var cai = GameObject.FindGameObjectsWithTag ("wcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y+2+0.5f,(-1)*x-0.5f,0f)) && cal.GetComponent<Cal>().lvl==2 && Matrice.board [x,y + 2] == 22)
					return true;
		}
		if (x + 2 <= 7)
		{
			var cai = GameObject.FindGameObjectsWithTag ("wcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y+0.5f,(-1)*(x+2)-0.5f,0f)) && cal.GetComponent<Cal>().lvl==2 && Matrice.board [x+2,y] == 22)
					return true;
		}
		if (x - 2 >= 0)
		{
			var cai = GameObject.FindGameObjectsWithTag ("wcal");
			foreach(var cal in cai)
				if((cal.transform.position == new Vector3(y+0.5f,(-1)*(x-2)-0.5f,0f)) && cal.GetComponent<Cal>().lvl==2 && Matrice.board [x-2,y] == 22)
					return true;
		}

		return false;
	}

	private bool ExistaMutariPosibile()
	{
		var cai = GameObject.FindGameObjectsWithTag ("bcal");
		foreach (var cal in cai)
			if (cal.GetComponent<CalNegru> ().CheckMoves () == true && Matrice.board[cal.GetComponent<CalNegru> ().x,cal.GetComponent<CalNegru> ().y] <10) {
				return true;
			}
		var nebuni = GameObject.FindGameObjectsWithTag ("bnebun");
		foreach (var nebun in nebuni)
			if (nebun.GetComponent<NebunNegru> ().CheckMoves () == true && Matrice.board[nebun.GetComponent<NebunNegru> ().x,nebun.GetComponent<NebunNegru> ().y] <10) {
				return true;
			}
		var pioni = GameObject.FindGameObjectsWithTag ("bpion");
		foreach (var pion in pioni)
			if (pion.GetComponent<PionNegru> ().CheckMoves () == true && Matrice.board[pion.GetComponent<PionNegru> ().x,pion.GetComponent<PionNegru> ().y] <10) {
				return true;
			}
		var ture = GameObject.FindGameObjectsWithTag ("btura");
		foreach (var tura in ture)
			if (tura.GetComponent<TuraNegru> ().CheckMoves () == true && Matrice.board[tura.GetComponent<TuraNegru> ().x,tura.GetComponent<TuraNegru> ().y] <10) {
				return true;
			}
		var regina = GameObject.FindGameObjectWithTag ("bregina");
		if (regina.GetComponent<ReginaNegru> ().CheckMoves () == true) {
			return true;
		}
		var rege = GameObject.FindGameObjectWithTag ("brege");
		if (rege.GetComponent<RegeNegru> ().CheckMoves () == true) {
			return true;
		}
		return false;
	}

	void Update()
	{
		if (tested == false && Matrice.turn == 2) 
		{
			if (TestDanger (x, y) == true)
				inDanger = true;
			if (ExistaMutariPosibile () == false && inDanger == true) {
				Matrice.GameOver();
			}
			tested = true;
		}
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
				if (lvl == 1 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] > 10 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] != 0) 
				{
					lvl = 2;
					this.GetComponent<SpriteRenderer> ().sprite = lvl2;
				}
				if (lvl == 2 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] > 10 && Matrice.board [Mathf.Abs ((int)this.transform.position.y), Mathf.Abs ((int)this.transform.position.x)] != 0) 
				{
					lvl = 1;
					Matrice.turn = 2;
					if (TestDanger (x, y) == true)
						inDanger = true;
				}
				else
					Matrice.turn = 1;
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
			if (TestDanger (x - 1, y) == false && Matrice.moves [x - 1, y] != (-1) && (Matrice.board [x - 1, y] == 0 || (Matrice.board [x - 1, y] > 10 && Matrice.board [x - 1, y] != 44))) {
				return true;
			}	
		}
		if (x != 7) {
			if (TestDanger (x + 1, y) == false && Matrice.moves [x + 1, y] != (-1) && (Matrice.board [x + 1, y] == 0 || (Matrice.board [x + 1, y] > 10 && Matrice.board [x + 1, y] != 44))) {
				return true;
			}	
		}
		if (y != 0) {
			if (TestDanger (x, y - 1) == false && Matrice.moves [x, y - 1] != (-1) && (Matrice.board [x, y - 1] == 0 || (Matrice.board [x, y - 1] > 10 && Matrice.board [x, y - 1] != 44))) {
				return true;
			}
		}
		if (y != 7) {
			if (TestDanger (x, y + 1) == false && Matrice.moves [x, y + 1] != (-1) && (Matrice.board [x, y + 1] == 0 || (Matrice.board [x, y + 1] > 10 && Matrice.board [x, y + 1] != 44))) {
				return true;
			}
		}
		if (x != 7 && y != 7) {
			if (TestDanger (x + 1, y + 1) == false && Matrice.moves [x + 1, y + 1] != (-1) && (Matrice.board [x + 1, y + 1] == 0 || (Matrice.board [x + 1, y + 1] > 10 && Matrice.board [x + 1, y + 1] != 44))) {
				return true;
			}
		}
		if (x != 7 && y != 0) {
			if (TestDanger (x + 1, y - 1) == false && Matrice.moves [x + 1, y - 1] != (-1) && (Matrice.board [x + 1, y - 1] == 0 || (Matrice.board [x + 1, y - 1] > 10 && Matrice.board [x + 1, y - 1] != 44))) {
				return true;
			}
		}
		if (x != 0 && y != 7) {
			if (TestDanger (x - 1, y + 1) == false && Matrice.moves [x - 1, y + 1] != (-1) && (Matrice.board [x - 1, y + 1] == 0 || (Matrice.board [x - 1, y + 1] > 10 && Matrice.board [x - 1, y + 1] != 44))) {
				return true;
			}
		}
		if (x != 0 && y != 0) {
			if (TestDanger (x - 1, y - 1) == false && Matrice.moves [x - 1, y - 1] != (-1) && (Matrice.board [x - 1, y - 1] == 0 || (Matrice.board [x - 1, y - 1] > 10 && Matrice.board [x - 1, y - 1] != 44))) {
				return true;
			}
		}
		return false;
	}

	public void OnMouseDown()
	{
		
		if (Matrice.turn == 2 && clicked == false) 
		{
			if (x != 0) {
				if (TestDanger(x-1,y)==false && Matrice.moves [x - 1, y] != (-1) && (Matrice.board [x - 1, y] == 0 || (Matrice.board [x - 1, y] > 10 && Matrice.board [x - 1, y] != 44))) {
					Matrice.moves [x - 1, y] = 1;
				}	
			}
			if (x != 7) {
				if (TestDanger(x+1,y)==false && Matrice.moves [x + 1, y] != (-1) && (Matrice.board [x + 1, y] == 0 || (Matrice.board [x + 1, y] > 10 && Matrice.board [x + 1, y] != 44))) {
					Matrice.moves [x + 1, y] = 1;
				}	
			}
			if (y != 0) {
				if (TestDanger(x,y-1)==false && Matrice.moves [x, y - 1] != (-1) && (Matrice.board [x, y - 1] == 0 || (Matrice.board [x, y - 1] > 10 && Matrice.board [x, y - 1] != 44))) {
					Matrice.moves [x, y - 1] = 1;
				}
			}
			if (y != 7) {
				if (TestDanger(x,y+1)==false && Matrice.moves [x, y + 1] != (-1) && (Matrice.board [x, y + 1] == 0 || (Matrice.board [x, y + 1] > 10 && Matrice.board [x, y + 1] != 44))) {
					Matrice.moves [x, y + 1] = 1;
				}
			}
			if(x!=7 && y!=7){
				if (TestDanger(x+1,y+1)==false && Matrice.moves [x + 1, y + 1] != (-1) && (Matrice.board [x + 1, y + 1] == 0 || (Matrice.board [x + 1, y + 1] > 10 && Matrice.board [x + 1, y + 1] != 44))) {
					Matrice.moves [x + 1, y + 1] = 1;
				}
			}
			if(x!=7 && y!=0){
				if (TestDanger(x+1,y-1)==false && Matrice.moves [x + 1, y - 1] != (-1) && (Matrice.board [x + 1, y - 1] == 0 || (Matrice.board [x + 1, y - 1] > 10 && Matrice.board [x + 1, y - 1] != 44))) {
					Matrice.moves [x + 1, y - 1] = 1;
				}
			}
			if(x!=0 && y!=7){
				if (TestDanger(x-1,y+1)==false && Matrice.moves [x - 1, y + 1] != (-1) && (Matrice.board [x - 1, y + 1] == 0 || (Matrice.board [x - 1, y + 1] > 10 && Matrice.board [x - 1, y + 1] != 44))) {
					Matrice.moves [x - 1, y + 1] = 1;
				}
			}
			if(x!=0 && y!=0){
				if (TestDanger(x-1,y-1)==false && Matrice.moves [x - 1, y - 1] != (-1) && (Matrice.board [x - 1, y - 1] == 0 || (Matrice.board [x - 1, y - 1] > 10 && Matrice.board [x - 1, y - 1] != 44))) {
					Matrice.moves [x - 1, y - 1] = 1;
				}
			}
			clicked = true;
			Matrice.cloned = true;
		}
	}
}
