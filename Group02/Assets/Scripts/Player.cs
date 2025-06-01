using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Nếu bạn đang làm 2D top‐down (không muốn Gravity kéo), hãy tắt gravity:
        rb.gravityScale = 0f;
    }

    // Không gọi MovePlayer() ở Update, mà ở FixedUpdate
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Lấy input từ Input Manager (Horizontal, Vertical)
        Vector2 playerInput = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        // Chuẩn hóa để không đi nhanh hơn chéo góc, rồi nhân tốc độ
        rb.linearVelocity = playerInput.normalized * moveSpeed;

    }
}
