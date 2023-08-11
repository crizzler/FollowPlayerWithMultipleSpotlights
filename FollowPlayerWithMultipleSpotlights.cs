using UnityEngine;

public class FollowPlayerWithMultipleSpotlights : MonoBehaviour
{
	public Transform player; // Player's transform.
	public Spotlight[] spotlights; // Array of spotlights.

	[System.Serializable]
	public class Spotlight
	{
		public Transform spotlightTransform;
		public float followSpeed = 2.0f;
		public float rotationSpeed = 2.0f;
		public float orbitSpeed = 30.0f;
		public float orbitRadius = 0.5f;
		[HideInInspector]
		public Vector3 offset;
		public bool rotateClockwise = true;
		public bool shouldRotate = true;
	}

	private void Start()
	{
		InitializeSpotlightOffsets();
	}

	private void Update()
	{
		foreach (var light in spotlights)
		{
			UpdateSpotlightPosition(light);
			UpdateSpotlightRotation(light);
		}
	}

	private void InitializeSpotlightOffsets()
	{
		foreach (var light in spotlights)
		{
			light.offset = light.spotlightTransform.position - player.position;
		}
	}

	private void UpdateSpotlightPosition(Spotlight light)
	{
		Vector3 desiredPosition = player.position + light.offset;

		if (light.shouldRotate)
		{
			desiredPosition = ComputeOrbitPosition(light, desiredPosition);
		}

		light.spotlightTransform.position = Vector3.Lerp(light.spotlightTransform.position, desiredPosition, light.followSpeed * Time.deltaTime);
	}

	private Vector3 ComputeOrbitPosition(Spotlight light, Vector3 desiredPosition)
	{
		float rotationDirection = light.rotateClockwise ? 1 : -1;
		Vector3 nextPosition = RotatePointAroundPivot(desiredPosition, player.position, Vector3.up * rotationDirection * light.orbitSpeed * Time.deltaTime);

		Vector3 toPlayer = nextPosition - player.position;
		Vector3 orbitPosition = player.position + toPlayer.normalized * light.orbitRadius;

		light.offset = orbitPosition - player.position;
		return Vector3.Lerp(desiredPosition, orbitPosition, light.followSpeed * Time.deltaTime);
	}

	private void UpdateSpotlightRotation(Spotlight light)
	{
		Quaternion targetRotation = Quaternion.LookRotation(player.position - light.spotlightTransform.position);
		light.spotlightTransform.rotation = Quaternion.Slerp(light.spotlightTransform.rotation, targetRotation, light.rotationSpeed * Time.deltaTime);
	}

	private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		return Quaternion.Euler(angles) * (point - pivot) + pivot;
	}
}
