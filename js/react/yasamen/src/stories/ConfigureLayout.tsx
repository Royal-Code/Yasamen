import React from 'react';

import Github from './assets/github.svg';
import Discord from './assets/discord.svg';
import Youtube from './assets/youtube.svg';
import Tutorials from './assets/tutorials.svg';
import Styling from './assets/styling.png';
import Context from './assets/context.png';
import Assets from './assets/assets.png';
import Docs from './assets/docs.png';
import Share from './assets/share.png';
import FigmaPlugin from './assets/figma-plugin.png';
import Testing from './assets/testing.png';
import Accessibility from './assets/accessibility.png';
import Theming from './assets/theming.png';
import AddonLibrary from './assets/addon-library.png';
import './Configure.css';

// Lightweight docs layout component (replaces brittle MDX HTML from SB8)
export const ConfigureLayout: React.FC = () => {
  return (
    <div className="sb-container">
      <h1>Configure your project</h1>
      <p>
        Storybook runs outside your app. Configure it for your stack (framework, styling, assets, providers) and extend with docs, testing & publishing.
      </p>

      <h2>Essentials</h2>
      <ul className="sb-list">
  <li><img src={Styling} alt="Styling" /> <strong>Styling & CSS</strong> – Multiple strategies to include CSS. <a href="https://storybook.js.org/docs/configure/styling-and-css/?renderer=react" target="_blank" rel="noopener noreferrer">Learn more</a></li>
  <li><img src={Context} alt="Context" /> <strong>Context & Mocking</strong> – Provide themes, routers & data. <a href="https://storybook.js.org/docs/writing-stories/decorators/?renderer=react#context-for-mocking" target="_blank" rel="noopener noreferrer">Learn more</a></li>
  <li><img src={Assets} alt="Assets" /> <strong>Static assets</strong> – Serve fonts/images via <code>staticDirs</code>. <a href="https://storybook.js.org/docs/configure/images-and-assets/?renderer=react" target="_blank" rel="noopener noreferrer">Learn more</a></li>
      </ul>

      <h2>Do more with Storybook</h2>
      <ul className="sb-list">
  <li><img src={Docs} alt="Docs" /> <strong>Autodocs</strong> – Interactive docs from stories. <a href="https://storybook.js.org/docs/writing-docs/autodocs/?renderer=react" target="_blank" rel="noopener noreferrer">Learn more</a></li>
  <li><img src={Share} alt="Share" /> <strong>Publish</strong> – Host & collaborate (Chromatic). <a href="https://storybook.js.org/docs/sharing/publish-storybook/?renderer=react#publish-storybook-with-chromatic" target="_blank" rel="noopener noreferrer">Learn more</a></li>
  <li><img src={FigmaPlugin} alt="Figma" /> <strong>Figma plugin</strong> – Embed stories in design files. <a href="https://storybook.js.org/docs/sharing/design-integrations/?renderer=react#embed-storybook-in-figma-with-the-plugin" target="_blank" rel="noopener noreferrer">Learn more</a></li>
  <li><img src={Testing} alt="Testing" /> <strong>Testing</strong> – Interaction, a11y, visual, coverage. <a href="https://storybook.js.org/docs/writing-tests/?renderer=react" target="_blank" rel="noopener noreferrer">Learn more</a></li>
  <li><img src={Accessibility} alt="Accessibility" /> <strong>Accessibility</strong> – Catch WCAG issues early. <a href="https://storybook.js.org/docs/writing-tests/accessibility-testing/?renderer=react" target="_blank" rel="noopener noreferrer">Learn more</a></li>
  <li><img src={Theming} alt="Theming" /> <strong>Theming</strong> – Customize Storybook UI. <a href="https://storybook.js.org/docs/configure/theming/?renderer=react" target="_blank" rel="noopener noreferrer">Learn more</a></li>
      </ul>

      <h2>Addons</h2>
  <p><img src={AddonLibrary} alt="Addon library" /> Extend workflows with community & custom addons. <a href="https://storybook.js.org/addons/" target="_blank" rel="noopener noreferrer">Discover addons</a></p>

      <h2>Community</h2>
      <ul className="sb-list">
  <li><img src={Github} alt="Github" /> GitHub: <a href="https://github.com/storybookjs/storybook" target="_blank" rel="noopener noreferrer">Star & issues</a></li>
  <li><img src={Discord} alt="Discord" /> Discord: <a href="https://discord.gg/storybook" target="_blank" rel="noopener noreferrer">Chat & support</a></li>
  <li><img src={Youtube} alt="YouTube" /> YouTube: <a href="https://www.youtube.com/@chromaticui" target="_blank" rel="noopener noreferrer">Tutorials</a></li>
  <li><img src={Tutorials} alt="Tutorials" /> Tutorials: <a href="https://storybook.js.org/tutorials/" target="_blank" rel="noopener noreferrer">Guided workflows</a></li>
      </ul>

  <p className="sb-footer-note">Storybook 10 – ESM-only, leaner core, optional docs/test packages, module automocking & CSF Factories (preview).</p>
    </div>
  );
};

export default ConfigureLayout;
