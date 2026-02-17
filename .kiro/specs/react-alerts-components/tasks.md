# Implementation Plan: React Alerts Components

## Overview

This implementation plan breaks down the React Alerts components into discrete coding tasks. The approach follows an incremental pattern: set up infrastructure, implement individual components (Badge, Notification, NotificationContent, Feedback), then build the notification system (Context, Provider, Hook, Outlet), and finally wire everything together with tests.

## Tasks

- [ ] 1. Set up project structure and type definitions
  - Create directory structure: `src/lib/components/alerts/`
  - Create type definition files: `alert-types.ts`, `badge-types.ts`, `notification-types.ts`, `feedback-types.ts`
  - Define Theme, Size, IconPosition, and Placement enums
  - Define NotificationItem, NotificationHandle, and NotifyService interfaces
  - Create CSS class mapping files: `badge-classes.ts`, `notification-classes.ts`, `notification-content-classes.ts`, `feedback-classes.ts`, `notification-group-classes.ts`
  - _Requirements: 10.1, 10.2, 10.3, 10.4, 10.5, 10.6, 10.7, 10.8, 10.9, 10.10, 10.11, 12.1, 12.2, 12.3, 12.4, 12.5_

- [ ] 2. Implement Badge component
  - [ ] 2.1 Create Badge component with text and children support
    - Implement Badge.tsx with BadgeProps interface
    - Render div with ya-badge class
    - Support both text prop and children prop
    - Apply theme and size CSS classes
    - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.7, 1.8_
  
  - [ ] 2.2 Add icon support with positioning
    - Add icon and iconPosition props
    - Render icon before content when iconPosition="start"
    - Render icon after content when iconPosition="end"
    - Throw error when iconPosition="center"
    - _Requirements: 1.5, 1.6, 1.9_
  
  - [ ]* 2.3 Write property tests for Badge
    - **Property 1: Badge renders content in correct structure**
    - **Validates: Requirements 1.1, 1.2**
    - **Property 2: Badge theme CSS class application**
    - **Validates: Requirements 1.3**
    - **Property 3: Badge size CSS class application**
    - **Validates: Requirements 1.4**
    - **Property 4: Icon position determines DOM order**
    - **Validates: Requirements 1.5, 1.6**
  
  - [ ]* 2.4 Write unit tests for Badge edge cases
    - Test iconPosition="center" throws error
    - Test default theme and size values
    - Test empty content rendering
    - Test custom className application
    - _Requirements: 1.7, 1.8, 1.9_

