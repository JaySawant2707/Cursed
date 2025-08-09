using UnityEngine;
using UnityEngine.EventSystems;

public class SelectObjectUI : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material selectionMaterial;
    [SerializeField] private LayerMask selectableLayer;

    Material originalMaterialHighlight;
    Material originalMaterialSelection;

    Transform highlight;
    Transform selection;

    MeshRenderer highlightRenderer;
    MeshRenderer selectionRenderer;

    RaycastHit raycastHit;

    void Update()
    {
        HandleHighlight();
        HandleSelection();
    }

    private void HandleHighlight()
    {
        if (highlight != null)
        {
            if (highlightRenderer != null)
                highlightRenderer.material = originalMaterialHighlight;

            highlight = null;
            highlightRenderer = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() &&
            Physics.Raycast(ray, out raycastHit, Mathf.Infinity, selectableLayer))
        {
            Transform target = raycastHit.transform;
            MeshRenderer targetRenderer = target.GetComponent<MeshRenderer>();

            if (target != selection && targetRenderer != null)
            {
                highlight = target;
                highlightRenderer = targetRenderer;

                if (highlightRenderer.material != highlightMaterial)
                {
                    originalMaterialHighlight = highlightRenderer.material;
                    highlightRenderer.material = highlightMaterial;
                }
            }
        }
    }

    private void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (highlight != null) 
            {
                if (selectionRenderer != null && selectionRenderer.material != selectionMaterial)
                {
                    originalMaterialSelection = selectionRenderer.material;
                    selectionRenderer.material = selectionMaterial;
                }

                ClickLogic(highlight.gameObject);

                highlight = null;
                highlightRenderer = null;
            }
            else
            {
                if (selection != null && selectionRenderer != null)
                {
                    selectionRenderer.material = originalMaterialSelection;
                    selection = null;
                    selectionRenderer = null;
                }
            }
        }
    }

    void ClickLogic(GameObject obj)
    {
        WorldButton btn = obj.GetComponent<WorldButton>();
        if (btn != null)
        {
            btn.OnClickWorldButton();
        }
    }
}
