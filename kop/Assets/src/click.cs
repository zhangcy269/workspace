using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {
	generate g;
	public int kind;
	// Use this for initialization
	void Start () {
		if(GameObject.Find ("game(Clone)")!=null)
			g = GameObject.Find ("game(Clone)").GetComponent<generate>();
	}

	void fun(){
		Debug.Log ("ccclick");
	}

	void OnMouseDown(){
		if (g.preobj!=gameObject && g.flag == 0 && g.pre != -1 && g.pre == kind) {
			Destroy	(g.preobj);
			Destroy (gameObject);
			g.flag = 1;
		}
		else g.flag = 0;
		Debug.Log ("mousedown");
		g.pre = kind;
		g.preobj = gameObject;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