- [ ] 3. Implement Notification component
  - [ ] 3.1 Create base Notification structure
    - Implement Notification.tsx with NotificationProps interface
    - Render div with role="alert" and ya-notification class
    - Render notification-box container
    - Render content section with ya-notification-content class
    - Support text prop and children prop
    - Apply theme CSS classes
    - _Requirements: 2.1, 2.2, 2.3, 2.6, 2.8_
  
  - [ ] 3.2 Add icon and close button support
    - Implement conditional icon section rendering (icon=true)
    - Implement conditional bar rendering (icon=false)
    - Implement conditional close button rendering (closeable=true)
    - Add closeOnClick functionality
    - _Requirements: 2.4, 2.5, 2.7, 4.1, 4.2_
  
  - [ ] 3.3 Implement timer with auto-close
    - Add timer prop and useEffect for auto-close
    - Render progress bar with ya-notification-timer class
    - Animate progress bar from 100% to 0%
    - Call onClose callback when timer completes
    - Set closed state when timer completes
    - Clean up timer on unmount
    - _Requirements: 3.1, 3.2, 3.3, 3.6, 3.7_
  
  - [ ] 3.4 Implement timer pause/resume on hover
    - Add onMouseEnter handler to pause timer
    - Add onMouseLeave handler to resume timer
    - Track remaining time when paused
    - Resume from remaining time
    - _Requirements: 3.4, 3.5_
  
  - [ ] 3.5 Implement controlled/uncontrolled state
    - Add open prop for controlled mode
    - Add startClosed prop for uncontrolled initial state
    - Implement internal state management
    - Add onOpen and onClose callbacks
    - _Requirements: 4.3, 4.4, 4.5, 4.8, 4.9_
  
  - [ ] 3.6 Implement ref handle for programmatic control
    - Use forwardRef and useImperativeHandle
    - Expose open() and close() methods via NotificationHandle
    - _Requirements: 4.6, 4.7_
  
  - [ ]* 3.7 Write property tests for Notification
    - **Property 5: Notification base structure**
    - **Validates: Requirements 2.1, 2.3, 2.6**
    - **Property 6: Notification theme CSS class application**
    - **Validates: Requirements 2.2**
    - **Property 7: Icon prop determines icon section or bar rendering**
    - **Validates: Requirements 2.4, 2.5**
    - **Property 8: Closeable prop controls close button rendering**
    - **Validates: Requirements 2.7**
    - **Property 9: Timer auto-closes notification**
    - **Validates: Requirements 3.1, 3.6, 3.7**
    - **Property 10: Timer renders progress bar**
    - **Validates: Requirements 3.2, 3.3**
    - **Property 11: Timer pause/resume on hover**
    - **Validates: Requirements 3.4, 3.5**
    - **Property 12: CloseOnClick closes notification**
    - **Validates: Requirements 4.1**
    - **Property 13: Close button closes notification**
    - **Validates: Requirements 4.2**
    - **Property 14: Close and open callbacks invoked**
    - **Validates: Requirements 4.3, 4.4**
    - **Property 15: StartClosed sets initial state**
    - **Validates: Requirements 4.5**
    - **Property 16: NotificationHandle ref exposes control methods**
    - **Validates: Requirements 4.6, 4.7**
    - **Property 17: Controlled vs uncontrolled state**
    - **Validates: Requirements 4.8, 4.9**
  
  - [ ]* 3.8 Write unit tests for Notification edge cases
    - Test default theme value
    - Test timer cleanup on unmount
    - Test callback error handling
    - Test empty content rendering
    - _Requirements: 2.8_

- [ ] 4. Checkpoint - Ensure Badge and Notification tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 5. Implement NotificationContent component
  - [ ] 5.1 Create NotificationContent component
    - Implement NotificationContent.tsx with NotificationContentProps interface
    - Render div with ya-notification-content-group class
    - Conditionally render text in div with ya-notification-content-text class
    - Conditionally render details in div with ya-notification-content-details class
    - Ensure text appears before details in DOM
    - _Requirements: 5.1, 5.2, 5.3, 5.4_
  
  - [ ]* 5.2 Write property tests for NotificationContent
    - **Property 18: NotificationContent structure**
    - **Validates: Requirements 5.1, 5.2, 5.3, 5.4**
  
  - [ ]* 5.3 Write unit tests for NotificationContent edge cases
    - Test with only text
    - Test with only details
    - Test with both text and details
    - Test with neither text nor details

