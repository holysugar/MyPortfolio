﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionAttach : ColorAttach
{
	[SerializeField] private Sprite _attach = null;
	[SerializeField] private List<SpriteRenderer> Dandelion_growth = new List<SpriteRenderer>();
	private enum PHASE_GROWTH {
		PHASE_0,
		PHASE_1,
		PHASE_2,
	};
	private PHASE_GROWTH _phase = PHASE_GROWTH.PHASE_0;
	private float _time = 0.0f;

	private void Start()
	{
		enabled = false;
	}

	protected override void Regain()
	{
		rend.sprite = _attach;
		box2D.enabled = false;
		StartCoroutine(GoSignal());
	}

	private IEnumerator GoSignal()
	{
		yield return new WaitForSeconds(0.4f);
		enabled = true;
	}

	private void Update()
	{
		switch (_phase) {
			case PHASE_GROWTH.PHASE_0:
				actOnPhase0();
				break;
			case PHASE_GROWTH.PHASE_1:
				actOnPhase1();
				break;
			case PHASE_GROWTH.PHASE_2:
				actOnPhase2();
				break;
		}
	}

	private void actOnPhase0()
	{
		_time += getDeltaTime();
		setAlpha(1 - _time, Dandelion_growth[(int)_phase]);
		setAlpha(_time, Dandelion_growth[(int)_phase + 1]);

		if (_time >= 1.5f) {
			_phase = PHASE_GROWTH.PHASE_1;
			_time = 0.0f;
		}
	}

	private void actOnPhase1()
	{
		_time += getDeltaTime();
		setAlpha(1 - _time, Dandelion_growth[(int)_phase]);
		setAlpha(_time, Dandelion_growth[(int)_phase + 1]);
		if (_time >= 1.5f) {
			_phase = PHASE_GROWTH.PHASE_2;
			_time = 0.0f;
		}
	}

	private void actOnPhase2()
	{
		_time += getDeltaTime();
		setAlpha(1 - _time, Dandelion_growth[(int)_phase]);
		setAlpha(_time, Dandelion_growth[(int)_phase + 1]);
		if (_time >= 1.5f) {
			enabled = false;
			_player.PlayerAnimationChange(Player.ANIM_TYPE.ANIM_TYPE_GLAD);
			_barrier.ChildKill();
		}
	}

	private float getDeltaTime()
	{
		return Time.unscaledDeltaTime;
	}

	private void setAlpha(float alpha, SpriteRenderer rend)
	{
		Color color = rend.color;
		rend.color = new Color(color.r, color.g, color.b, alpha);
	}
}
