import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import tailwindcss from '@tailwindcss/vite';
import dts from 'vite-plugin-dts';
import { resolve } from 'path';

export default defineConfig(({ mode }) => {
  const isDemo = mode === 'demo' || process.env.BUILD_TARGET === 'demo';

  if (isDemo) {
    return {
      plugins: [react(), tailwindcss()],
      build: {
        outDir: 'dist-demo',
      },
    };
  }

  return {
    plugins: [
      react(),
      tailwindcss(),
      dts({
        tsconfigPath: './tsconfig.lib.json',
      }),
    ],
    build: {
      lib: {
        entry: resolve(process.cwd(), 'src/lib/index.ts'),
        name: 'Yasamen',
        fileName: (format) => `yasamen.${format === 'es' ? 'js' : 'cjs'}`,
        formats: ['es', 'cjs'],
      },
      rollupOptions: {
        external: [
          'react',
          'react-dom',
          'react/jsx-runtime',
          'react/jsx-dev-runtime',
          'react-router-dom',
        ],
        output: {
          assetFileNames: (assetInfo) => {
            if (assetInfo.name?.endsWith('.css')) return 'yasamen.css';
            return assetInfo.name || '[name].[ext]';
          },
          globals: {
            react: 'React',
            'react-dom': 'ReactDOM',
            'react-router-dom': 'ReactRouterDOM',
          },
        },
      },
      cssCodeSplit: false,
      sourcemap: true,
    },
  };
});
