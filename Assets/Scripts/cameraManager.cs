using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{

    public GameObject target; // 追従する対象を決める変数
    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("追従対象が設定されていません！");
            return; // 対象が設定されていない場合は処理を中断
        }

        Vector3 cameraPos = target.transform.position; // cameraPosという変数を作り、追従する対象の位置を入れる

        cameraPos.z = -10; // カメラの奥行きの位置に-10を入れる (ここはそのまま)

        Camera.main.gameObject.transform.position = cameraPos; //　カメラの位置に変数cameraPosの位置を入れる
    }
}