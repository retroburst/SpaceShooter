using UnityEngine;
using System.Collections;

/// <summary>
/// Boundary controller.
/// Responsible for destroying game objects
/// that go passed the boundary.
/// </summary>
public class BoundaryController : MonoBehaviour
{
	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="otherCollider">Other collider.</param>
	private void OnTriggerExit (Collider otherCollider)
	{
		if (otherCollider.transform.parent != null) {
			Destroy (otherCollider.transform.parent.gameObject);
		} else {
			Destroy (otherCollider.gameObject);
		}
	}
	
}
