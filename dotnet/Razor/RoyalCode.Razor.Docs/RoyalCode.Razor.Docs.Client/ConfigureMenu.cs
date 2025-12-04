using RoyalCode.Razor.Layouts.Models;

namespace RoyalCode.Razor.Docs.Client;

public static class ConfigureMenu
{
    public static void AddMenuItems(this IServiceCollection services)
    {
        services.Configure<MenuOptions>(options =>
        {
            options.MenuItems.Add(new MenuItem
            {
                Id = "home",
                Text = "Home",
                Url = "/",
                Type = MenuItemType.Link
            });
            options.MenuItems.Add(new MenuItem
            {
                Id = "default-demo",
                Text = "Default Demo",
                Type = MenuItemType.Module,
                Children = 
                [
                    new MenuItem
                    {
                        Id = "counter",
                        Text = "Counter",
                        Url = "counter",
                        Type = MenuItemType.Link
                    },
                    new MenuItem
                    {
                        Id = "weather",
                        Text = "Weather",
                        Url = "weather",
                        Type = MenuItemType.Link
                    }
                ]
            });
            options.MenuItems.Add(new MenuItem
            {
                Id = "ya-demo",
                Text = "Yasamen Components Demo",
                Type = MenuItemType.Module,
                Children =
                [
                    new MenuItem
                    {
                        Id = "layouts",
                        Text = "App Layouts",
                        Type = MenuItemType.Module,
                        Children =
                        [
                            new MenuItem
                            {
                                Id = "app-layout",
                                Text = "App Layout",
                                Url = "app-layout",
                                Type = MenuItemType.Link
                            },
                            new MenuItem
                            {
                                Id = "app-menu",
                                Text = "App Menu",
                                Type = MenuItemType.Module,
                                Children =
                                [
                                    new MenuItem
                                    {
                                        Id = "app-menu-a",
                                        Text = "Menu A",
                                        Type = MenuItemType.Module,
                                        Children =
                                        [
                                            new MenuItem
                                            {
                                                Id = "app-menu-b",
                                                Text = "Menu B",
                                                Type = MenuItemType.Module,
                                                Children = [
                                                    new MenuItem
                                                    {
                                                        Id = "app-menu-c",
                                                        Text = "Menu C",
                                                        Type = MenuItemType.Module,
                                                        Children = [
                                                            new MenuItem
                                                            {
                                                                Id = "app-menu-d",
                                                                Text = "Menu D",
                                                                Type = MenuItemType.Module,
                                                                Children = [
                                                                    new MenuItem
                                                                    {
                                                                        Id = "app-menu-e",
                                                                        Text = "Menu E",
                                                                        Url = "app-layout",
                                                                        Type = MenuItemType.Link,
                                                                    }
                                                                ]
                                                            }
                                                        ]
                                                    },
                                                ]
                                            },
                                        ]
                                    },
                                ]
                            },
                        ]
                    },
                    new MenuItem
                    {
                        Id = "commons",
                        Text = "Commons",
                        Type = MenuItemType.Module,
                        Children =
                        [
                            new MenuItem
                            {
                                Id = "elementjs",
                                Text = "Elements",
                                Url = "demo/commons/elementjs",
                                Type = MenuItemType.Link
                            }
                        ]
                    },
                    new MenuItem
                    {
                        Id = "buttons",
                        Text = "Buttons",
                        Url = "buttons",
                        Type = MenuItemType.Link
                    },
                    new MenuItem
                    {
                        Id = "icon-buttons",
                        Text = "Icon Buttons",
                        Url = "icon-buttons",
                        Type = MenuItemType.Link
                    },
                    new MenuItem
                    {
                        Id = "modals",
                        Text = "Modals",
                        Url = "modals",
                        Type = MenuItemType.Link
                    },
                    new MenuItem
                    {
                        Id = "drops",
                        Text = "Drops",
                        Url = "drops",
                        Type = MenuItemType.Link
                    }
                ]
            });
        });
    }
}
