# Implementation Plan: React Forms Components

## Overview

This implementation plan breaks down the React Forms Components feature into discrete coding tasks. The implementation follows a bottom-up approach, starting with utility functions, then building the foundational FieldGroup component, followed by the specialized components (FieldText, FieldAction, FieldBadge), and finally the high-level TextField component. Each component includes property-based tests to validate correctness properties from the design document.

The implementation uses TypeScript, React functional components with hooks, and integrates with the existing Yasamen component library. Property-based testing uses @fast-check/jest library.

## Tasks

- [ ] 1. Set up project structure and dependencies
  - Create directory structure: `src/components/TextField/`, `src/components/FieldGroup/`, `src/components/FieldText/`, `src/components/FieldAction/`, `src/components/FieldBadge/`, `src/utils/`
  - Install @fast-check/jest for property-based testing
  - Set up TypeScript configuration for React components
  - Create index files for component exports
  - _Requirements: All requirements (project setup)_

- [ ] 2. Implement error handling utilities
  - [ ] 2.1 Create error message type definitions
    - Define `ErrorMessage` type (string | { message?: string } | undefined | null)
    - Export type from `src/utils/errorHandling.ts`
    - _Requirements: 12.1, 12.2, 12.3, 12.4_

  - [ ] 2.2 Implement error message extraction function
    - Create `getErrorMessage(error: ErrorMessage): string | undefined` function
    - Handle string errors, object errors with message property, undefined, null, empty strings
    - _Requirements: 12.1, 12.2, 12.3, 12.4_

  - [ ]* 2.3 Write property test for error message extraction
    - **Property 48: Error Message Extraction**
    - **Validates: Requirements 12.1, 12.2**
    - Generate random error values (string, object, undefined, null, empty string)
    - Verify correct error message extraction for all cases

  - [ ]* 2.4 Write unit tests for error edge cases
    - Test undefined returns undefined
    - Test null returns undefined
    - Test empty string returns undefined
    - Test object without message property returns undefined
    - _Requirements: 12.3, 12.4_

- [ ] 3. Implement FieldText component
  - [ ] 3.1 Create FieldText component with TypeScript interface
    - Define `FieldTextProps` interface extending `React.HTMLAttributes<HTMLDivElement>`
    - Implement functional component with forwardRef (if needed)
    - Render div with `ya-field-text` class
    - Spread HTML attributes to div
    - _Requirements: 3.1, 3.2, 3.3, 8.3_

  - [ ]* 3.2 Write property test for FieldText base class
    - **Property 28: FieldText Base Class**
    - **Validates: Requirements 3.1, 10.11**
    - Generate random FieldText props
    - Verify ya-field-text class is always present

  - [ ]* 3.3 Write property test for FieldText children rendering
    - **Property 29: FieldText Children Rendering**
    - **Validates: Requirements 3.2**
    - Generate random React nodes as children
    - Verify children are rendered inside div

  - [ ]* 3.4 Write property test for FieldText attribute pass-through
    - **Property 30: FieldText Attribute Pass-Through**
    - **Validates: Requirements 3.3**
    - Generate random valid HTML div attributes
    - Verify attributes are applied to div element

