using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Matrice : MonoBehaviour {

		public static bool cloned,gameOver,info;
		public static int turn;
		public static int[,] board;
		public static int[,] moves;
		public static int[] alive;
		private int oldTurn=1;
        public AudioSource tap, recruit, drop;

    public void playTap()
    {
        tap.Play(0);
    }
    void Start()
	{
		gameOver = false;
		cloned = false;
		turn = 1;
		info = false;
		board = new int[8,8]
		{
			{1, 2, 3, 5, 4, 3, 2, 1},
			{6, 6, 6, 6, 6, 6, 6, 6},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{66,66,66,66,66,66,66,66},
			{11,22,33,55,44,33,22,11}
		};
		moves = new int[8,8]
		{
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 }
		};
		alive = new int[]
		{1,2,2,2,1,2,2,2};
	}
	public static void Clear()
	{
		var clones = GameObject.FindGameObjectsWithTag ("clone");
		foreach (var clone in clones)
		{
			if ((Matrice.moves [Mathf.Abs ((int)clone.transform.position.y), Mathf.Abs ((int)clone.transform.position.x)]) >= 0 || Matrice.moves [Mathf.Abs ((int)clone.transform.position.y), Mathf.Abs ((int)clone.transform.position.x)] == (-2))
				Destroy (clone);
		}
		for (int i = 0; i < 8; i++)
			for (int j = 0; j < 8; j++)
				if (moves [i, j] > 0 || moves[i,j]==(-2))
					moves [i, j] = 0;
	}

	public static void GameOver()
	{
        if(!GOver.active)
            GOver.anim = true;
		gameOver = true;
	}

	void Update()
	{
		if (oldTurn != turn)
		{
            if(!drop.isPlaying)
                drop.Play(0);
			oldTurn = turn;
			if (turn == 2) 
			{
				var rege = GameObject.FindGameObjectWithTag ("wrege");
					rege.GetComponent<Rege> ().tested = false;
					rege.GetComponent<Rege> ().inDanger = false;
			} 
			else if (turn == 1) 
			{
				var rege = GameObject.FindGameObjectWithTag ("brege");
					rege.GetComponent<RegeNegru> ().tested = false;
					rege.GetComponent<RegeNegru> ().inDanger = false;
				if (SceneManager.GetActiveScene ().name == "ChessSingle")
					AI.moveDone = false;
			}
		}
		if (cloned == true && (SceneManager.GetActiveScene ().name == "Chess" || turn == 1))
		{
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
				{
					if ((moves [i, j] == 1 || moves [i, j] == (-2)) && !Recruit.active) 
					{
						GameObject highlight =
							Instantiate (GameObject.Find ("Highlight"),
								new Vector3 (j + 0.5f, (-1) * i - 0.5f, 0f),
								Quaternion.identity) as GameObject;
						highlight.tag = "clone";
						cloned = true;
					}
				}
			cloned = false;
		}
	}
}
   
