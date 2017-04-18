using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	[SerializeField]
	private float _xMin;
	[SerializeField]
	private float _xMax;

	[SerializeField]
	private float _yMin;
	[SerializeField]
	private float _yMax;

	[SerializeField]
	private float _zMin;
	[SerializeField]
	private float _zMax;

	public void SetXMin(float xMin)
	{
		this._xMin = xMin;
	}

	public float GetXMin()
	{
		return _xMin;
	}

	public void SetXMax(float xMax)
	{
		this._xMax = xMax;
	}

	public float GetXMax()
	{
		return _xMax;
	}

	public void SetYMin(float yMin)
	{
		this._yMin = yMin;
	}

	public float GetYMin()
	{
		return _yMin;
	}

	public void SetYMax(float yMax)
	{
		this._yMax = yMax;
	}

	public float GetYMax()
	{
		return _yMax;
	}

	public void SetZMin(float zMin)
	{
		this._zMin = zMin;
	}

	public float GetZMin()
	{
		return _zMin;
	}

	public void SetZMax(float zMax)
	{
		this._zMax = zMax;
	}

	public float GetZMax()
	{
		return _zMax;
	}
}
