using UnityEngine;
using System.Collections;


public class generate : MonoBehaviour {

	const int MAXBLOCKKIND = 10;
	const int BLOCKWIHTH = 16*2;
	const int BLOCKHEIGHT = 19*2;
	public int level = 2;
	public GameObject[] prefab;
	GameObject[,] block;
	int[,] block_kind;
	int height;
	int length;
	int blockcnt;
	int x_base;
	int y_base;
	int[] kind;

	public int pre;
	public int flag;
	public GameObject preobj;

	/// <summary>
	/// init height length kind and blockcnt
	/// 
	/// </summary>
	bool init () {
		//prefab = new GameObject[MAXBLOCKKIND];
		if (level <= 0 || level >= MAXBLOCKKIND) {
			return false;
		}

		pre = -1;
		flag = 0;
		preobj = null;

		height = 6;
		length = 10;
		blockcnt = 2 + level;

		block_kind = new int[20, 20];
		block = new GameObject[20, 20];
		kind = new int[20];

		int sum = 0;
		for (int i=0; i<blockcnt - 1; i++) {
			kind[i] = (height*length)/blockcnt;
			if(kind[i]%2==1){
				kind[i]--;
			}
			sum+=kind[i];
		}

		//last block kind
		kind [blockcnt - 1] = (height * length) - sum;

		int[,] visit = new int[length,height];

		for (int i=0; i<length; i++) {
			for(int j=0;j<height;j++){
				visit[i,j] = 0;
			}
		}

		#if false
		Debug.Log ("kind:" + blockcnt);
		for (int i=0; i<blockcnt; i++)
			Debug.Log ("kind[" + i + "]:" + kind [i]);
		#endif

		x_base = -length*(BLOCKWIHTH+1)/2;
		y_base = -height*(BLOCKHEIGHT+1)/2;
		//Debug.Log ("x_base:"+x_base);
		//Debug.Log ("y_base"+y_base);

		for (int i=0; i<blockcnt; i++) {
			for(int j=0; j<kind[i]; j++) {
				//GameObject obj = GameObject.Instantiate (prefab[i]) as GameObject;

				//obj.transform.localPosition = new Vector3(-103,0,0);
				//obj.transform.localScale = new Vector3(16,19, 1);

				string str_origin = "ele"+i.ToString()+"(Clone)";
				string str_new = "ele"+i.ToString()+"_"+j.ToString()+"(Clone)";
				NGUITools.AddChild (transform.gameObject, prefab[i]);

				//string str = "ele"+i.ToString()+"(Clone)";
				transform.FindChild(str_origin).name = str_new;
				//Debug.Log(transform.FindChild(str_new).name);

				int x_pos,y_pos;
				do {
					x_pos = (int)Random.Range(0, length);
					y_pos = (int)Random.Range(0, height);
				} while(visit[x_pos, y_pos] == 1);

				GameObject obj = transform.FindChild(str_new).gameObject;
				obj.transform.localPosition = new Vector3(x_base+x_pos*(BLOCKWIHTH+1),y_base+y_pos*(BLOCKHEIGHT+1),0);
				obj.transform.localScale = new Vector3(BLOCKWIHTH,BLOCKHEIGHT, 1);
				visit[x_pos,y_pos] = 1;
				block[x_pos,y_pos] = obj;
				block_kind[x_pos,y_pos] = i;
				//Destroy (obj);
			}
		}

		#if true
		for (int i=0; i<length; i++) {
			for (int j=0; j<height; j++) {
				//Debug.Log (block [i, j].name);
				//block[i,j].SetActive(((i+j)%2==0)?true:false);
				block[i,j].AddComponent<click>();
				block[i,j].GetComponent<click>().kind = block_kind[i,j];
				block[i,j].AddComponent<BoxCollider2D>();

				//block[i,j].AddComponent<UIButtonMessage>();
				//UIButtonMessage btn= block[i,j].GetComponent<UIButtonMessage>();
				//btn.target = block[i,j];
				//btn.functionName = "fun";
				//btn.trigger = UIButtonMessage.Trigger.OnClick;
				//block[i,j].SetActive(false);

			}
		}
		#endif

		return true;
	}


	// Use this for initialization
	void Start () {
		if (GameObject.Find ("game(Clone)") != null) {
			if (false == init ()) {
				return;
			}
		}


	}

	void OnMouseDown(){
		//Debug.Log("mmmoused");
		//print ("dsadsadsa");

	}

	void onGUI(){

	}

	// Update is called once per frame
	void Update () {
		for (int i=0; i<length; i++) {
			for (int j=0; j<height; j++) {

			}
		}
	}
}