- [ ] 4. Implement FieldAction component
  - [ ] 4.1 Create FieldAction component with TypeScript interface
    - Define `FieldActionProps` interface with label, icon, iconPosition, theme, outline, active, disabled, onClick
    - Wrap existing Yasamen Button component
    - Add `ya-field-action` class to Button
    - Pass all props to Button component
    - _Requirements: 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8, 4.9, 8.4_

  - [ ]* 4.2 Write property test for FieldAction base class
    - **Property 31: FieldAction Base Class**
    - **Validates: Requirements 4.1, 10.12**
    - Generate random FieldAction props
    - Verify ya-field-action class is always present

  - [ ]* 4.3 Write property test for FieldAction label display
    - **Property 32: FieldAction Label Display**
    - **Validates: Requirements 4.2**
    - Generate random label strings
    - Verify label text appears in button

  - [ ]* 4.4 Write property test for FieldAction icon display
    - **Property 33: FieldAction Icon Display**
    - **Validates: Requirements 4.3**
    - Generate random icon components
    - Verify icon is rendered in button

  - [ ]* 4.5 Write property test for FieldAction icon position
    - **Property 34: FieldAction Icon Position**
    - **Validates: Requirements 4.4**
    - Test both left and right iconPosition values
    - Verify icon position is correct

  - [ ]* 4.6 Write property test for FieldAction theme styling
    - **Property 35: FieldAction Theme Styling**
    - **Validates: Requirements 4.5**
    - Generate random theme values
    - Verify appropriate theme styling is applied

  - [ ]* 4.7 Write property test for FieldAction click handler
    - **Property 36: FieldAction Click Handler**
    - **Validates: Requirements 4.9**
    - Generate random onClick handlers
    - Simulate click events and verify handler is called

  - [ ]* 4.8 Write property test for FieldAction keyboard accessibility
    - **Property 46: FieldAction Keyboard Accessibility**
    - **Validates: Requirements 9.7**
    - Generate random onClick handlers
    - Simulate Enter and Space key presses
    - Verify onClick handler is called

  - [ ]* 4.9 Write unit tests for FieldAction boolean props
    - Test outline prop
    - Test active prop
    - Test disabled prop
    - _Requirements: 4.6, 4.7, 4.8_

- [ ] 5. Implement FieldBadge component
  - [ ] 5.1 Create FieldBadge component with TypeScript interface
    - Define `FieldBadgeProps` interface with text, children, theme
    - Wrap existing Yasamen Badge component
    - Add `ya-field-badge` class to Badge
    - Support text or children for content
    - Apply `ya-badge-{theme}` class based on theme
    - _Requirements: 5.1, 5.2, 5.3, 5.4, 5.5, 8.5_

  - [ ]* 5.2 Write property test for FieldBadge base class
    - **Property 37: FieldBadge Base Class**
    - **Validates: Requirements 5.1, 10.13**
    - Generate random FieldBadge props
    - Verify ya-field-badge class is always present

  - [ ]* 5.3 Write property test for FieldBadge text display
    - **Property 38: FieldBadge Text Display**
    - **Validates: Requirements 5.2**
    - Generate random text strings
    - Verify text appears in badge

  - [ ]* 5.4 Write property test for FieldBadge children display
    - **Property 39: FieldBadge Children Display**
    - **Validates: Requirements 5.3**
    - Generate random React nodes as children
    - Verify children are rendered in badge

  - [ ]* 5.5 Write property test for FieldBadge theme styling
    - **Property 40: FieldBadge Theme Styling**
    - **Validates: Requirements 5.4, 5.5**
    - Generate random theme values
    - Verify ya-badge-{theme} class is applied

