using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		// public Transform target;
		IAstarAI ai;
		
		public Transform target;
		private GameObject[] pebbles;
		private int pointer = 1;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>

		void Update () {
			// if (target != null && ai != null) ai.destination = target.position;
			if (ai != null)
			{
				pebbles = GameObject.FindGameObjectsWithTag("Pebble");
				if (pebbles.Length>1) 
				{
					pointer = findClosestPebble(pebbles);
	
					Vector3 heading = pebbles[pointer].transform.position - transform.position;
					if (heading.magnitude > 3)		// Witch is beside the closest pebble
					{
						target = pebbles[pointer].transform;
						ai.destination = target.position;
					}
					else
					{
						pebbles[pointer].transform.gameObject.tag = "SearchedPebble";
					}
					
				}
			}
		}

		int findClosestPebble(GameObject[] pebbles)
		{
			int idx = 1;
			Vector3 heading = pebbles[idx].transform.position - transform.position;
			float min = heading.magnitude;
			for (int i = 2; i < pebbles.Length; i++)
			{
				heading = pebbles[i].transform.position - transform.position;
				if (heading.magnitude < min) 
				{
					min = heading.magnitude;
					idx = i;
				}
			}
			return idx;
		}
	}
}
