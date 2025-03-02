using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Yeni Input Sistemi Kullanımı
        float moveX = Input.GetAxis("Horizontal"); // A-D (Sol-Sağ)
        float moveZ = Input.GetAxis("Vertical");   // W-S (İleri-Geri)

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if (move.magnitude > 1)
        {
            move.Normalize(); // Hareket vektörünü normalize et (çapraz hız problemini çözer)
        }

        controller.Move(move * speed * Time.deltaTime);

        // Yerçekimi Uygulama
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Hafif bir zıplama hissi için
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