- [ ] 6. Checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 7. Implement FieldGroup component
  - [ ] 7.1 Create FieldGroup component with TypeScript interface
    - Define `FieldGroupProps` interface with label, descriptionComplement, children, information, error, prepend, append, footerAction, size, expanded, invalid, htmlFor
    - Implement functional component
    - Render container div with `ya-field-group` class
    - Implement conditional rendering for label section, control section, informative section
    - Apply size classes (`ya-field-{size}`)
    - Apply invalid class when error is present
    - Wrap control in `ya-control-group` when prepend or append is present
    - _Requirements: 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8, 2.9, 2.10, 2.11, 2.12, 2.13, 2.14, 2.15, 8.2_

  - [ ]* 7.2 Write property test for FieldGroup container class
    - **Property 15: FieldGroup Container Class**
    - **Validates: Requirements 2.1, 10.4**
    - Generate random FieldGroup props
    - Verify ya-field-group class is always present

  - [ ]* 7.3 Write property test for FieldGroup label rendering
    - **Property 16: FieldGroup Label Rendering**
    - **Validates: Requirements 2.2, 10.6**
    - Generate random label strings
    - Verify label element with ya-field-group-label class is rendered

  - [ ]* 7.4 Write property test for label for attribute
    - **Property 17: Label For Attribute**
    - **Validates: Requirements 2.3**
    - Generate random label and htmlFor combinations
    - Verify label's for attribute matches htmlFor

  - [ ]* 7.5 Write property test for description complement rendering
    - **Property 18: Description Complement Rendering**
    - **Validates: Requirements 2.4**
    - Generate random React nodes for descriptionComplement
    - Verify content appears in description section

  - [ ]* 7.6 Write property test for FieldGroup prepend rendering
    - **Property 19: FieldGroup Prepend Rendering**
    - **Validates: Requirements 2.5**
    - Generate random React nodes for prepend
    - Verify prepend appears before children in ya-control-group

  - [ ]* 7.7 Write property test for FieldGroup append rendering
    - **Property 20: FieldGroup Append Rendering**
    - **Validates: Requirements 2.6**
    - Generate random React nodes for append
    - Verify append appears after children in ya-control-group

  - [ ]* 7.8 Write property test for FieldGroup children rendering
    - **Property 21: FieldGroup Children Rendering**
    - **Validates: Requirements 2.7, 11.1**
    - Generate random React nodes as children
    - Verify children are rendered in control section

  - [ ]* 7.9 Write property test for FieldGroup information display
    - **Property 22: FieldGroup Information Display**
    - **Validates: Requirements 2.8, 10.9**
    - Generate random information strings
    - Verify information with ya-field-information class is displayed

  - [ ]* 7.10 Write property test for FieldGroup error display
    - **Property 23: FieldGroup Error Display**
    - **Validates: Requirements 2.9**
    - Generate random error values
    - Verify error message is displayed in informative section

  - [ ]* 7.11 Write property test for FieldGroup invalid state
    - **Property 24: FieldGroup Invalid State**
    - **Validates: Requirements 2.10, 10.5**
    - Generate random error values
    - Verify ya-field-group-invalid class is applied

  - [ ]* 7.12 Write property test for FieldGroup footer action
    - **Property 25: FieldGroup Footer Action**
    - **Validates: Requirements 2.11, 10.10, 11.2**
    - Generate random React nodes for footerAction
    - Verify footer action appears with ya-field-group-footer class

  - [ ]* 7.13 Write property test for FieldGroup size class
    - **Property 10: Size Class Application (FieldGroup)**
    - **Validates: Requirements 2.12, 14.1, 14.3, 14.4**
    - Generate random size values
    - Verify ya-field-{size} class is applied

  - [ ]* 7.14 Write property test for FieldGroup description section class
    - **Property 26: FieldGroup Description Section Class**
    - **Validates: Requirements 2.14, 10.7**
    - Generate random props that trigger description section
    - Verify ya-field-group-description class is present

  - [ ]* 7.15 Write property test for FieldGroup informative section class
    - **Property 27: FieldGroup Informative Section Class**
    - **Validates: Requirements 2.15, 10.8**
    - Generate random props that trigger informative section
    - Verify ya-field-group-informative class is present

  - [ ]* 7.16 Write property test for control group CSS class
    - **Property 47: Control Group CSS Class**
    - **Validates: Requirements 10.14, 13.4**
    - Generate random prepend/append props
    - Verify ya-control-group class is present

  - [ ]* 7.17 Write property test for error takes precedence over information
    - **Property 50: Error Takes Precedence Over Information**
    - **Validates: Requirements 12.7**
    - Generate random error and information combinations
    - Verify error is displayed and information is not

  - [ ]* 7.18 Write property test for prepend and append order
    - **Property 51: Prepend and Append Order**
    - **Validates: Requirements 13.3**
    - Generate random prepend and append content
    - Verify rendering order is prepend, children, append

  - [ ]* 7.19 Write property test for content rendering without wrappers
    - **Property 52: Content Rendering Without Wrappers**
    - **Validates: Requirements 13.5, 13.6**
    - Generate random prepend/append content
    - Verify content is rendered directly without extra wrappers

  - [ ]* 7.20 Write unit tests for FieldGroup edge cases
    - Test expanded prop
    - Test invalid prop
    - Test empty children
    - _Requirements: 2.13_

