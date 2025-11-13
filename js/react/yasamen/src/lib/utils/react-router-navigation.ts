
import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';
import { setNavigator, type Navigator } from '../components/commons';

// Hook que cria o adapter baseado no hook do react-router
function useReactRouterNavigationAdapter(): Navigator {
    const navigate = useNavigate();
    return { navigate: (to: string) => navigate(to) };
}

// Hook de setup: deve ser chamado dentro de um componente React (ex: App root)
// Responsável por registrar o adapter no registry global. Assim evitamos violar regras de hooks.
export function useSetupReactRouterNavigator(): void {
    const adapter = useReactRouterNavigationAdapter();
    useEffect(() => {
        setNavigator(adapter);
    }, [adapter]);
}

// Componente opcional para quem preferir JSX em vez de chamar o hook manualmente.
export function ReactRouterNavigatorProvider() {
    useSetupReactRouterNavigator();
    return null;
}