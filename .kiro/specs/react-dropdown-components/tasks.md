# Implementation Plan: React Dropdown Components

## Overview

This implementation plan breaks down the React Dropdown components feature into discrete, incremental coding tasks. Each task builds on previous work, with testing integrated throughout to validate functionality early. The implementation follows the compound component pattern established in the Yasamen library and integrates with existing Button, IconButton, and context systems.

## Tasks

- [ ] 1. Set up dropdown component structure and types
  - Create `src/lib/components/dropdown/` directory
  - Create type definitions file `dropdown-types.ts` with Directions, DropCloseBehavior, and DropContentType enums
  - Create CSS classes file `dropdown-classes.ts` with DropdownClasses mapping
  - Create barrel export `index.ts`
  - _Requirements: 12.2, 11.1_

- [ ] 2. Implement dropdown context system
  - [ ] 2.1 Create dropdown context
    - Create `dropdown-context.ts` with DropdownContext and DropdownContextValue interface
    - Implement `useDropdownContext` hook with error handling
    - _Requirements: 5.1, 5.4_
  
  - [ ]* 2.2 Write property test for context
    - **Property 13: Context provides complete state to all children**
    - **Validates: Requirements 5.1, 5.2, 5.3, 5.4**

- [ ] 3. Implement useDropdown hook
  - [ ] 3.1 Create useDropdown hook with state management
    - Create `use-dropdown.ts` with UseDropdownOptions and UseDropdownReturn interfaces
    - Implement isOpen state with useState
    - Implement open, close, and toggle functions
    - Create refs for dropdown and trigger elements
    - _Requirements: 4.1, 4.2, 4.3, 4.4_
  
  - [ ] 3.2 Add click outside detection
    - Implement useEffect for click outside handler
    - Handle CloseOnClickOutside behavior
    - Handle CloseOnClick behavior
    - Respect CloseManually behavior
    - _Requirements: 4.5, 4.7, 4.8_
  
  - [ ] 3.3 Add keyboard interaction
    - Implement useEffect for Escape key handler
    - Close dropdown on Escape
    - Return focus to trigger button
    - _Requirements: 4.6, 10.5_
  
  - [ ]* 3.4 Write property tests for useDropdown hook
    - **Property 2: Dropdown opens only when closed**
    - **Property 3: Dropdown does not re-open when already open**
    - **Property 4: Click outside closes dropdown**
    - **Property 5: Escape key closes dropdown and returns focus**
    - **Property 7: Manual close behavior prevents automatic closing**
    - **Property 18: Toggle function inverts state**
    - **Validates: Requirements 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8**

- [ ] 4. Checkpoint - Ensure hook tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 5. Implement DropdownMenu component
  - [ ] 5.1 Create DropdownMenu component
    - Create `DropdownMenu.tsx` with DropdownMenuProps interface
    - Implement conditional rendering based on isOpen from context
    - Render ul element for List contentType, div for Custom
    - Apply appropriate ARIA roles
    - Apply CSS classes from DropdownClasses
    - Support custom className prop
    - _Requirements: 7.1, 7.2, 7.3, 7.4, 7.5, 7.6_
  
  - [ ]* 5.2 Write property tests for DropdownMenu
    - **Property 8: Element type matches contentType**
    - **Property 9: Dropdown menu visibility matches isOpen state**
    - **Property 16: Custom className is applied**
    - **Validates: Requirements 7.1, 7.2, 7.3, 7.4, 7.5**

- [ ] 6. Implement DropdownItem component
  - [ ] 6.1 Create DropdownItem component
    - Create `DropdownItem.tsx` with DropdownItemProps interface
    - Access context with useDropdownContext
    - Render li element for List contentType, div for Custom
    - Apply appropriate ARIA roles
    - Implement onClick handler with close behavior
    - Support disabled state
    - Apply CSS classes from DropdownClasses
    - _Requirements: 3.1, 3.2, 3.3, 3.4, 3.5, 3.6_
  
  - [ ]* 6.2 Write property tests for DropdownItem
    - **Property 6: Click item closes dropdown with CloseOnClick behavior**
    - **Property 12: Disabled items do not trigger actions**
    - **Property 17: Item onClick callback is invoked**
    - **Validates: Requirements 3.1, 3.2, 3.3, 3.4, 3.6**

- [ ] 7. Implement DropdownHandler
  - [ ] 7.1 Create DropdownHandler interface and factory
    - Create `DropdownHandler.ts` with DropdownHandler interface
    - Implement `createDropdownHandler` factory function
    - _Requirements: 9.1_
  
  - [ ]* 7.2 Write property tests for DropdownHandler
    - **Property 10: Handler methods control dropdown state**
    - **Validates: Requirements 9.2, 9.3, 9.4, 9.5**