- [ ] 8. Checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 9. Implement TextField component
  - [ ] 9.1 Create TextField component with TypeScript interface
    - Define `TextFieldProps` interface extending input HTML attributes with custom props (label, information, error, descriptionComplement, prepend, append, footerAction, size, expanded)
    - Implement functional component with forwardRef
    - Generate unique IDs using React.useId() for label association and aria-describedby
    - Render FieldGroup internally with all layout props
    - Render input element with ya-input-field class
    - Apply ya-input-field-invalid class when error is present
    - Forward ref to input element
    - Handle error normalization using getErrorMessage utility
    - Set aria-invalid and aria-describedby attributes
    - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 1.10, 1.11, 1.12, 1.13, 1.14, 1.15, 1.16, 1.17, 1.18, 8.1_

  - [ ]* 9.2 Write property test for controlled input value and handler
    - **Property 1: Controlled Input Value and Handler**
    - **Validates: Requirements 1.1**
    - Generate random value strings and onChange handlers
    - Verify input has correct value and onChange is called

  - [ ]* 9.3 Write property test for input type attribute
    - **Property 2: Input Type Attribute**
    - **Validates: Requirements 1.2**
    - Generate random input types
    - Verify input has correct type attribute

  - [ ]* 9.4 Write property test for label association
    - **Property 3: Label Association**
    - **Validates: Requirements 1.3, 9.1**
    - Generate random label strings
    - Verify label's htmlFor matches input's id

  - [ ]* 9.5 Write property test for placeholder pass-through
    - **Property 4: Placeholder Pass-Through**
    - **Validates: Requirements 1.4**
    - Generate random placeholder strings
    - Verify input has correct placeholder attribute

  - [ ]* 9.6 Write property test for information text display
    - **Property 5: Information Text Display**
    - **Validates: Requirements 1.5**
    - Generate random information strings
    - Verify information is displayed with ya-field-information class

  - [ ]* 9.7 Write property test for error display and invalid state
    - **Property 6: Error Display and Invalid State**
    - **Validates: Requirements 1.6, 1.16**
    - Generate random error values
    - Verify error message is displayed and ya-input-field-invalid class is applied

  - [ ]* 9.8 Write property test for prepend content rendering
    - **Property 7: Prepend Content Rendering**
    - **Validates: Requirements 1.7**
    - Generate random React nodes for prepend
    - Verify prepend appears before input in ya-control-group

  - [ ]* 9.9 Write property test for append content rendering
    - **Property 8: Append Content Rendering**
    - **Validates: Requirements 1.8**
    - Generate random React nodes for append
    - Verify append appears after input in ya-control-group

  - [ ]* 9.10 Write property test for footer action rendering
    - **Property 9: Footer Action Rendering**
    - **Validates: Requirements 1.9**
    - Generate random React nodes for footerAction
    - Verify footer action appears with ya-field-group-footer class

  - [ ]* 9.11 Write property test for size class application
    - **Property 10: Size Class Application (TextField)**
    - **Validates: Requirements 1.10, 14.1, 14.3, 14.4**
    - Generate random size values
    - Verify ya-field-{size} class is applied

  - [ ]* 9.12 Write property test for maxLength attribute
    - **Property 11: MaxLength Attribute**
    - **Validates: Requirements 1.13**
    - Generate random positive integers
    - Verify input has correct maxLength attribute

  - [ ]* 9.13 Write property test for ref forwarding
    - **Property 12: Ref Forwarding**
    - **Validates: Requirements 1.14, 6.4**
    - Generate random ref objects
    - Verify ref references the input DOM element

  - [ ]* 9.14 Write property test for base input CSS class
    - **Property 13: Base Input CSS Class**
    - **Validates: Requirements 1.15, 10.1**
    - Generate random TextField props
    - Verify ya-input-field class is always present

  - [ ]* 9.15 Write property test for onBlur handler
    - **Property 14: OnBlur Handler**
    - **Validates: Requirements 1.17, 7.5**
    - Generate random onBlur handlers
    - Simulate blur events and verify handler is called

  - [ ]* 9.16 Write property test for name prop support
    - **Property 42: Name Prop Support**
    - **Validates: Requirements 6.5, 7.4**
    - Generate random name strings
    - Verify input has correct name attribute

  - [ ]* 9.17 Write property test for error accessibility attributes
    - **Property 44: Error Accessibility Attributes**
    - **Validates: Requirements 9.2, 9.3**
    - Generate random error values
    - Verify aria-invalid and aria-describedby are set correctly

  - [ ]* 9.18 Write property test for information accessibility
    - **Property 45: Information Accessibility**
    - **Validates: Requirements 9.4**
    - Generate random information strings
    - Verify aria-describedby references information element

  - [ ]* 9.19 Write property test for error message location
    - **Property 49: Error Message Location**
    - **Validates: Requirements 12.5**
    - Generate random error values
    - Verify error appears in informative section below control

  - [ ]* 9.20 Write unit tests for TextField boolean props
    - Test disabled prop
    - Test readonly prop
    - Test expanded prop
    - _Requirements: 1.11, 1.12, 1.18_

  - [ ]* 9.21 Write unit tests for default size
    - Test that medium is default size when size prop is not provided
    - _Requirements: 14.2_

