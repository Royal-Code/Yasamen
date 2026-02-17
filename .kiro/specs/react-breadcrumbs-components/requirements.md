# Requirements Document: React Breadcrumbs Components

## Introduction

This document specifies the requirements for implementing Breadcrumb navigation components in the Yasamen React library. The implementation will port the functionality from the existing Razor/Blazor Breadcrumb components to React, maintaining consistency with the existing Yasamen design patterns and component architecture.

The breadcrumb system provides hierarchical navigation that shows users their current location within the application structure. It supports both simple breadcrumb trails and smart breadcrumbs with overflow handling for long navigation paths.

## Glossary

- **Breadcrumb**: A navigation component that displays a hierarchical trail of links showing the user's location
- **BreadcrumbItem**: An individual link or text element within a breadcrumb trail
- **Breadcrumbs**: A smart component that automatically manages breadcrumb items from a data array
- **BreadcrumbData**: A data object describing a single breadcrumb item (text, href, state)
- **Active_Item**: The last item in the breadcrumb trail representing the current page
- **Overflow_Menu**: A dropdown menu that contains hidden breadcrumb items when the trail exceeds MaxVisibleItems
- **MaxVisibleItems**: The maximum number of breadcrumb items to display before creating an overflow menu
- **Compound_Component**: A component pattern where multiple sub-components work together as a cohesive unit
- **Navigation_State**: Optional state object passed during navigation (for React Router state)

## Requirements

### Requirement 1: Breadcrumb Container Component

**User Story:** As a developer, I want a breadcrumb container component, so that I can create semantic navigation trails with proper structure and styling.

#### Acceptance Criteria

1. WHEN a Breadcrumb component is rendered, THE System SHALL render a nav element with aria-label="breadcrumb"
2. WHEN a Breadcrumb component is rendered, THE System SHALL render an ordered list (ol) element inside the nav
3. THE Breadcrumb SHALL apply the CSS class "ya-breadcrumb" to the nav element
4. THE Breadcrumb SHALL support custom className for additional styling
5. THE Breadcrumb SHALL accept BreadcrumbItem components as children
6. THE Breadcrumb SHALL support flexible content through the children prop

### Requirement 2: BreadcrumbItem Component

**User Story:** As a developer, I want individual breadcrumb item components, so that I can build custom breadcrumb trails with links and text.

#### Acceptance Criteria

1. WHEN a BreadcrumbItem is rendered, THE System SHALL render a list item (li) element with class "ya-breadcrumb-item"
2. WHEN a BreadcrumbItem has an href prop, THE System SHALL render a Link component (from react-router) inside the list item
3. WHEN a BreadcrumbItem has an onClick prop but no href, THE System SHALL render a clickable button element
4. WHEN a BreadcrumbItem has neither href nor onClick, THE System SHALL render a span element
5. WHEN a BreadcrumbItem is marked as active, THE System SHALL add the "active" class to the link/button/span element
6. WHEN a BreadcrumbItem is marked as active, THE System SHALL add aria-current="page" to the element
7. THE BreadcrumbItem link/button/span SHALL have the CSS class "ya-breadcrumb-link"
8. THE BreadcrumbItem SHALL support flexible content through the children prop
9. WHEN a BreadcrumbItem with onClick is clicked, THE System SHALL invoke the onClick callback

### Requirement 3: Breadcrumb Data Model

**User Story:** As a developer, I want a TypeScript interface for breadcrumb data, so that I can pass structured breadcrumb information to smart components.

#### Acceptance Criteria

1. THE System SHALL define a BreadcrumbData interface with text property (required string)
2. THE BreadcrumbData interface SHALL include an optional href property (string)
3. THE BreadcrumbData interface SHALL include an optional state property (any type) for navigation state
4. THE BreadcrumbData interface SHALL include an optional onClick property (function)
5. THE System SHALL export the BreadcrumbData interface for use in application code

### Requirement 4: Smart Breadcrumbs Component

**User Story:** As a developer, I want a smart breadcrumbs component that automatically manages items from a data array, so that I can easily create breadcrumb trails without manual component composition.

#### Acceptance Criteria