- [ ] 8. Checkpoint - Ensure component tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 9. Implement DropdownButton component
  - [ ] 9.1 Create DropdownButton component
    - Create `DropdownButton.tsx` with DropdownButtonProps interface
    - Extend ButtonProps and add dropdown-specific props
    - Integrate useDropdown hook
    - Provide DropdownContext to children
    - Render Button component with all props
    - Handle button click to open dropdown
    - Connect handler if provided
    - Apply aria-expanded and aria-haspopup attributes
    - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 10.2, 10.3, 10.4_
  
  - [ ]* 9.2 Write property tests for DropdownButton
    - **Property 1: Button props pass-through**
    - **Property 11: ARIA expanded attribute reflects dropdown state**
    - **Property 14: Callbacks are invoked on state changes**
    - **Property 15: CSS classes applied based on configuration**
    - **Property 19: ARIA roles are correctly applied**
    - **Validates: Requirements 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 10.2, 10.3, 10.4**

- [ ] 10. Implement DropdownIconButton component
  - [ ] 10.1 Create DropdownIconButton component
    - Create `DropdownIconButton.tsx` with DropdownIconButtonProps interface
    - Extend IconButtonProps and add dropdown-specific props
    - Follow same pattern as DropdownButton but with IconButton
    - _Requirements: 2.1, 2.2, 2.3, 2.4, 2.5_
  
  - [ ]* 10.2 Write property tests for DropdownIconButton
    - **Property 1: Button props pass-through** (IconButton variant)
    - **Validates: Requirements 2.1, 2.2, 2.3, 2.4, 2.5**

- [ ] 11. Create compound component namespace
  - [ ] 11.1 Create Dropdown namespace
    - Create `Dropdown.tsx` that exports namespace object
    - Attach Button, IconButton, Menu, and Item as properties
    - _Requirements: 8.1, 8.2, 8.3, 8.4, 8.5_
  
  - [ ] 11.2 Update barrel export
    - Export Dropdown namespace from `index.ts`
    - Export all types and interfaces
    - Export DropdownHandler factory
    - _Requirements: 12.1_

- [ ] 12. Checkpoint - Ensure integration tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 13. Add accessibility features
  - [ ] 13.1 Implement Tab navigation
    - Add keyboard navigation support for Tab key
    - Ensure focus moves through items in logical order
    - _Requirements: 10.6_
  
  - [ ] 13.2 Add aria-label support to DropdownItem
    - Add aria-label prop to DropdownItemProps
    - Apply aria-label attribute to rendered element
    - _Requirements: 10.7_
  
  - [ ]* 13.3 Write property test for accessibility
    - **Property 20: Tab navigation follows logical order**
    - **Validates: Requirements 10.6**

- [ ] 14. Create CSS styles
  - [ ] 14.1 Create dropdown CSS file
    - Create `src/lib/styles/css/components/dropdown.css`
    - Define base dropdown styles with ya-drop- prefix
    - Define positioning classes for direction (up, down, left, right)
    - Define alignment classes (start, center, end)
    - Define min-width classes for all sizes
    - Define item styles and disabled state
    - Define transition animations
    - _Requirements: 11.1, 11.2, 11.3, 11.6_
  
  - [ ] 14.2 Import dropdown CSS in yasamen.css
    - Add `@import './css/components/dropdown.css';` to yasamen.css
    - _Requirements: 11.1_

- [ ] 15. Update commons exports
  - [ ] 15.1 Export dropdown classes from commons
    - Add DropdownClasses to `src/lib/components/commons/themes.ts`
    - Export DropdownClassesMap type
    - Update commons index.ts to export dropdown classes
    - _Requirements: 11.1_

- [ ] 16. Create Storybook stories
  - [ ] 16.1 Create DropdownButton story
    - Create `src/stories/Dropdown.stories.tsx`
    - Add stories for basic dropdown with items
    - Add stories for different themes and sizes
    - Add stories for different directions and alignments
    - Add stories for different close behaviors
    - Add story demonstrating handler usage
  
  - [ ] 16.2 Create DropdownIconButton story
    - Add stories for icon button dropdown
    - Add stories showing all icon button variants

- [ ] 17. Final checkpoint - Ensure all tests pass
  - Run all unit tests and property tests
  - Verify all requirements are covered
  - Ensure all tests pass, ask the user if questions arise.

## Notes

- Tasks marked with `*` are optional property-based tests and can be skipped for faster MVP
- Each task references specific requirements for traceability
- Checkpoints ensure incremental validation
- Property tests validate universal correctness properties with minimum 100 iterations
- Unit tests validate specific examples and edge cases
- CSS implementation follows existing Yasamen patterns with ya- prefix
- TypeScript types ensure compile-time safety
- Accessibility is integrated throughout, not added as an afterthought