- [ ] 6. Implement Feedback component
  - [ ] 6.1 Create base Feedback structure
    - Implement Feedback.tsx with FeedbackProps interface
    - Render div with role="alert" and ya-feedback class
    - Apply theme, size, and block CSS classes
    - Render content section with ya-feedback-content class
    - _Requirements: 6.1, 6.2, 6.3, 6.4, 6.6, 6.19, 6.20, 6.21, 11.2_
  
  - [ ] 6.2 Add icon, title, text, and children support
    - Conditionally render icon section with ya-feedback-icon class
    - Conditionally render title as heading (h2-h6) based on size
    - Apply ya-feedback-title class to heading
    - Conditionally render text in paragraph with ya-feedback-text class
    - Render children after title and text
    - _Requirements: 6.5, 6.7, 6.8, 6.9, 6.10, 6.11, 6.12, 6.13, 6.14, 6.15, 6.16_
  
  - [ ] 6.3 Add close button support
    - Conditionally render close button when closeable=true
    - Implement close functionality
    - Call onClose callback when closed
    - _Requirements: 6.17, 6.18_
  
  - [ ]* 6.4 Write property tests for Feedback
    - **Property 19: Feedback base structure**
    - **Validates: Requirements 6.1, 6.6, 11.2**
    - **Property 20: Feedback theme CSS class application**
    - **Validates: Requirements 6.2**
    - **Property 21: Feedback size CSS class application**
    - **Validates: Requirements 6.3**
    - **Property 22: Feedback block CSS class application**
    - **Validates: Requirements 6.4**
    - **Property 23: Feedback icon rendering**
    - **Validates: Requirements 6.5**
    - **Property 24: Feedback heading level matches size**
    - **Validates: Requirements 6.7, 6.8, 6.9, 6.10, 6.11, 6.12, 6.13, 6.14**
    - **Property 25: Feedback text rendering**
    - **Validates: Requirements 6.15**
    - **Property 26: Feedback children rendering order**
    - **Validates: Requirements 6.16**
    - **Property 27: Feedback close button**
    - **Validates: Requirements 6.17, 6.18**
  
  - [ ]* 6.5 Write unit tests for Feedback edge cases
    - Test default theme, size, and block values
    - Test all heading levels for all sizes
    - Test empty content rendering
    - Test callback error handling
    - _Requirements: 6.19, 6.20, 6.21_

- [ ] 7. Checkpoint - Ensure all component tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 8. Implement notification system context and provider
  - [ ] 8.1 Create NotificationContext and NotificationProvider
    - Create notification-context.ts with NotificationContextValue interface
    - Implement NotificationContext with createContext
    - Implement useNotificationContext hook with error handling
    - Implement NotificationProvider component
    - Initialize empty notifications array state
    - Implement addNotification function with unique ID generation
    - Implement removeNotification function
    - _Requirements: 7.1, 7.2, 7.3, 7.4_
  
  - [ ] 8.2 Implement notification grouping by placement
    - Group notifications by placement in provider state
    - Support all six placement positions
    - _Requirements: 7.5_
  
  - [ ]* 8.3 Write unit tests for notification context
    - Test useNotificationContext outside provider throws error
    - Test initial empty state
    - Test addNotification adds with unique ID
    - Test removeNotification removes by ID
    - Test grouping by placement
    - _Requirements: 7.2, 8.2_

- [ ] 9. Implement useNotify hook
  - [ ] 9.1 Create useNotify hook with show method
    - Create use-notify.ts with NotifyService interface
    - Implement useNotify hook that uses useNotificationContext
    - Implement show() method that calls addNotification
    - Implement auto-timer calculation function (3000ms + text.length * 50ms)
    - Apply auto-timer when timer is not provided
    - _Requirements: 8.1, 8.3, 8.4, 8.16, 8.17_
  
  - [ ] 9.2 Add theme-specific convenience methods
    - Implement primary(), secondary(), tertiary() methods
    - Implement success(), danger(), warning(), alert() methods
    - Implement info(), highlight(), light(), dark() methods
    - Each method should call show() with appropriate theme
    - Set default placement to "top-end"
    - Set default icon=true and closeable=true
    - _Requirements: 8.5, 8.6, 8.7, 8.8, 8.9, 8.10, 8.11, 8.12, 8.13, 8.14, 8.15_
  
  - [ ]* 9.3 Write property tests for useNotify
    - **Property 28: Notification system adds notifications**
    - **Validates: Requirements 7.3, 8.3**
    - **Property 31: Theme-specific convenience methods**
    - **Validates: Requirements 8.5-8.15**
    - **Property 32: Auto-calculate timer from text length**
    - **Validates: Requirements 8.16, 8.17**
  
  - [ ]* 9.4 Write unit tests for useNotify edge cases
    - Test useNotify outside provider throws error
    - Test show() with all configuration options
    - Test each theme-specific method
    - Test auto-timer calculation with various text lengths
    - _Requirements: 8.2_

