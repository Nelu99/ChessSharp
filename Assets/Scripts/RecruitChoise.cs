using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitChoise : MonoBehaviour {

	public string piece;
	private bool checkd = false;
	private Sprite wr,wt,wn,wc,br,bt,bn,bc;
    public Matrice matrice;

	void Awake()
	{
		wr=Resources.Load ("Wregina", typeof(Sprite)) as Sprite;
		wt=Resources.Load ("Wtura", typeof(Sprite)) as Sprite;
		wn=Resources.Load ("Wnebun", typeof(Sprite)) as Sprite;
		wc=Resources.Load ("Wcal", typeof(Sprite)) as Sprite;
		br=Resources.Load ("Bregina", typeof(Sprite)) as Sprite;
		bt=Resources.Load ("Btura", typeof(Sprite)) as Sprite;
		bn=Resources.Load ("Bnebun", typeof(Sprite)) as Sprite;
		bc=Resources.Load ("Bcal1", typeof(Sprite)) as Sprite;
	}

	void Update () 
	{
		if (Recruit.active) 
		{
			checkd = false;
		}
		if (this.GetComponent<UnityEngine.UI.Image> ().color == Color.green && Recruit.updated < 4 && checkd == false)
		{
			this.GetComponent<UnityEngine.UI.Image> ().color = Color.black;
			Recruit.updated++;
		}
		if (Recruit.active && Recruit.updated > 0 && checkd == false) 
		{
			if (piece == "regina") {
				if ((Recruit.team == "alb" && Matrice.alive [0] < 1) || (Recruit.team == "negru" && Matrice.alive [4] < 1)) {
					{
						this.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
						Recruit.updated--;
					}
				}
			} else if (piece == "tura") {
				if ((Recruit.team == "alb" && Matrice.alive [1] < 2) || (Recruit.team == "negru" && Matrice.alive [5] < 2))
				{
					this.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
					Recruit.updated--;
				}
			} else if (piece == "nebun") {
				if ((Recruit.team == "alb" && Matrice.alive [2] < 2) || (Recruit.team == "negru" && Matrice.alive [6] < 2))
				{
					this.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
					Recruit.updated--;
				}
			} else if (piece == "cal") {
				if ((Recruit.team == "alb" && Matrice.alive [3] < 2) || (Recruit.team == "negru" && Matrice.alive [7] < 2)) 
				{
					this.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
					Recruit.updated--;
				}
			}
			checkd = true;
		} 
	}
	void OnMouseDown()
	{
		if (this.GetComponent<UnityEngine.UI.Image> ().color == Color.green)
		{

			if(Recruit.team=="alb")
			{
				var wpioni = GameObject.FindGameObjectsWithTag ("wpion");
				foreach (var wpion in wpioni)
				{
					if (Mathf.Abs ((int)wpion.transform.position.y) == 0) 
					{
						if (piece == "regina") 
						{
							Matrice.alive[0]++;
							wpion.GetComponent<SpriteRenderer> ().sprite = wr;
							Destroy(wpion.GetComponent<Pion>());
							wpion.AddComponent(typeof(Regina));	
							wpion.tag="wregina";
						} 
						else if (piece == "tura") 
						{
							Matrice.alive[1]++;
							wpion.GetComponent<SpriteRenderer> ().sprite = wt;
							Destroy(wpion.GetComponent<Pion>());
							wpion.AddComponent(typeof(Tura));
							wpion.tag="wtura";
						}
						else if (piece == "nebun")
						{
							Matrice.alive[2]++;
							wpion.GetComponent<SpriteRenderer> ().sprite = wn;
							Destroy(wpion.GetComponent<Pion>());
							wpion.AddComponent(typeof(Nebun));
							wpion.tag="wnebun";
						}
						else if (piece == "cal") 
						{
							Matrice.alive[3]++;
							wpion.GetComponent<SpriteRenderer> ().sprite = wc;
							Destroy(wpion.GetComponent<Pion>());
							wpion.AddComponent(typeof(Cal));	
							wpion.tag="wcal";
						}
						break;
					}
				}
			}
			else if(Recruit.team=="negru")
			{
				var bpioni = GameObject.FindGameObjectsWithTag ("bpion");
				foreach (var bpion in bpioni)
				{
					if (Mathf.Abs ((int)bpion.transform.position.y) == 7)
					{
						if (piece == "regina") 
						{
							Matrice.alive[4]++;
							bpion.GetComponent<SpriteRenderer> ().sprite = br;
							Destroy(bpion.GetComponent<PionNegru>());
							bpion.AddComponent(typeof(ReginaNegru));	
							bpion.tag="bregina";
						} 
						else if (piece == "tura") 
						{
							Matrice.alive[5]++;
							bpion.GetComponent<SpriteRenderer> ().sprite = bt;
							Destroy(bpion.GetComponent<PionNegru>());
							bpion.AddComponent(typeof(TuraNegru));
							bpion.tag="btura";
						}
						else if (piece == "nebun")
						{
							Matrice.alive[6]++;
							bpion.GetComponent<SpriteRenderer> ().sprite = bn;
							Destroy(bpion.GetComponent<PionNegru>());
							bpion.AddComponent(typeof(NebunNegru));
							bpion.tag="bnebun";
						}
						else if (piece == "cal") 
						{
							Matrice.alive[7]++;
							bpion.GetComponent<SpriteRenderer> ().sprite = bc;
							Destroy(bpion.GetComponent<PionNegru>());
							bpion.AddComponent(typeof(CalNegru));	
							bpion.tag="bcal";
						}
						break;
					}
				}
			}
			Recruit.team="";
            Recruit.active = false;
            Recruit.recr = -1;
            matrice.recruit.Play(0);
		}
	}
}
