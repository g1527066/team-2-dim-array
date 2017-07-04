using UnityEngine;
using System.Collections;

//カメラの初期設定用スクリプト
public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform t = this.transform;
        t.position = Vector3.zero;
        t.rotation = Quaternion.Euler(Vector3.zero);
        t.localScale = Vector3.one;

        Camera camera = this.GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color(49/255, 77/255, 121/255);
        camera.cullingMask = LayerMask.NameToLayer("Everything");
        camera.orthographic = true;
        camera.orthographicSize = 5.7f;
        camera.nearClipPlane = 0f;
        camera.farClipPlane = 1f;
        camera.rect = new Rect(0f, 0f, 1f, 1f);
        camera.depth = -1f;
        camera.renderingPath = RenderingPath.UsePlayerSettings;
        camera.targetTexture = null;
        camera.useOcclusionCulling = true;
        camera.hdr = false;
        camera.targetDisplay = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
