
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Commons.Chaining;

public class ComponentChainContext<TChainModel>
{
    private readonly List<ComponentChainNode<TChainModel>> nodes = new();
    private readonly bool ordinationIsImportant;
    private ComponentChainNode<TChainModel>? lastNode;

    internal ComponentChainContext(
        RenderFragment<ComponentChainModel<TChainModel>>? renderFragment,
        bool ordinationIsImportant)
    {
        RenderFragment = renderFragment;
        this.ordinationIsImportant = ordinationIsImportant;
    }

    public RenderFragment<ComponentChainModel<TChainModel>>? RenderFragment { get; }

    internal void Register(ComponentChainNode<TChainModel> node)
    {
        lock (nodes)
        {
            lastNode = node;
            nodes.Add(node);
        }
    }

    internal void Render(TChainModel model)
    {
        ComponentChainNode<TChainModel>? currentLast;

        lock (nodes)
        {
            currentLast = lastNode;
            var node = ordinationIsImportant
                ? FindReverseFreeNode()
                : nodes.FirstOrDefault(n => n.Render.IsFree);
            if (node is not null)
            {
                Console.WriteLine("ComponentChainContext ---> Node livre encontrado");
                Render(model, node);
                return;
            }
            else
            {
                Console.WriteLine("ComponentChainContext ---> Novo Node será criado");
            }

            currentLast?.Next.CreateChild(node =>
            {
                Render(model, node);
            });
        }
    }

    private ComponentChainNode<TChainModel>? FindReverseFreeNode()
    {
        ComponentChainNode<TChainModel>? lastFree = null;
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            var node = nodes[i];
            if (node.Render.IsFree)
                lastFree = node;
            else
                break;
        }
        return lastFree;
    }

    private void Render(TChainModel model, ComponentChainNode<TChainModel> node)
    {
        var render = node.Render;
        var reference = new ComponentChainReference(render);
        var chainModel = new ComponentChainModel<TChainModel>(model, reference);
        render.Render(chainModel);
    }
}
