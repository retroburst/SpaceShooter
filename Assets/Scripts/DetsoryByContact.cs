using UnityEngine;
using System.Collections;

/// <summary>
/// Detsory by contact.
/// Responsible for destroying game objects
/// based on collisions.
/// </summary>
public class DetsoryByContact : MonoBehaviour
{
	private const string TAG_BOUNDARY = "Boundary";
	private const string TAG_PLAYER = "Player";
	public GameObject explosion = null;
	public GameObject playerExplosion = null;
	public int points = 10;
	private GameController gameController = null;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		GameObject gameControllerGameObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerGameObject != null) {
			gameController = gameControllerGameObject.GetComponent<GameController> ();
			if (gameController == null) {
				Debug.LogError ("Could not get a reference to GameController script.");
			}
		}
	}
	
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="otherCollider">Other collider.</param>
	private void OnTriggerEnter (Collider otherCollider)
	{
		Debug.Log ("otherCollider name is: " + otherCollider.name);
		if (otherCollider.tag == TAG_BOUNDARY) {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (otherCollider.tag == TAG_PLAYER) {
			gameController.PlayerDestroyed ();
			Instantiate (playerExplosion, otherCollider.transform.position, otherCollider.transform.rotation);
		}
		Destroy (otherCollider.gameObject);
		if (gameObject.transform.parent != null) {
			Destroy (transform.parent.gameObject);
		}
		Destroy (gameObject);
		gameController.AddScore (points);
	}

}
