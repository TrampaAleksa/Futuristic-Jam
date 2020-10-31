using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float moveSpeed = 3.0f;
	[SerializeField]
	CharacterController player;

	
	void Start () {		
		player = gameObject.GetComponent<CharacterController>();
	}
	
	
	void Update () {		
		Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;		
		Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;		
		Vector3 movement = transform.TransformDirection(movementZ+movementX);
		player.Move(movement);
	}
}
