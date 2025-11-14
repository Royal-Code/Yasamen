// Workspace style export: array of project configs.
// Using a single inline project with jsdom environment.
export default [
  {
    test: {
      environment: 'jsdom',
      setupFiles: ['vitest.setup.ts']
    }
  }
];
