import React from 'react';
import { Outlet } from 'react-router-dom';
import AppLayout from '../../lib/components/layouts/apps/AppLayout';
import { Bar } from '../../lib/components/layouts';
import { Button } from '../../lib/components/button';
import { IconButton } from '../../lib/components/button';
import { Link, useLocation } from 'react-router-dom';
import { BsIcons } from '../../lib/components/bsicons';
import { ModalOutlet } from '../../lib/components/modal/ModalOutlet';
import { SectionOutlet } from '../../lib/components/outlet';

/**
 * DemoMainLayout
 * Um layout raiz para o site demo, equivalente conceitual ao MainLayout do Razor / Blazor.
 * Encapsula cabeçalho (Top), menus laterais, conteúdo principal, rodapé e permite conteúdo pré e pós.
 */
const DemoMainLayout: React.FC = () => {
	const location = useLocation();

	const navLinkClass = (path: string) => [
		'px-3 py-2 text-sm rounded transition-colors',
		location.pathname === path
			? 'bg-primary-500 text-white hover:bg-primary-600'
			: 'text-primary-700 hover:bg-primary-100'
	].join(' ');

	return (
		<AppLayout>
			<AppLayout.PreContent>
				{/* Espaço antes do layout principal se necessário */}
				<ModalOutlet />
			</AppLayout.PreContent>

			<AppLayout.Top>
				<Bar className="px-4 h-full">
					<Bar.Start>
						<div className="font-semibold text-primary-700">
							<span>Yasamen Demo</span>
						</div>
					</Bar.Start>
					<Bar.Center>
						<nav className="flex flex-wrap gap-2">
							<Link to="/" className={navLinkClass('/')}>Home</Link>
							<Link to="/buttons" className={navLinkClass('/buttons')}>Buttons</Link>
							<Link to="/icon-buttons" className={navLinkClass('/icon-buttons')}>IconButtons</Link>
							<Link to="/icons" className={navLinkClass('/icons')}>Icons</Link>
							<Link to="/stack" className={navLinkClass('/stack')}>Stack</Link>
							<Link to="/layout" className={navLinkClass('/layout')}>Layout</Link>
							<Link to="/section" className={navLinkClass('/section')}>Section</Link>
							<Link to="/bar" className={navLinkClass('/bar')}>Bar</Link>
							<Link to="/modal" className={navLinkClass('/modal')}>Modal</Link>
						</nav>
					</Bar.Center>
					<Bar.End>
						<div className="flex items-center gap-2">
							<IconButton icon={BsIcons.Trash} ariaLabel="Limpar" theme="alert" />
							<Button label="Ação" theme="primary" size="sm" />
						</div>
					</Bar.End>
				</Bar>
			</AppLayout.Top>

			<AppLayout.LeftMenu>
				<div className="p-3 text-sm space-y-2">
					<h2 className="font-semibold text-neutral-600">Menu</h2>
					<ul className="space-y-1">
						<li><Link to="/" className="hover:underline">Home</Link></li>
						<li><Link to="/buttons" className="hover:underline">Buttons</Link></li>
						<li><Link to="/icon-buttons" className="hover:underline">IconButtons</Link></li>
						<li><Link to="/icons" className="hover:underline">Icons</Link></li>
						<li><Link to="/stack" className="hover:underline">Stack</Link></li>
					</ul>
				</div>
			</AppLayout.LeftMenu>

			<AppLayout.MainContent>
				<div className="p-6 md:p-7 lg:p-8 max-xs:p-4">
					{/* Header dinâmico de página via SectionOutlet */}
					<div className="mb-4">
						<SectionOutlet id="header" />
					</div>
					<Outlet />
				</div>
			</AppLayout.MainContent>

			<AppLayout.RightMenu>
				<div className="p-3 text-sm space-y-3">
					<h2 className="font-semibold text-neutral-600">Info</h2>
					<p className="text-neutral-500">Exemplo de conteúdo lateral direito.</p>
				</div>
			</AppLayout.RightMenu>

			<AppLayout.Footer>
				<div className="px-4 flex items-center justify-between h-full text-xs text-neutral-600">
					<span>© {new Date().getFullYear()} Yasamen Demo</span>
					<span>Layout: AppLayout + Slots</span>
				</div>
			</AppLayout.Footer>

			<AppLayout.PostContent>
				{/* Espaço pós layout se necessário */}
			</AppLayout.PostContent>
		</AppLayout>
	);
};

export default DemoMainLayout;
