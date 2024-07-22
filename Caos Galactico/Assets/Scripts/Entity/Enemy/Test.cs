using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public float shootInterval = 1.0f;  // Intervalo entre disparos
    public int numberOfProjectiles = 10; // Número de proyectiles en la espiral
    public float projectileSpeed = 5.0f; // Velocidad del proyectil
    public float rotationSpeed = 30.0f; // Velocidad de rotación en grados por segundo

    private float timer;
    private float currentAngle = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            FireProjectiles();
            timer = 0f;
        }

        // Incrementar el ángulo para la próxima ráfaga
        currentAngle += rotationSpeed * Time.deltaTime;
    }

    void FireProjectiles()
    {
        float angleStep = 360f / numberOfProjectiles;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = currentAngle + (i * angleStep);
            float projectileDirX = Mathf.Sin(angle * Mathf.Deg2Rad);
            float projectileDirZ = Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector3 projectileDirection = new Vector3(projectileDirX, 0, projectileDirZ);
            Vector3 spawnPosition = transform.position + projectileDirection;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            rb.velocity = projectileDirection * projectileSpeed;
        }
    }
}