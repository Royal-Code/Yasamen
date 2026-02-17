# Implementation Plan: React Breadcrumbs Components

## Overview

This implementation plan breaks down the React Breadcrumbs components into discrete coding tasks. The implementation will create a compound component pattern for manual breadcrumb composition (`Breadcrumb.Item`) and a smart component for data-driven usage (`Breadcrumbs`) with automatic overflow handling.

The implementation follows the existing Yasamen patterns and integrates with React Router for navigation and the existing Dropdown components for overflow menus.

## Tasks

- [ ] 1. Set up breadcrumb component structure and types
  - Create directory: `js/react/yasamen/src/lib/components/breadcrumb/`
  - Create `breadcrumb-types.ts` with BreadcrumbData interface
  - Create `breadcrumb-classes.ts` with CSS class constants
  - Create `index.ts` for exports
  - _Requirements: 3.1, 3.2, 3.3, 3.4, 10.1, 10.2, 10.3, 10.4, 10.5, 10.6_

- [ ] 2. Implement BreadcrumbContainer component
  - [ ] 2.1 Create BreadcrumbContainer.tsx with nav and ol structure
    - Implement BreadcrumbContainerProps interface
    - Render nav element with aria-label and ya-breadcrumb class
    - Render ol element with ya-breadcrumb-list class
    - Support custom className prop
    - Support flexible children
    - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.5, 1.6_

  - [ ]* 2.2 Write property test for BreadcrumbContainer structure
    - **Property 1: Breadcrumb container structure**
    - **Validates: Requirements 1.1, 1.2, 1.3**

  - [ ]* 2.3 Write property test for custom className
    - **Property 2: Custom className application**
    - **Validates: Requirements 1.4**

  - [ ]* 2.4 Write property test for children rendering
    - **Property 3: Children rendering**
    - **Validates: Requirements 1.5, 1.6, 2.8**

- [ ] 3. Implement BreadcrumbItem component
  - [ ] 3.1 Create BreadcrumbItem.tsx with conditional rendering logic
    - Implement BreadcrumbItemProps interface
    - Render li element with ya-breadcrumb-item class
    - Implement conditional rendering: href → Link, onClick → button, neither → span
    - Apply ya-breadcrumb-link class to inner element
    - Support active state with active class and aria-current="page"
    - Support custom className prop
    - Support flexible children
    - Implement onClick handler
    - _Requirements: 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8, 2.9, 6.1_

  - [ ]* 3.2 Write property test for list item structure
    - **Property 4: BreadcrumbItem list item structure**
    - **Validates: Requirements 2.1**

  - [ ]* 3.3 Write property test for conditional element rendering
    - **Property 5: BreadcrumbItem conditional element rendering**
    - **Validates: Requirements 2.2, 2.3, 2.4, 6.1**

  - [ ]* 3.4 Write property test for active state
    - **Property 6: Active state styling and ARIA**
    - **Validates: Requirements 2.5, 2.6**

  - [ ]* 3.5 Write property test for link CSS class
    - **Property 7: Breadcrumb link CSS class**
    - **Validates: Requirements 2.7**

  - [ ]* 3.6 Write property test for onClick invocation
    - **Property 8: BreadcrumbItem onClick invocation**
    - **Validates: Requirements 2.9**

- [ ] 4. Implement compound component pattern
  - [ ] 4.1 Create Breadcrumb.tsx with compound component export
    - Import BreadcrumbContainer and BreadcrumbItem
    - Create Breadcrumb namespace using Object.assign
    - Export Breadcrumb with Item property
    - _Requirements: 9.1, 9.2, 9.3_

  - [ ]* 4.2 Write unit test for compound component API
    - Test Breadcrumb.Item renders BreadcrumbItem
    - Test manual composition with multiple items
    - _Requirements: 9.2_

- [ ] 5. Checkpoint - Ensure basic breadcrumb components work
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 6. Implement Breadcrumbs smart component - basic rendering
  - [ ] 6.1 Create Breadcrumbs.tsx with items array handling
    - Implement BreadcrumbsProps interface
    - Handle empty/undefined items array (return null, log warning)
    - Handle single item (render as active span)
    - Render all items when length <= maxVisibleItems
    - Mark last item as active
    - Support maxVisibleItems prop with default value of 5
    - Support custom className and ariaLabel props
    - _Requirements: 4.1, 4.2, 4.5, 4.6, 4.7, 4.8, 4.9, 12.3, 14.1, 14.2, 14.3, 14.4, 14.5_

  - [ ]* 6.2 Write property test for rendering all items within limit
    - **Property 9: Breadcrumbs renders all items when within limit**
    - **Validates: Requirements 4.1, 4.2**

  - [ ]* 6.3 Write property test for last item marked as active
    - **Property 11: Last item marked as active**
    - **Validates: Requirements 4.5**

  - [ ]* 6.4 Write property test for item href renders as link
    - **Property 12: Item href renders as link**
    - **Validates: Requirements 4.6**

  - [ ]* 6.5 Write property test for item onClick invocation
    - **Property 13: Item onClick invocation in Breadcrumbs**
    - **Validates: Requirements 4.7**

  - [ ]* 6.6 Write property test for href priority over onClick
    - **Property 14: href priority over onClick**
    - **Validates: Requirements 4.8**

  - [ ]* 6.7 Write property test for text rendering
    - **Property 18: Breadcrumbs text rendering**
    - **Validates: Requirements 12.3**

  - [ ]* 6.8 Write property test for empty items array handling
    - **Property 19: Empty items array handling**
    - **Validates: Requirements 14.1, 14.2, 14.4, 14.5**

  - [ ]* 6.9 Write property test for single item rendering
    - **Property 20: Single item rendering**
    - **Validates: Requirements 14.3**

