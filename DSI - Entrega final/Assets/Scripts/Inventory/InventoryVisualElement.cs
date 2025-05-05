using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UIElements;
public class InventoryVisualElement : VisualElement
{
    const uint anchoSprite = 132;
    Texture2D spriteShit = Resources.Load<Texture2D>("Sprites"); 

    VisualElement elem = new VisualElement();
    Texture2D actText = new Texture2D((int)anchoSprite, (int)anchoSprite);
    uint estado;
    
    public uint Estado
    {
        get => estado;
        set
        {
            estado = value;
            cambiarElemento();
        }
    }
    void cambiarElemento()
    {
        Debug.Log(spriteShit.GetPixels());
        //por arreglar
        uint modulo = estado % 22;
        Color[] temp = spriteShit.GetPixels((int)(anchoSprite * (modulo % 6)) , (int)(anchoSprite * 3 - anchoSprite * (modulo / 6)),(int) anchoSprite,(int) anchoSprite);
        actText.SetPixels(temp);
        actText.Apply();

        elem.style.backgroundImage = actText;
    }

    public new class UxmlFactory : UxmlFactory<InventoryVisualElement, UxmlTraits> { };
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myEstado = new UxmlIntAttributeDescription { name = "estado", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var elemento = ve as InventoryVisualElement;
            elemento.Estado = (uint)myEstado.GetValueFromBag(bag, cc);        
        }
    }

    public InventoryVisualElement()
    {
        elem.style.width = 100;
        elem.style.height = 100;

        hierarchy.Add(elem);
    }
}