using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform arrowSpawnPoint;
    public float maxPullDistance = 2f;
    public float maxForce = 20f;

    private Vector2 initialMousePos;
    private bool isAiming;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartAiming();
        }

        if (Input.GetMouseButton(0))
        {
            Aim();
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseArrow();
        }
    }

    void StartAiming()
    {
        initialMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isAiming = true;
    }

    void Aim()
    {
        Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pullDirection = (initialMousePos - currentMousePos);
        float pullDistance = Mathf.Clamp(pullDirection.magnitude, 0, maxPullDistance);

        // Si el arco está mirando hacia arriba por defecto, ajusta el ángulo en consecuencia
        float angle = Mathf.Atan2(pullDirection.y, pullDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Visual representation of the aiming
        // Add your own logic for displaying the pulled bowstring
    }

    void ReleaseArrow()
    {
        if (!isAiming) return;

        Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pullDirection = (initialMousePos - currentMousePos);
        float pullDistance = Mathf.Clamp(pullDirection.magnitude, 0, maxPullDistance);
        float force = (pullDistance / maxPullDistance) * maxForce;

        GameObject arrow = PoolingManager.Instance.GetArrow();
        arrow.transform.position = arrowSpawnPoint.position;
        arrow.transform.rotation = transform.rotation;
        arrow.SetActive(true);
        arrow.GetComponent<Arrow>().Launch(transform.up, force); // Usa transform.up ya que el arco apunta hacia arriba

        isAiming = false;
    }
}
