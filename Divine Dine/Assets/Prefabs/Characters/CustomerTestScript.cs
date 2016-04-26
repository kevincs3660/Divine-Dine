using UnityEngine;
using System.Collections;

public class CustomerTestScript : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator> ();
		//anim.Play ("Walk");
		anim.SetInteger ("Transition", 1);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (anim.GetCurrentAnimatorStateInfo (0).IsName("Idle"));
		Debug.Log (anim.GetCurrentAnimatorStateInfo (0).IsName("Walk"));
	}
}