- [ ] 7. Implement Breadcrumbs overflow handling
  - [ ] 7.1 Add overflow logic to Breadcrumbs.tsx
    - Calculate visible and hidden items when length > maxVisibleItems
    - Render first item as visible breadcrumb
    - Create Dropdown.IconButton with ellipsis icon
    - Apply ya-breadcrumb-dropdown class to dropdown button
    - Create Dropdown.Menu with hidden items as Dropdown.Item components
    - Render last (maxVisibleItems - 2) items as visible breadcrumbs
    - Handle onClick and href for overflow menu items
    - _Requirements: 4.3, 4.4, 5.1, 5.2, 5.3, 5.4, 5.5, 5.6, 5.7_

  - [ ]* 7.2 Write property test for overflow structure
    - **Property 10: Breadcrumbs overflow structure**
    - **Validates: Requirements 4.3, 4.4, 5.1, 5.2, 5.3, 5.4**

  - [ ]* 7.3 Write property test for overflow menu item navigation
    - **Property 15: Overflow menu item navigation**
    - **Validates: Requirements 5.5, 5.6**

  - [ ]* 7.4 Write property test for overflow menu closes after click
    - **Property 16: Overflow menu closes after click**
    - **Validates: Requirements 5.7**

- [ ] 8. Implement React Router state passing
  - [ ] 8.1 Add state prop support to BreadcrumbItem and Breadcrumbs
    - Pass state prop to Link component in BreadcrumbItem
    - Pass state from BreadcrumbData to Link in Breadcrumbs
    - _Requirements: 6.2, 15.1_

  - [ ]* 8.2 Write property test for state passed to Link
    - **Property 17: State passed to Link component**
    - **Validates: Requirements 6.2**

- [ ] 9. Checkpoint - Ensure all breadcrumb functionality works
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 10. Create CSS styles for breadcrumbs
  - [ ] 10.1 Create breadcrumb.scss in sass directory
    - Define .ya-breadcrumb container styles
    - Define .ya-breadcrumb-list styles
    - Define .ya-breadcrumb-item styles with separators using ::before
    - Define .ya-breadcrumb-link styles with hover and focus states
    - Define .active class styles
    - Define .ya-breadcrumb-dropdown styles
    - Ensure separators are not rendered after last item
    - Ensure separators are decorative (not announced by screen readers)
    - Support CSS variables for separator customization
    - Ensure touch targets meet 44x44px minimum
    - Add responsive styles for narrow viewports
    - _Requirements: 8.1, 8.2, 8.3, 8.4, 8.5, 13.1, 13.2, 13.3, 13.4, 13.5_

  - [ ]* 10.2 Write unit test for CSS class application
    - Test all CSS classes are applied correctly
    - Test custom className is applied
    - _Requirements: 10.1, 10.2, 10.3, 10.4, 10.5, 10.6, 10.8_

- [ ] 11. Update exports and documentation
  - [ ] 11.1 Update index.ts files
    - Export Breadcrumb compound component
    - Export Breadcrumbs smart component
    - Export BreadcrumbData interface
    - Export breadcrumb types and classes
    - _Requirements: 3.5, 9.4_

  - [ ] 11.2 Add JSDoc comments to all exports
    - Document all component props with JSDoc
    - Document BreadcrumbData interface properties
    - Document usage examples
    - _Requirements: 11.4_

- [ ] 12. Final checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

## Notes

- Tasks marked with `*` are optional and can be skipped for faster MVP
- Each task references specific requirements for traceability
- Checkpoints ensure incremental validation
- Property tests validate universal correctness properties using fast-check
- Unit tests validate specific examples and edge cases
- The implementation integrates with existing Yasamen components (Button, IconButton, Dropdown)
- React Router integration uses the Link component from react-router-dom
- CSS styles follow existing Yasamen patterns and use the ya-breadcrumb prefix
