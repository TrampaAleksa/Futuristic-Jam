using UnityEngine;

public class PowerupSoundTriggers : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject help = other.gameObject;
        var delay = 0.4f;

        if (other.gameObject.CompareTag("ms+"))
        {
            Debug.Log("power up: " + other.tag);
            SoundsHolder.Instance.speedUp.PlayDelayed(delay);
        }
        else if (other.gameObject.CompareTag("ms-"))
        {
            Debug.Log("power up: " + other.tag);
            SoundsHolder.Instance.speedDown.PlayDelayed(delay);
        }
        else if (other.gameObject.CompareTag("timer+"))
        {
            Debug.Log("power up: " + other.tag);
            // PowerUpSounds.Instance.timeUp.PlayDelayed(delay);
        }
        else if (other.gameObject.CompareTag("timer-"))
        {
            Debug.Log("power up: " + other.tag);
            // PowerUpSounds.Instance.timeDown.PlayDelayed(delay);
        }
        else if (other.gameObject.CompareTag("teleport+"))
        {
            Debug.Log("power up: " + other.tag);
            SoundsHolder.Instance.teleportOn.PlayDelayed(delay);
        }
        else if (other.gameObject.CompareTag("teleport-"))
        {
            Debug.Log("power up: " + other.tag);
            SoundsHolder.Instance.teleportOff.PlayDelayed(delay);
        }
    }
}