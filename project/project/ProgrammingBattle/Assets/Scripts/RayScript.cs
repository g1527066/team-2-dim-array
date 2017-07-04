using UnityEngine;

//マウスで触っているものの名前を取得するメソッド、よそから呼び出して使う
public class RayScript : MonoBehaviour
{
    //どのカメラを使ってRayを作成するかが引数として必要
    public static string getObj(Camera cam)
    {
        Transform result = null;
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        #if UNITY_EDITOR
        Debug.DrawRay(mouseRay.origin, mouseRay.direction, Color.red, 1);
        #endif

        if (Physics.Raycast(mouseRay, out hit))
        {
            result = hit.transform;
            return result.name;
        }
        return "null";
    }
}