- [ ] 10. Implement NotificationOutlet component
  - [ ] 10.1 Create NotificationOutlet component
    - Implement NotificationOutlet.tsx
    - Consume NotificationContext
    - Group notifications by placement using useMemo
    - Render notification groups for each placement
    - Apply ya-notification-group and ya-notification-group-{placement} classes
    - Render Notification components for each item in group
    - Pass NotificationContent when details are provided
    - Handle notification close by calling removeNotification
    - _Requirements: 9.1, 9.2, 9.3, 9.4, 9.5_
  
  - [ ]* 10.2 Write property tests for NotificationOutlet
    - **Property 29: Notification system removes notifications**
    - **Validates: Requirements 7.4, 9.5**
    - **Property 30: Notifications grouped by placement**
    - **Validates: Requirements 7.5, 9.2, 9.3, 9.4**
  
  - [ ]* 10.3 Write unit tests for NotificationOutlet
    - Test empty notifications renders nothing
    - Test single notification in one placement
    - Test multiple notifications in same placement
    - Test notifications in different placements
    - Test notification removal on close

- [ ] 11. Add accessibility features
  - [ ] 11.1 Add ARIA labels to close buttons
    - Add aria-label="Close notification" to Notification close button
    - Add aria-label="Close feedback" to Feedback close button
    - _Requirements: 11.3_
  
  - [ ] 11.2 Add ARIA attributes to timer progress bar
    - Add role="progressbar" to timer element
    - Add aria-valuenow, aria-valuemin, aria-valuemax attributes
    - Update aria-valuenow as timer progresses
    - _Requirements: 11.4_
  
  - [ ] 11.3 Add accessible labels for icon-only badges
    - Add aria-label when Badge has only icon (no text or children)
    - _Requirements: 11.5_
  
  - [ ]* 11.4 Write property tests for accessibility
    - **Property 33: Close button accessible label**
    - **Validates: Requirements 11.3**
    - **Property 34: Timer progress bar ARIA attributes**
    - **Validates: Requirements 11.4**

- [ ] 12. Create component exports and index
  - [ ] 12.1 Create index.ts for alerts module
    - Export Badge component
    - Export Notification component and NotificationHandle type
    - Export NotificationContent component
    - Export Feedback component
    - Export NotificationProvider component
    - Export useNotify hook
    - Export NotificationOutlet component
    - Export all types: Theme, Size, IconPosition, Placement, NotificationItem, NotifyService
  
  - [ ] 12.2 Update main library index
    - Add alerts components to main library exports
    - Ensure proper tree-shaking support

- [ ] 13. Integration testing
  - [ ]* 13.1 Write integration tests for notification system
    - Test NotificationProvider + useNotify + NotificationOutlet together
    - Test showing notification via notify.success()
    - Test notification appears in correct placement
    - Test notification auto-closes after timer
    - Test notification closes on close button click
    - Test multiple notifications stack correctly
  
  - [ ]* 13.2 Write integration tests for Notification ref control
    - Test NotificationHandle ref methods
    - Test programmatic open() and close()
    - Test ref methods work with controlled and uncontrolled modes
  
  - [ ]* 13.3 Write integration tests for timer interactions
    - Test timer pause on hover
    - Test timer resume on mouse leave
    - Test progress bar animation
    - Test timer cleanup on unmount

- [ ] 14. Final checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

## Notes

- Tasks marked with `*` are optional and can be skipped for faster MVP
- Each task references specific requirements for traceability
- Property tests validate universal correctness properties
- Unit tests validate specific examples and edge cases
- Integration tests validate end-to-end flows
- Checkpoints ensure incremental validation
- All components follow existing Yasamen patterns and CSS class conventions
