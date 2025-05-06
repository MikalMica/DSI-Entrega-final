using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DangerousManipulator : Manipulator
{
    private bool selected = true;
    VisualElement root;

    public DangerousManipulator(VisualElement root) { this.root = root; }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<ClickEvent>(ChangeSelection);
        target.RegisterCallback<MouseEnterEvent>(MouseHover);
        target.RegisterCallback<MouseLeaveEvent>(MouseNotHover);

    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<ClickEvent>(ChangeSelection);
        target.UnregisterCallback<MouseEnterEvent>(MouseHover);
        target.UnregisterCallback<MouseLeaveEvent>(MouseNotHover);
    }

    private void MouseHover(MouseEnterEvent e)
    {
        Label text = target.Q<Label>("Label");
        text.style.color = new Color(0.789f, 0.475f, 0.768f);
        e.StopPropagation();
    }

    private void MouseNotHover(MouseLeaveEvent e)
    {
        Label text = target.Q<Label>("Label");
        if (selected)
        {
            text.style.color = Color.white;
        }
        else
        {
            text.style.color = Color.gray;
        }
        e.StopPropagation();
    }

    private void ChangeSelection(ClickEvent e)
    {
        Label text = target.Q<Label>("Label");
        if (selected)
        {
            text.style.color = Color.gray;
        }
        else
        {
            text.style.color = Color.white;
        }
        selected = !selected;

        List<VisualElement> vs = root.Query(className: "dangerousEnemy").ToList();
        foreach (VisualElement v in vs)
        {
            if (!selected) v.AddToClassList("noTint");
            else v.RemoveFromClassList("noTint");
        }

        e.StopPropagation();
    }
}
