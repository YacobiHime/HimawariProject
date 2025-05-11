using UnityEngine;

public class HajimeMove : MonoBehaviour
{
    [SerializeField] float speed = 3; // 移動速度
    private Animator animator; // アニメーション制御用コンポーネント
    bool isidling; // 停止中かどうかの判定
    bool iscollided; // 何かに衝突しているかどうかの判定

    private void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
        //    DontDestroyOnLoad(this.gameObject); // このオブジェクトをシーンが変わっても破棄しない設定（必要に応じてコメントを外す）
    }

    void Update()
    {
        // 現在の位置を取得
        Vector2 pos = transform.position;
        bool isMoving = false; // 移動中かどうかの判定

        // 衝突していない場合のみ移動処理を行う
        if (!iscollided)
        {
            // 入力に応じて位置を更新
            if (Input.GetKey(KeyCode.RightArrow)) // →キーを押したら
            {
                pos.x += speed * Time.deltaTime; // 右に移動 (経過時間を考慮)
                animator.SetInteger("direction", 0);
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) // ←キーを押したら
            {
                pos.x -= speed * Time.deltaTime; // 左に移動 (経過時間を考慮)
                animator.SetInteger("direction", 1);
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.UpArrow)) // ↑キーを押したら
            {
                pos.y += speed * Time.deltaTime; // 上に移動 (経過時間を考慮)
                animator.SetInteger("direction", 2);
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow)) // ↓キーを押したら
            {
                pos.y -= speed * Time.deltaTime; // 下に移動 (経過時間を考慮)
                animator.SetInteger("direction", 3);
                isMoving = true;
            }

            // 移動中かどうかでisidlingフラグを設定
            isidling = !isMoving;

            // 位置を更新
            transform.position = pos;

            // アニメーションパラメーターを設定
            animator.SetBool("IsIdling", isidling);
        }
        else
        {
             // 衝突中は停止状態とみなす
            isidling = true;
            animator.SetBool("IsIdling", isidling);
        }
    }

    // 他のCollider2Dと接触を開始したときに呼ばれる
    // private void OnCollisionEnter2D(Collision2D other)
    // {
        // 接触したオブジェクトのタグが"Wall"の場合
        // if (other.gameObject.CompareTag("Wall"))
        // {
            // iscollided = true; // 衝突中フラグを立てる
        // }
    // }

    // 他のCollider2Dと接触が終了したときに呼ばれる
    // private void OnCollisionExit2D(Collision2D other)
    // {
        // 接触が終了したオブジェクトのタグが"Wall"の場合
        // if (other.gameObject.CompareTag("Wall"))
        // {
            // iscollided = false; // 衝突中フラグを下ろす
        // }
    // }
}