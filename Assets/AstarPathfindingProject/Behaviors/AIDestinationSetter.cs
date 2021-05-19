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
		public Transform playerTarget;
		public changeMusic bgm;
		public int killPlayerDistance = 30;
		public int searchPebbleRange = 50;
		public float moveSpeed = 300.0f;
		public float rotSpeed = 100f;
		


		private GameObject[] pebbles;
		private int pointer = 1;
		private bool randomBegin = true;
		private int rotLorR = 0;
		private int rotTime = 0;
		private int walkTime = 0;
		private int rotWait = 0;
		private int walkWait = 0;
		private int timeCounter = 0;
		private bool once = true;


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
				Vector3 heading = playerTarget.position - transform.position;
				if (heading.magnitude < killPlayerDistance)		// Witch is beside the player
				{
					target = playerTarget;
					ai.destination = target.position;
					if (once)
					{
						bgm.change2Found();
						once = false;
					}
				}
				else
				{
					if (!once)
					{
						bgm.change2Original();
						once = true;
					}
					pebbles = GameObject.FindGameObjectsWithTag("Pebble");
					if (pebbles.Length>1) 
					{
						pointer = findClosestPebble(pebbles);
		
						heading = pebbles[pointer].transform.position - transform.position;
						if (heading.magnitude < searchPebbleRange)		// Witch is beside the closest pebble
						{
							if (heading.magnitude > 3)
							{
								pebbles[pointer].transform.gameObject.tag = "SearchedPebble";
							}
							else
							{
								target = pebbles[pointer].transform;
								ai.destination = target.position;
							}
							
						}
						else 
						{
							// Random Walk
							if (randomBegin)
							{
								rotTime = Random.Range(1,2) * 100;
								rotWait = Random.Range(1,2) * 100 + rotTime;
								rotLorR = Random.Range(1,2);
								walkTime = Random.Range(1,4) * 100 + rotWait;
								walkWait = Random.Range(1,2) * 100 + walkTime;
								randomBegin = false;
							}

							if (rotLorR == 1 && timeCounter < rotTime)
							{
								transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
								timeCounter += 1;
							}
							else if (rotLorR == 2 && timeCounter < rotTime)
							{
								transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
								timeCounter += 1;
							}
							else if (rotWait < timeCounter && timeCounter < walkTime)
							{
								transform.position += transform.forward * moveSpeed * Time.deltaTime;
								timeCounter += 1;
							}
							else if (walkTime < timeCounter && timeCounter < walkWait)
							{
								timeCounter = 0;
								randomBegin = true;
							}
							else 
							{
								timeCounter += 1;
							}
						}
					}
					else 
					{
						// Random walk
						if (randomBegin)
						{
							rotTime = Random.Range(1,2) * 100;
							rotWait = Random.Range(1,2) * 100 + rotTime;
							rotLorR = Random.Range(1,2);
							walkTime = Random.Range(1,4) * 100 + rotWait;
							walkWait = Random.Range(1,2) * 100 + walkTime;
							randomBegin = false;
						}

						if (rotLorR == 1 && timeCounter < rotTime)
						{
							transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
							timeCounter += 1;
						}
						else if (rotLorR == 2 && timeCounter < rotTime)
						{
							transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
							timeCounter += 1;
						}
						else if (rotWait < timeCounter && timeCounter < walkTime)
						{
							transform.position += transform.forward * moveSpeed * Time.deltaTime;
							timeCounter += 1;
						}
						else if (walkTime < timeCounter && timeCounter < walkWait)
						{
							timeCounter = 0;
							randomBegin = true;
						}
						else 
						{
							timeCounter += 1;
						}
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
