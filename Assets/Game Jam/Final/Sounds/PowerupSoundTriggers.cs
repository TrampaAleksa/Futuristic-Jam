using UnityEngine;

public class PowerupSoundTriggers : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject help = other.gameObject;

        if (other.gameObject.CompareTag("ms+"))
        {
            Debug.Log("power up: " + other.tag);
            PowerUpSounds.Instance.speedUp.Play();
        }
        else if (other.gameObject.CompareTag("ms-"))
        {
            Debug.Log("power up: " + other.tag);
            PowerUpSounds.Instance.speedDown.Play();
        }
        else if (other.gameObject.CompareTag("timer+"))
        {
            Debug.Log("power up: " + other.tag);
            PowerUpSounds.Instance.timeUp.Play();
        }
        else if (other.gameObject.CompareTag("timer-"))
        {
            Debug.Log("power up: " + other.tag);
            PowerUpSounds.Instance.timeDown.Play();
        }
        else if (other.gameObject.CompareTag("teleport+"))
        {
            Debug.Log("power up: " + other.tag);
            PowerUpSounds.Instance.teleportOn.Play();
        }
        else if (other.gameObject.CompareTag("teleport-"))
        {
            Debug.Log("power up: " + other.tag);
            PowerUpSounds.Instance.teleportOff.Play();
        }
    }
}