- [ ] 10. Implement React Hook Form integration
  - [ ] 10.1 Add React Hook Form integration examples to TextField
    - Document how to use TextField with register props
    - Document how to pass errors from formState
    - Create example usage in component documentation
    - _Requirements: 6.1, 6.2, 6.3, 6.4, 6.5_

  - [ ]* 10.2 Write property test for React Hook Form error handling
    - **Property 41: React Hook Form Error Handling**
    - **Validates: Requirements 6.2, 6.3**
    - Generate random React Hook Form error objects
    - Verify error message display and invalid class

  - [ ]* 10.3 Write integration test for React Hook Form register
    - Test TextField with actual React Hook Form register
    - Verify register props are spread correctly
    - _Requirements: 6.1_

- [ ] 11. Implement Formik integration
  - [ ] 11.1 Add Formik integration examples to TextField
    - Document how to use TextField with field props
    - Document how to pass errors from Formik
    - Create example usage in component documentation
    - _Requirements: 7.1, 7.2, 7.3, 7.4, 7.5_

  - [ ]* 11.2 Write property test for Formik error handling
    - **Property 43: Formik Error Handling**
    - **Validates: Requirements 7.2, 7.3**
    - Generate random Formik error values
    - Verify error message display and invalid class

  - [ ]* 11.3 Write integration test for Formik field props
    - Test TextField with actual Formik field props
    - Verify field props are spread correctly
    - _Requirements: 7.1_

- [ ] 12. Create component exports and documentation
  - [ ] 12.1 Create index file for all components
    - Export TextField, FieldGroup, FieldText, FieldAction, FieldBadge
    - Export all TypeScript interfaces
    - Export error handling utilities
    - _Requirements: 8.1, 8.2, 8.3, 8.4, 8.5_

  - [ ] 12.2 Create component usage examples
    - Create example for TextField standalone usage
    - Create example for FieldGroup custom composition
    - Create example for React Hook Form integration
    - Create example for Formik integration
    - Create example with prepend/append/footerAction
    - _Requirements: All requirements (documentation)_

  - [ ] 12.3 Add TypeScript documentation comments
    - Add JSDoc comments to all component props
    - Add JSDoc comments to all exported functions
    - Document prop types and default values
    - _Requirements: 8.6, 8.7, 8.8_

- [ ] 13. Final checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

## Notes

- Tasks marked with `*` are optional and can be skipped for faster MVP
- Each property test references a specific correctness property from the design document
- Property tests use @fast-check/jest with minimum 100 iterations
- Unit tests focus on specific examples and edge cases
- Integration tests verify compatibility with React Hook Form and Formik
- All components use TypeScript for type safety
- Components follow existing Yasamen patterns and CSS classes
- Ref forwarding is implemented using React.forwardRef
- Unique IDs are generated using React.useId() hook (React 18+)
