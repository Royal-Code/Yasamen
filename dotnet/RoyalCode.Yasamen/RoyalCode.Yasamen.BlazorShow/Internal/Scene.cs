﻿using System.Reflection;
using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.BlazorShow.Internal;

public class Scene<TComponent> : IScene<TComponent>
    where TComponent : class, IComponent
{
    private ShowRenderKind? renderKind;
    private readonly List<ScenePropertyDescription> sceneProperties;

    public Scene(IShowDescription show)
    {
        Show = show;
        sceneProperties = show.Properties.Select(p => new ScenePropertyDescription(p)).ToList();
    }
    
    public bool IsDefault { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public TextAlign Align { get; set; } = TextAlign.Middle;

    public IShowDescription Show { get; }
    
    public ShowRenderKind? RenderKind 
    {
        get => renderKind ?? Show.RenderKind;
        set => renderKind = value;
    }
    
    public FrameOptions FrameOptions { get; } = new FrameOptions();

    public IEnumerable<IScenePropertyDescription> SceneProperties => sceneProperties;

    public string GetRoute()
    {
        var route = Show.Route ?? Show.Name ?? Show.ComponentType.Name;
        
        if (IsDefault)
            return route;
        
        return $"{route}/{Name}";
    }

    public ScenePropertyDescription? FindPropertyDescription(PropertyInfo propertyInfo)
    {
        return sceneProperties.FirstOrDefault(p => p.Property.Name == propertyInfo.Name);
    }
}