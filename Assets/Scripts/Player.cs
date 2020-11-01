using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {

	public AudioSource pickUpPower;
	public float moveSpeed = 3.0f;
	[SerializeField]
	CharacterController player;
	public Text time;
	string currentTime;
	public float bonusMoveSpeed = 1f;
	public int bonusTime = 5;
	public static int[] teleports;
	void Start () {		
		player = gameObject.GetComponent<CharacterController>();
		currentTime = time.text;
		teleports = new int[2];
		teleports[0] = 0;
		teleports[1] = 0;
	}
	
	
	void Update () {		
		Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;		
		Vector3 movement = transform.TransformDirection(movementZ);
		player.Move(movement);
		if(Input.GetAxis("Horizontal") != 0)
        	{
            	transform.Rotate(0, 7 * Input.GetAxis("Horizontal"), 0);
        	}
	}

	private void OnTriggerEnter(Collider other)
	{
		int timer;
		GameObject help = other.gameObject;
		int index;
		if (other.gameObject.CompareTag("ms+"))
		{
			moveSpeed+=bonusMoveSpeed;
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
		if (other.gameObject.CompareTag("ms-"))
		{
			moveSpeed-=bonusMoveSpeed;
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
		if (other.gameObject.CompareTag("timer+"))
		{
			int.TryParse(time.text,out timer);
			timer += bonusTime;
			time.text = timer.ToString();
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
		if (other.gameObject.CompareTag("timer-"))
		{
			int.TryParse(time.text, out timer);
			timer -= bonusTime;
			time.text = timer.ToString();
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
		if (other.gameObject.CompareTag("teleport1+"))
		{
			teleports[0] = 1;
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
		if (other.gameObject.CompareTag("teleport1-"))
		{
			teleports[0] = 0;
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
		if (other.gameObject.CompareTag("teleport2+"))
		{
			teleports[1] = 1;
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
		if (other.gameObject.CompareTag("teleport2-"))
		{
			teleports[1] = 0;
			index = SpawnPickUps.ReturnIndex(SpawnPickUps.selectedPlaces, help);
			SpawnPickUps.packages.Remove(help);
			SpawnPickUps.takenPlaces.Remove(index);
			pickUpPower.Play();
		}
	}
}
