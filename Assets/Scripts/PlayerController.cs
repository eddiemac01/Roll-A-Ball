using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	public float speed;
	public GUIText countText;
	public GUIText winText;
	public GUIText timeText;
	public static float timecount;
	public static float starttime;
	private int count;

	void Start ()
	{
		count = 0;
		SetCountText ();
		winText.text = "";
		starttime = Time.time;
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		timecount = Time.time - starttime;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		timeText.text = timecount.ToString ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "YOU WIN!";
		}
	}
}