1. WHEN a Breadcrumbs component receives an items array, THE System SHALL render a Breadcrumb container with BreadcrumbItem components for each item
2. WHEN the items array length is less than or equal to maxVisibleItems, THE System SHALL render all items as visible breadcrumbs
3. WHEN the items array length exceeds maxVisibleItems, THE System SHALL render the first item, an overflow menu, and the last (maxVisibleItems - 2) items
4. WHEN an overflow menu is created, THE System SHALL contain all hidden items as menu items in a Dropdown component
5. THE Breadcrumbs component SHALL mark the last item in the trail as active
6. WHEN a breadcrumb item has an href property, THE System SHALL render it as a navigable link
7. WHEN a breadcrumb item has an onClick property, THE System SHALL render it as a clickable button and invoke onClick when clicked
8. WHEN a breadcrumb item has both href and onClick, THE System SHALL prioritize href for navigation
9. THE Breadcrumbs component SHALL support a maxVisibleItems prop with a default value of 5

### Requirement 5: Overflow Menu Integration

**User Story:** As a developer, I want breadcrumb overflow to use existing Dropdown components, so that the UI is consistent with other dropdown menus in the application.

#### Acceptance Criteria

1. WHEN creating an overflow menu, THE System SHALL use the Dropdown.IconButton component with an ellipsis icon
2. WHEN creating an overflow menu, THE System SHALL use the Dropdown.Menu component to contain hidden items
3. WHEN creating an overflow menu, THE System SHALL use Dropdown.Item components for each hidden breadcrumb
4. THE overflow menu icon button SHALL have the CSS class "ya-breadcrumb-dropdown"
5. WHEN a user clicks an overflow menu item with href, THE System SHALL navigate to the href
6. WHEN a user clicks an overflow menu item with onClick, THE System SHALL invoke the onClick callback
7. THE overflow menu SHALL close after an item is clicked

### Requirement 6: React Router Integration

**User Story:** As a developer, I want breadcrumbs to integrate with React Router, so that navigation works seamlessly with my application routing.

#### Acceptance Criteria

1. WHEN a BreadcrumbItem has an href prop, THE System SHALL use the Link component from react-router-dom
2. WHEN a BreadcrumbData item has a state property, THE System SHALL pass it to the Link component as navigation state
3. WHEN a breadcrumb link is clicked, THE System SHALL use React Router navigation instead of full page reload
4. THE System SHALL support both relative and absolute paths in href properties
5. THE System SHALL work correctly with React Router's useNavigate hook for programmatic navigation

### Requirement 7: Accessibility Support

**User Story:** As a user with assistive technology, I want breadcrumb components to be accessible, so that I can understand and navigate the breadcrumb trail using keyboard and screen readers.

#### Acceptance Criteria

1. WHEN a Breadcrumb is rendered, THE System SHALL include aria-label="breadcrumb" on the nav element
2. WHEN a BreadcrumbItem is active, THE System SHALL include aria-current="page" on the link/button/span
3. WHEN a breadcrumb link receives focus, THE System SHALL display a visible focus indicator
4. WHEN a user navigates with Tab key, THE System SHALL follow logical focus order through breadcrumb links
5. THE System SHALL use semantic HTML elements (nav, ol, li) for proper structure
6. WHEN an overflow menu is present, THE System SHALL ensure the dropdown button has appropriate ARIA attributes
7. THE System SHALL ensure screen readers announce breadcrumb items in correct order

### Requirement 8: Breadcrumb Separators

**User Story:** As a developer, I want automatic separators between breadcrumb items, so that the navigation trail is visually clear without manual separator insertion.

#### Acceptance Criteria

1. WHEN breadcrumb items are rendered, THE System SHALL display visual separators between items using CSS
2. THE System SHALL not render a separator after the last breadcrumb item
3. THE separators SHALL be implemented using CSS pseudo-elements (::before or ::after)
4. THE separators SHALL not be announced by screen readers (decorative only)
5. THE System SHALL support customization of separator appearance through CSS variables

### Requirement 9: Compound Component Pattern

**User Story:** As a developer, I want to use a compound component API, so that I can compose breadcrumb components in an intuitive and flexible way.

#### Acceptance Criteria

