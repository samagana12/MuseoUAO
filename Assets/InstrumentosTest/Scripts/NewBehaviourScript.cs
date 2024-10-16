using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Camera mainCamera;        // Cámara principal
    private GameObject selectedObject; // El objeto actualmente seleccionado
    private Vector3 offset;            // Distancia entre el objeto y el punto de clic
    private float zCoord;              // Coordenada Z en la que se moverá el objeto

    void Start()
    {
        // Obtener la cámara principal
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            TryPickObject();
        }

        // Si hay un objeto seleccionado, moverlo con el mouse
        if (selectedObject != null)
        {
            MoveObjectWithMouse();
        }

        // Soltar el objeto cuando se suelta el clic
        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }
    }

    // Intentar seleccionar un objeto
    void TryPickObject()
    {
        // Obtener la posición del mouse en la pantalla
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Realizar un raycast para detectar si estamos haciendo clic en un objeto con colisión
        if (Physics.Raycast(ray, out hit))
        {
            // Guardar el objeto que hemos seleccionado
            selectedObject = hit.transform.gameObject;

            // Obtener la coordenada Z del objeto (para mantenerlo en el mismo plano de profundidad)
            zCoord = mainCamera.WorldToScreenPoint(selectedObject.transform.position).z;

            // Calcular el offset entre el punto de clic y la posición del objeto
            offset = selectedObject.transform.position - GetMouseWorldPos();
        }
    }

    // Mover el objeto seleccionado con el mouse
    void MoveObjectWithMouse()
    {
        // Mover el objeto a la posición del mouse, manteniendo el offset calculado
        selectedObject.transform.position = GetMouseWorldPos() + offset;
    }

    // Obtener la posición del mouse en el mundo
    Vector3 GetMouseWorldPos()
    {
        // Crear un vector con la posición del mouse y la coordenada Z del objeto
        Vector3 mousePoint = Input.mousePosition;

        // Añadir la coordenada Z del objeto para que mantenga su profundidad
        mousePoint.z = zCoord;

        // Convertir la posición de la pantalla a coordenadas del mundo
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
