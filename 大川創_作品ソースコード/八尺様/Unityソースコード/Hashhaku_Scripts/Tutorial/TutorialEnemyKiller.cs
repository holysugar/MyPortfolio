﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialEnemyKiller : MonoBehaviour
{
	[SerializeField]private Animator _volume = null;
	[SerializeField]private GameObject _endText = null;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			_volume.SetTrigger("StopChase");
			collision.gameObject.SetActive(false);
			_endText.SetActive(true);
			Destroy(gameObject);
		}
	}
}
