using UnityEngine;
using System.Collections;

public class FlipbookAnimation : MonoBehaviour {
	
	public float Rate;
	public int NumSlots;
	public float DeltaX;
	
	private float _FlipTime;
	private int _FlipIndex;
	
	// Use this for initialization
	void Start () {
		_FlipTime = Time.time;
		_FlipIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
				
		if(Time.time - _FlipTime > Rate)
		{			
			Material mat = gameObject.renderer.material;
			float size = (NumSlots == 0) ? 1.0f : 1.0f/NumSlots;
			_FlipIndex = (_FlipIndex + 1) % NumSlots;
			float x_offset = (float)(_FlipIndex) * size;
			
			//transform.Translate(new Vector3(DeltaX, 0.0f, 0.0f));
		
			print("Update..." + size + ", index: " + _FlipIndex + ", offset: " + x_offset);
			//mat.mainTextureOffset.Set(x_offset, 0.0f);
			mat.SetTextureOffset("_MainTex", new Vector2(x_offset, 0.0f));
			_FlipTime = Time.time;
		}
		transform.Translate(new Vector3(DeltaX*Time.deltaTime, 0.0f, 0.0f));
	}
}
