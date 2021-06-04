using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	private int rngPiece;
	public static bool moveDone;

	void Start()
	{
		moveDone = false;
	}
	void Update () 
	{
		if (moveDone == false && Matrice.turn == 2 && GameObject.FindGameObjectWithTag ("brege").GetComponent<RegeNegru> ().tested == true) 
		{
			rngPiece = Random.Range (1, 7);
			if (rngPiece == 1 && moveDone == false) {
				var ture = GameObject.FindGameObjectsWithTag ("btura");
				foreach (var tura in ture) {
					if (moveDone == true)
						break;
					if (tura.GetComponent<TuraNegru> ().CheckMoves () == true && Matrice.board [tura.GetComponent<TuraNegru> ().x, tura.GetComponent<TuraNegru> ().y] < 10) {
						tura.GetComponent<TuraNegru> ().OnMouseDown ();
						for (int i = 7; i >= 0; i--)
							for (int j = 7; j >= 0; j--)
								if (Matrice.moves [i, j] == 1) {
									tura.transform.position = new Vector2 (j + 0.5f, (-1) * i - 0.5f);
									moveDone = true;
									break;
								}	
					}
				}
			} else if (rngPiece == 2 && moveDone == false) {
				var cai = GameObject.FindGameObjectsWithTag ("bcal");
				foreach (var cal in cai) {
					if (moveDone == true)
						break;
					if (cal.GetComponent<CalNegru> ().CheckMoves () == true && Matrice.board [cal.GetComponent<CalNegru> ().x, cal.GetComponent<CalNegru> ().y] < 10) {
						cal.GetComponent<CalNegru> ().OnMouseDown ();
						for (int i = 7; i >= 0; i--)
							for (int j = 7; j >= 0; j--)
								if (Matrice.moves [i, j] == 1) {
									cal.transform.position = new Vector2 (j + 0.5f, (-1) * i - 0.5f);
									moveDone = true;
									break;
								}	
					}
				}
			} else if (rngPiece == 3 && moveDone == false) {
				var nebuni = GameObject.FindGameObjectsWithTag ("bnebun");
				foreach (var nebun in nebuni) {
					if (moveDone == true)
						break;
					if (nebun.GetComponent<NebunNegru> ().CheckMoves () == true && Matrice.board [nebun.GetComponent<NebunNegru> ().x, nebun.GetComponent<NebunNegru> ().y] < 10) {
						nebun.GetComponent<NebunNegru> ().OnMouseDown ();
						for (int i = 7; i >= 0; i--)
							for (int j = 7; j >= 0; j--)
								if (Matrice.moves [i, j] == 1) {
									nebun.transform.position = new Vector2 (j + 0.5f, (-1) * i - 0.5f);
									moveDone = true;
									break;
								}	
					}
				}
			} else if (rngPiece == 4 && moveDone == false) {
				var rege = GameObject.FindGameObjectWithTag ("brege");
				if (rege.GetComponent<RegeNegru> ().CheckMoves () == true) {
					rege.GetComponent<RegeNegru> ().OnMouseDown ();
					for (int i = 7; i >= 0; i--)
						for (int j = 7; j >= 0; j--)
							if (Matrice.moves [i, j] == 1) {
								if (Matrice.board [i, j] < 10)
									moveDone = true;
								rege.transform.position = new Vector2 (j + 0.5f, (-1) * i - 0.5f);
								break;
							}	
				}
			} else if (rngPiece == 5 && moveDone == false) {
				var regina = GameObject.FindGameObjectWithTag ("bregina");
				if (regina.GetComponent<ReginaNegru> ().CheckMoves () == true) {
					regina.GetComponent<ReginaNegru> ().OnMouseDown ();
					for (int i = 7; i >= 0; i--)
						for (int j = 7; j >= 0; j--)
							if (Matrice.moves [i, j] == 1) {
								regina.transform.position = new Vector2 (j + 0.5f, (-1) * i - 0.5f);
								moveDone = true;
								break;
							}	
				}
			} else if (rngPiece == 6 && moveDone == false) {
				var pioni = GameObject.FindGameObjectsWithTag ("bpion");
				foreach (var pion in pioni) {
					if (moveDone == true)
						break;
					if (pion.GetComponent<PionNegru> ().CheckMoves () == true && Matrice.board [pion.GetComponent<PionNegru> ().x, pion.GetComponent<PionNegru> ().y] < 10) {
						pion.GetComponent<PionNegru> ().OnMouseDown ();
						for (int i = 7; i >= 0; i--)
							for (int j = 7; j >= 0; j--)
								if (Matrice.moves [i, j] == 1) {
									pion.transform.position = new Vector2 (j + 0.5f, (-1) * i - 0.5f);
									moveDone = true;
									break;
								}	
					}
				}
			}
		}
	}
}