1. THE System SHALL export a Breadcrumb namespace object with Item property
2. WHEN using Breadcrumb.Item, THE System SHALL render a BreadcrumbItem component
3. THE Compound pattern SHALL allow flexible composition of breadcrumb components
4. THE System SHALL also export a standalone Breadcrumbs component for data-driven usage
5. THE System SHALL support both compound component pattern and data-driven pattern simultaneously

### Requirement 10: CSS Integration

**User Story:** As a developer, I want breadcrumb components to use existing Yasamen CSS classes, so that styling is consistent with the design system.

#### Acceptance Criteria

1. THE System SHALL use CSS classes with the "ya-breadcrumb" prefix for breadcrumb-specific styling
2. THE System SHALL apply the "ya-breadcrumb" class to the nav container
3. THE System SHALL apply the "ya-breadcrumb-item" class to each list item
4. THE System SHALL apply the "ya-breadcrumb-link" class to each link/button/span
5. THE System SHALL apply the "ya-breadcrumb-dropdown" class to the overflow menu button
6. THE System SHALL apply the "active" class to the active breadcrumb item
7. THE System SHALL integrate with existing Tailwind CSS utilities
8. THE System SHALL support custom className props for additional styling

### Requirement 11: TypeScript Type Safety

**User Story:** As a developer, I want full TypeScript support, so that I can catch errors at compile time and have excellent IDE autocomplete.

#### Acceptance Criteria

1. THE System SHALL export TypeScript interfaces for all component props
2. THE System SHALL define the BreadcrumbData interface with proper type annotations
3. THE System SHALL provide type definitions for onClick callbacks
4. THE System SHALL ensure all exported types are properly documented with JSDoc comments
5. THE System SHALL use proper generic types for navigation state objects

### Requirement 12: Breadcrumb Item Content Flexibility

**User Story:** As a developer, I want to include custom content in breadcrumb items, so that I can add icons, badges, or other elements alongside text.

#### Acceptance Criteria

1. WHEN a BreadcrumbItem receives children, THE System SHALL render the children inside the link/button/span
2. THE BreadcrumbItem SHALL support React nodes as children (text, elements, fragments)
3. WHEN using the Breadcrumbs component with data array, THE System SHALL render the text property as the item content
4. THE System SHALL support mixing text and icon content in breadcrumb items
5. THE System SHALL maintain proper spacing and alignment for custom content

### Requirement 13: Responsive Behavior

**User Story:** As a user on mobile devices, I want breadcrumbs to adapt to smaller screens, so that navigation remains usable on all device sizes.

#### Acceptance Criteria

1. WHEN the viewport is narrow, THE System SHALL maintain readable breadcrumb text
2. WHEN breadcrumbs exceed available width, THE System SHALL allow text to wrap or truncate based on CSS configuration
3. THE System SHALL ensure touch targets for breadcrumb links meet minimum size requirements (44x44px)
4. THE System SHALL ensure the overflow menu button is easily tappable on touch devices
5. THE System SHALL maintain proper spacing between items on all screen sizes

### Requirement 14: Empty State Handling

**User Story:** As a developer, I want proper handling of empty breadcrumb arrays, so that the component doesn't break with invalid data.

#### Acceptance Criteria

1. WHEN the Breadcrumbs component receives an empty items array, THE System SHALL render nothing (null)
2. WHEN the Breadcrumbs component receives an undefined items prop, THE System SHALL render nothing (null)
3. WHEN the Breadcrumbs component receives a single item, THE System SHALL render it as an active breadcrumb without links
4. THE System SHALL not throw errors when receiving invalid or empty data
5. THE System SHALL log a warning in development mode when receiving empty or invalid data

### Requirement 15: Navigation State Preservation

**User Story:** As a developer, I want to pass state objects during breadcrumb navigation, so that I can preserve context when users navigate through the breadcrumb trail.

#### Acceptance Criteria

1. WHEN a BreadcrumbData item includes a state property, THE System SHALL pass it to React Router's Link component
2. WHEN a breadcrumb link is clicked, THE System SHALL preserve the state object for the target route
3. THE state object SHALL be accessible in the target component via useLocation hook
4. THE System SHALL support any serializable object as navigation state
5. WHEN using onClick instead of href, THE System SHALL pass the state object to the onClick callback
