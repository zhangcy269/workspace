using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	public GameObject prefab;

	public void fun(){
		Debug.Log ("clicbbk");
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() {
		//GameObject obj = GameObject.Instantiate (prefab) as GameObject;
		GameObject root = GameObject.Find ("Anchor") as GameObject;
		GameObject enter = GameObject.Find ("enter") as GameObject;
		//obj.transform.parent. = root;
		NGUITools.AddChild (root, prefab);
		GameObject obj = GameObject.Find("game(Clone)");
		obj.AddComponent<generate> ();
		//Destroy (obj);
		enter.SetActive (false);
	}
}
