﻿using System.Collections.Generic;
using UnityEngine;

public class SetSourceAnimation : MonoBehaviour
{
	[SerializeField] private List<Animator> _sourceAnimators = new List<Animator>();
	private Animator _possession_color = null;
	private ColorAbsorption _stockColor = null;

	private void Start()
	{
		Initialise();
	}

    private void Initialise()
    {
        foreach (Animator sourceAnimator in _sourceAnimators) {
            sourceAnimator.SetBool(sourceAnimator.gameObject.name, true);
        }
    }
}
