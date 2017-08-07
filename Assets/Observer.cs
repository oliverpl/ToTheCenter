using UnityEngine;

public class Observer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool GameOver { get; set; }
}
